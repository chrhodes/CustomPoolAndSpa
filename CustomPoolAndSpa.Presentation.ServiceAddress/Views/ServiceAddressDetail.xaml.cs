using System;
using System.Windows.Controls;

using VNC;
using VNC.Core.Mvvm;

namespace CustomPoolAndSpa.Presentation.ServiceAddress.Views
{
    public partial class ServiceAddressDetail : UserControl, IServiceAddressDetail
    {
        public ServiceAddressDetail(ViewModels.IServiceAddressDetailViewModel viewModel)
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            InitializeComponent();
            ViewModel = viewModel;

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public IViewModel ViewModel
        {
            get { return (IViewModel)DataContext; }
            set { DataContext = value; }
        }
    }
}
