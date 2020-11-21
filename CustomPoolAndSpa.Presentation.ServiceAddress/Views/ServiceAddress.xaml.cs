using System;
using System.Windows;
using System.Windows.Controls;

using VNC;
using VNC.Core.Mvvm;

namespace CustomPoolAndSpa.Presentation.ServiceAddress.Views
{
    public partial class ServiceAddress : UserControl, IServiceAddress
    {

        public ServiceAddress(ViewModels.IServiceAddressViewModel viewModel)
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            InitializeComponent();

            ViewModel = viewModel;
            Loaded += ServiceAddress_Loaded;

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        private async void ServiceAddress_Loaded(object sender, RoutedEventArgs e)
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            await ((ViewModels.IServiceAddressViewModel)ViewModel).LoadAsync();

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
