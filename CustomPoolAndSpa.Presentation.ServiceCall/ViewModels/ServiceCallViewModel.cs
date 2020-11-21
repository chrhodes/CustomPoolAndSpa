using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using CustomPoolAndSpa.Core.Events;
using CustomPoolAndSpa.DomainServices;

using Prism.Events;

using VNC;
using VNC.Core.DomainServices;
using VNC.Core.Mvvm;

namespace CustomPoolAndSpa.Presentation.ServiceCall.ViewModels
{
    public class ServiceCallViewModel : ViewModelBase, IServiceCallViewModel
    {
        private IServiceCallLookupDataService _ServiceCallLookupDataService;
        private IEventAggregator _eventAggregator;

        public ServiceCallViewModel(
                IServiceCallLookupDataService ServiceCallLookupDataService,
                IEventAggregator eventAggregator)
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            _ServiceCallLookupDataService = ServiceCallLookupDataService;
            _eventAggregator = eventAggregator;
            ServiceCalls = new ObservableCollection<LookupItem>();

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task LoadAsync()
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            var lookup = await _ServiceCallLookupDataService.GetServiceCallLookupAsync();
            ServiceCalls.Clear();

            foreach (var item in lookup)
            {
                ServiceCalls.Add(item);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public ObservableCollection<LookupItem> ServiceCalls { get; }

        public IView View
        {
            get;
            set;
        }

        LookupItem _selectedServiceCall;

        public LookupItem SelectedServiceCall
        {
            get { return _selectedServiceCall; }
            set
            {
                _selectedServiceCall = value;
                OnPropertyChanged();

                if (_selectedServiceCall != null)
                {
                    _eventAggregator.GetEvent<OpenServiceCallDetailViewEvent>()
                        .Publish(_selectedServiceCall.Id);
                }
            }
        }
    }
}
