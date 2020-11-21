using System;
using System.Windows;
using System.Windows.Controls;

using VNC;
using VNC.Core.Mvvm;

namespace CustomPoolAndSpa.Presentation.LookupMaintenance.Views
{
    public partial class LookupMaintenance : UserControl, ILookupMaintenance
    {

        public LookupMaintenance(ViewModels.ILookupMaintenanceViewModel viewModel)
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            InitializeComponent();

            ViewModel = viewModel;
            Loaded += LookupMaintenance_Loaded;

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        private async void LookupMaintenance_Loaded(object sender, RoutedEventArgs e)
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            await ((ViewModels.ILookupMaintenanceViewModel)ViewModel).LoadAsync();

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
