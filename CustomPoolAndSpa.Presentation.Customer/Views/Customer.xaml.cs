using System;
using System.Windows;
using System.Windows.Controls;

using VNC;
using VNC.Core.Mvvm;

namespace CustomPoolAndSpa.Presentation.Customer.Views
{
    public partial class Customer : UserControl, ICustomer
    {

        public Customer(ViewModels.ICustomerViewModel viewModel)
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            InitializeComponent();

            ViewModel = viewModel;
            Loaded += Customer_Loaded;

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        private async void Customer_Loaded(object sender, RoutedEventArgs e)
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            await ((ViewModels.ICustomerViewModel)ViewModel).LoadAsync();

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
