using System;
using System.Windows.Controls;

using VNC;
using VNC.Core.Mvvm;

namespace CustomPoolAndSpa.Presentation.Customer.Views
{
    public partial class CustomerDetail : UserControl, ICustomerDetail
    {
        public CustomerDetail(ViewModels.ICustomerDetailViewModel viewModel)
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
