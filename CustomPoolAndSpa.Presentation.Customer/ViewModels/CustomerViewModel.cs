using System.Collections.ObjectModel;
using System.Threading.Tasks;

using CustomPoolAndSpa.Core.Events;
using CustomPoolAndSpa.DomainServices;

using Prism.Events;
using System;
using VNC.Core.DomainServices;
using VNC.Core.Mvvm;
using System.Linq;
using VNC;

namespace CustomPoolAndSpa.Presentation.Customer.ViewModels
{
    public class CustomerViewModel : ViewModelBase, ICustomerViewModel
    {
        private ICustomersLookupDataService _CustomerLookupDataService;
        private IEventAggregator _eventAggregator;

        public CustomerViewModel(
                    ICustomersLookupDataService CustomersLookupDataService,
                    IEventAggregator eventAggregator)
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            _CustomerLookupDataService = CustomersLookupDataService;
            _eventAggregator = eventAggregator;
            //Customers = new ObservableCollection<LookupItem>();
            Customers = new ObservableCollection<NavigationItemViewModel>();
            _eventAggregator.GetEvent<AfterCustomerSavedEvent>().Subscribe(AfterCustomerSaved);

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task LoadAsync()
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            var lookup = await _CustomerLookupDataService.GetCustomersLookupAsync();
            Customers.Clear();

            foreach (var item in lookup)
            {
                //Customers.Add(item);
                Customers.Add(new NavigationItemViewModel(item.Id, item.DisplayMember));
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        void AfterCustomerSaved(AfterCustomerSavedEventArgs customerArgs)
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            var lookupItem = Customers.Single(l => l.Id == customerArgs.Id);
            lookupItem.DisplayMember = customerArgs.DisplayMember;

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public IView View
        {
            get;
            set;
        }

        //public ObservableCollection<LookupItem> Customers { get; }
        public ObservableCollection<NavigationItemViewModel> Customers { get; }

        NavigationItemViewModel _selectedCustomer;

        public NavigationItemViewModel SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged();

                if (_selectedCustomer != null)
                {
                    _eventAggregator.GetEvent<OpenCustomerDetailViewEvent>()
                        .Publish(_selectedCustomer.Id);
                }
            }
        }
        //LookupItem _selectedCustomer;

        //public LookupItem SelectedCustomer
        //{
        //    get { return _selectedCustomer; }
        //    set
        //    {
        //        _selectedCustomer = value;
        //        OnPropertyChanged();

        //        if (_selectedCustomer != null)
        //        {
        //            _eventAggregator.GetEvent<OpenCustomerDetailViewEvent>()
        //                .Publish(_selectedCustomer.Id);
        //        }
        //    }
        //}

    }
}
