using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

using VNC;

namespace CustomPoolAndSpa.Presentation.Customer.ViewModels
{
    public class NavigationItemViewModel : BindableBase
    {
        string _displayMember;
 
        public NavigationItemViewModel(int id, string displayMember)
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            Id = id;
            DisplayMember = displayMember;

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public int Id { get; set; }

        
        public string DisplayMember
        {
            get { return _displayMember; }
            set
            {
                if (_displayMember == value)
                    return;
                _displayMember = value;
                RaisePropertyChanged();
            }
        }      
    }
}
