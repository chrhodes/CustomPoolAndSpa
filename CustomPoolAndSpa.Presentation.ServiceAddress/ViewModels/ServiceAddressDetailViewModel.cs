using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

using CustomPoolAndSpa.Core.Events;
using CustomPoolAndSpa.DomainServices;

using Prism.Commands;
using Prism.Events;

using VNC;
using VNC.Core.Mvvm;

namespace CustomPoolAndSpa.Presentation.ServiceAddress.ViewModels
{
    class ServiceAddressDetailViewModel : ViewModelBase, IServiceAddressDetailViewModel
    {
        private IServiceAddressDataService _dataService;
        private IEventAggregator _eventAggregator;

        public ServiceAddressDetailViewModel(
                IServiceAddressDataService dataService,
                IEventAggregator eventAggregator)
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            _dataService = dataService;
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<OpenServiceAddressDetailViewEvent>()
                .Subscribe(OnOpenServiceAddressDetailView);

            SaveCommand = new DelegateCommand(
                OnSaveExecute, OnSaveCanExecute);

            AddServiceCallCommand = new DelegateCommand(
                OnAddServiceCallExecute, OnAddServiceCallCanExecute);

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        private async void OnOpenServiceAddressDetailView(int typeId)
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            await LoadAsync(typeId);

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task LoadAsync(int id)
        {
            ServiceAddress = await _dataService.FindByIdAsync(id);
        }

        private Domain.ServiceAddress _ServiceAddress;

        public Domain.ServiceAddress ServiceAddress
        {
            get { return _ServiceAddress; }
            private set
            {
                _ServiceAddress = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

        async void OnSaveExecute()
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            await _dataService.UpdateAsync(ServiceAddress);

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        bool OnSaveCanExecute()
        {
            // TODO(crhodes)
            // Check if Customer is valid
            return true;
        }

        public ICommand AddServiceCallCommand { get; }

        void OnAddServiceCallExecute()
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            MessageBox.Show("AddServiceCall Stuff");

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        bool OnAddServiceCallCanExecute()
        {
            // TODO(crhodes)
            // Check if Customer is valid
            return true;
        }
    }
}
