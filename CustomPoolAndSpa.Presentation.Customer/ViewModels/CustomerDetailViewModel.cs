using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

using CustomPoolAndSpa.Core.Events;
using CustomPoolAndSpa.DomainServices;
using CustomPoolAndSpa.Presentation.Customer.Wrapper;
using Prism.Commands;
using Prism.Events;

using VNC;
using VNC.Core.Mvvm;

namespace CustomPoolAndSpa.Presentation.Customer.ViewModels
{
    class CustomerDetailViewModel : ViewModelBase, ICustomerDetailViewModel
    {
        private CustomerValidationWrapper _Customer;
        private ICustomerDataService _dataService;
        private IEventAggregator _eventAggregator;

        public CustomerDetailViewModel(
                ICustomerDataService dataService,
                IEventAggregator eventAggregator)
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            _dataService = dataService;
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<OpenCustomerDetailViewEvent>()
                .Subscribe(OnOpenCustomerDetailView);

            SaveCommand = new DelegateCommand(
                OnSaveExecute, OnSaveCanExecute);

            AddServiceAddressCommand = new DelegateCommand(
                OnAddServiceAddressExecute, OnAddServiceAddressCanExecute);

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public ICommand AddServiceAddressCommand { get; }

        public CustomerValidationWrapper Customer
        {
            get { return _Customer; }
            private set
            {
                _Customer = value;
                OnPropertyChanged();
            }
        }

        //private Domain.Customer _Customer;

        //public Domain.Customer Customer
        //{
        //    get { return _Customer; }
        //    private set
        //    {
        //        _Customer = value;
        //        OnPropertyChanged();
        //    }
        //}

        public ICommand SaveCommand { get; }

        public async Task LoadAsync(int id)
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            var customer = await _dataService.FindByIdAsync(id);

            Customer = new CustomerValidationWrapper(customer);
            //Customer = await _dataService.FindByIdAsync(id);

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        bool OnAddServiceAddressCanExecute()
        {
            // TODO(crhodes)
            // Check if Customer is valid
            return true;
        }

        void OnAddServiceAddressExecute()
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            MessageBox.Show("AddServiceAddress Stuff");

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        private async void OnOpenCustomerDetailView(int typeId)
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            await LoadAsync(typeId);

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        bool OnSaveCanExecute()
        {
            // TODO(crhodes)
            // Check in addition if Customer has changes

            // Check if Customer is valid
            return Customer != null && !Customer.HasErrors;
            //return true;
        }

        async void OnSaveExecute()
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            await _dataService.UpdateAsync(Customer.Model);
            //await _dataService.UpdateAsync(Customer);

            // Tell the Customer that we have updated something
            _eventAggregator.GetEvent<AfterCustomerSavedEvent>()
                .Publish(new AfterCustomerSavedEventArgs
                {
                    Id = Customer.Id,
                    DisplayMember = $"{Customer.FirstName} {Customer.LastName}"
                });

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }
    }
}
