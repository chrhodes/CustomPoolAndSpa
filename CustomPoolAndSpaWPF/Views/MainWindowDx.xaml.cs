using CustomPoolAndSpa.ViewModels;
using System.Windows;

using VNC;

namespace CustomPoolAndSpa.Views
{
    public partial class MainWindowDx : Window
    {
        public MainWindowDxViewModel _viewModel;

        public MainWindowDx(MainWindowDxViewModel viewModel)
        {
            long startTicks = Log.Debug("Enter", Common.LOG_APPNAME);

            InitializeComponent();

            _viewModel = viewModel;
            DataContext = _viewModel;

            Loaded += MainWindowDx_Loaded;

            Log.Debug("Exit", Common.LOG_APPNAME, startTicks);
        }

        // Load ViewModel asynchronously

        private async void MainWindowDx_Loaded(object sender, RoutedEventArgs e)
        {
            long startTicks = Log.Debug("Enter", Common.LOG_APPNAME);

            //_viewModel.Load();
            await _viewModel.LoadAsync();

            Log.Debug("Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}
