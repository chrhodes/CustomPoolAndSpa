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


namespace CustomPoolAndSpa.Presentation.ServiceCall.ViewModels
{
    class ServiceCallDetailViewModel : ViewModelBase, IServiceCallDetailViewModel
    {
        private IServiceCallDataService _dataService;
        private IEventAggregator _eventAggregator;

        public ServiceCallDetailViewModel(
                IServiceCallDataService dataService,
                IEventAggregator eventAggregator)
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            _dataService = dataService;
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<OpenServiceCallDetailViewEvent>()
                .Subscribe(OnOpenServiceCallDetailView);

            SaveCommand = new DelegateCommand(
                OnSaveExecute, OnSaveCanExecute);

            AddSomethingCommand = new DelegateCommand(
                OnAddSomethingExecute, OnAddSomethingCanExecute);

            AddLaborCommand = new DelegateCommand(
                OnAddLaborExecute, OnAddLaborCanExecute);

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        private async void OnOpenServiceCallDetailView(int typeId)
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            await LoadAsync(typeId);

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task LoadAsync(int id)
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            ServiceCall = await _dataService.FindByIdAsync(id);

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        private Domain.ServiceCall _serviceCall;

        public Domain.ServiceCall ServiceCall
        {
            get { return _serviceCall; }
            private set
            {
                _serviceCall = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }

        async void OnSaveExecute()
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            //var foo = new DomainServices.ServiceCallDataService(getdbcontext);
            //var foo = new DomainServices.ServiceAddressDataService(() => new Data.CustomPoolAndSpaDbContext());
            await _dataService.UpdateAsync(ServiceCall);
            //await foo.UpdateAsync(ServiceCall);

            //await _dataService.UpdateAsync(ServiceCall);

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        Data.CustomPoolAndSpaDbContext getdbcontext()
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            return new Data.CustomPoolAndSpaDbContext();
        }

        bool OnSaveCanExecute()
        {
            // TODO(crhodes)
            // Check if Customer is valid
            return true;
        }

        public ICommand AddSomethingCommand { get; }

        void OnAddSomethingExecute()
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            MessageBox.Show("AddServiceCall Stuff");

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        bool OnAddSomethingCanExecute()
        {
            // TODO(crhodes)
            // Check if Customer is valid
            return true;
        }

        public ICommand AddLaborCommand { get; }

        void OnAddLaborExecute()
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            MessageBox.Show("AddServiceCall Stuff");

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        bool OnAddLaborCanExecute()
        {
            // TODO(crhodes)
            // Check if Customer is valid
            return true;
        }
    }
}
