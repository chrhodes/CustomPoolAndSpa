using System;
using System.Windows;
using System.Windows.Controls;

using VNC;
using VNC.Core.Mvvm;

namespace CustomPoolAndSpa.Presentation.ServiceCall.Views
{
    public partial class ServiceCall : UserControl, IServiceCall
    {

        public ServiceCall(ViewModels.IServiceCallViewModel viewModel)
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            InitializeComponent();

            ViewModel = viewModel;
            Loaded += ServiceCall_Loaded;

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        private async void ServiceCall_Loaded(object sender, RoutedEventArgs e)
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            await ((ViewModels.IServiceCallViewModel)ViewModel).LoadAsync();

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
