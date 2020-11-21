using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using CustomPoolAndSpa.Core.Events;
using CustomPoolAndSpa.DomainServices;
using CustomPoolAndSpa.DomainServices.Services;
using Prism.Events;

using VNC;
using VNC.Core.DomainServices;
using VNC.Core.Mvvm;

namespace CustomPoolAndSpa.Presentation.LookupMaintenance.ViewModels
{
    public class LookupMaintenanceViewModel : ViewModelBase, ILookupMaintenanceViewModel, IViewModel
    {
        private ILookupMaintenanceLookupDataService _LookupMaintenanceLookupDataService;
        private IEventAggregator _eventAggregator;

        public LookupMaintenanceViewModel(
                ILookupMaintenanceLookupDataService lookupMaintenanceLookupDataService,
                IEventAggregator eventAggregator)
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            _LookupMaintenanceLookupDataService = lookupMaintenanceLookupDataService;
            _eventAggregator = eventAggregator;
            LookupMaintenances = new ObservableCollection<LookupItem>();

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task LoadAsync()
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            var lookup = await _LookupMaintenanceLookupDataService.GetLookupMaintenanceLookupAsync();
            LookupMaintenances.Clear();

            foreach (var item in lookup)
            {
                LookupMaintenances.Add(item);
            }

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public ObservableCollection<LookupItem> LookupMaintenances { get; }

        public IView View
        {
            get;
            set;
        }

        LookupItem _selectedLookupMaintenance;

        public LookupItem SelectedLookupMaintenance
        {
            get { return _selectedLookupMaintenance; }
            set
            {
                _selectedLookupMaintenance = value;
                OnPropertyChanged();

                if (_selectedLookupMaintenance != null)
                {
                    _eventAggregator.GetEvent<OpenLookupMaintenanceDetailViewEvent>()
                        .Publish(_selectedLookupMaintenance.Id);
                }
            }
        }
    }
}
