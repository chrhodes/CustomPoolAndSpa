﻿using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CustomPoolAndSpa.Domain;

using Prism.Mvvm;
using CustomPoolAndSpa.DomainServices;

namespace CustomPoolAndSpa.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        // ObservableCollection notifies databinding when collection changes
        // because it implements INotifyPropertyChanged

        //public ObservableCollection<Customer> Customers { get; set; }

        public ICustomerDataService _customerDataService { get; set; }

        public MainWindowViewModel(ICustomerDataService customerDataService)
        {
            //_customerDataService = customerDataService;

            //Customers = new ObservableCollection<Customer>();
        }

        #region This goes away with the new NavigationViewModel


        Customer _selectedCustomer;

        //public Customer SelectedCustomer
        //{
        //    get { return _selectedCustomer; }
        //    set
        //    {
        //        _selectedCustomer = value;
        //        // Notify databindings of change

        //        // Traditional approach is to pass string name of field - error prone!
        //        //OnPropertyChanged("SelectedFriend");

        //        // C#6 added nameof keyword
        //        //OnPropertyChanged(nameof(SelectedFriend));

        //        // Latest is to rely on compiler to pass in name of caller to invocation
        //        //OnPropertyChanged();
        //        SetProperty(ref _selectedCustomer, value);
        //    }
        //}

        #endregion

        #region Move to Navigation/Detail Views 

        //public MainWindowViewModel(INavigationViewModel navigationViewModel, 
        //                            IFriendDetailViewModel friendDetailViewModel)
        //{
        //    NavigationViewModel = navigationViewModel;
        //    FriendDetailViewModel = friendDetailViewModel;
        //}

        //public INavigationViewModel NavigationViewModel { get; }
        //public IFriendDetailViewModel FriendDetailViewModel { get; }

        #endregion

        #region Move to Async loading

        //public void Load()
        //{
        //    var customers = _customerDataService.All();
        //    Customers.Clear();

        //    foreach (var customer in customers)
        //    {
        //        Customers.Add(customer);
        //    }
        //}

        //public async Task LoadAsync()
        //{
        //    var customers = await _customerDataService.AllAsync();
        //    Customers.Clear();

        //    foreach (var friend in customers)
        //    {
        //        Customers.Add(friend);
        //    }
        //}

        #endregion

        //public async Task LoadAsync()
        //{
        //    await NavigationViewModel.LoadAsync();
        //}
    }
}
