using System.Windows;

using VNC;

namespace CustomPoolAndSpa.Views
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            long startTicks = Log.Debug("Enter", Common.LOG_APPNAME);

            InitializeComponent();

            Log.Debug("Exit", Common.LOG_APPNAME, startTicks);
        }
    }
}
