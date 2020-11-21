using System;
using System.Threading.Tasks;

using CustomPoolAndSpa.Core.Events;
using CustomPoolAndSpa.DomainServices;

using Prism.Events;

using VNC;
using VNC.Core.Mvvm;


namespace CustomPoolAndSpa.Presentation.LookupMaintenance.ViewModels
{
    class LookupMaintenanceDetailViewModel : ViewModelBase, ILookupMaintenanceDetailViewModel
    {
        private ILookupMaintenanceDataService _dataService;
        private IEventAggregator _eventAggregator;

        public LookupMaintenanceDetailViewModel(
                ILookupMaintenanceDataService dataService,
                IEventAggregator eventAggregator)
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            _dataService = dataService;
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<OpenLookupMaintenanceDetailViewEvent>();

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        private async void OnOpenLookupMaintenanceDetailView(int typeId)
        {

            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            await LoadAsync(typeId);

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        public async Task LoadAsync(int id)
        {
            long startTicks = Log.Trace(String.Format("Enter"), Common.LOG_APPNAME);

            LookupMaintenance = await _dataService.FindByIdAsync(id);

            Log.Trace(String.Format("Exit"), Common.LOG_APPNAME, startTicks);
        }

        private Domain.Lookups.LookupMaintenance _lookupMaintenance;

        public Domain.Lookups.LookupMaintenance LookupMaintenance
        {
            get { return _lookupMaintenance; }
            private set
            {
                _lookupMaintenance = value;
                OnPropertyChanged();
            }
        }
    }
}
