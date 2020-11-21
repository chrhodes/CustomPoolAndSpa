using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using CustomPoolAndSpa.Core.Events;
using CustomPoolAndSpa.DomainServices;

using Prism.Events;

using VNC;
using VNC.Core.DomainServices;
using VNC.Core.Mvvm;

namespace CustomPoolAndSpa.Presentation.ServiceAddress.ViewModels
{
    public class ServiceAddressViewModel : ViewModelBase, IServiceAddressViewModel
    {
        private IServiceAddressLookupDataService _ServiceAddressLookupDataService;
        private IEventAggregator _eventAggregator;

        public ServiceAddressViewModel(
                IServiceAddressLookupDataService ServiceAddressLookupDataService,
                IEventAggregator eventAggregator)
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            _ServiceAddressLookupDataService = ServiceAddressLookupDataService;
            _eventAggregator = eventAggregator;
            ServiceAddresses = new ObservableCollection<LookupItem>();

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task LoadAsync()
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            var lookup = await _ServiceAddressLookupDataService.GetServiceAddressLookupAsync();
            ServiceAddresses.Clear();

            foreach (var item in lookup)
            {
                ServiceAddresses.Add(item);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public ObservableCollection<LookupItem> ServiceAddresses { get; }

        public IView View
        {
            get;
            set;
        }

        LookupItem _selectedServiceAddress;

        public LookupItem SelectedServiceAddress
        {
            get { return _selectedServiceAddress; }
            set
            {
                _selectedServiceAddress = value;
                OnPropertyChanged();

                if (_selectedServiceAddress != null)
                {
                    _eventAggregator.GetEvent<OpenServiceAddressDetailViewEvent>()
                        .Publish(_selectedServiceAddress.Id);
                }
            }
        }
    }
}
