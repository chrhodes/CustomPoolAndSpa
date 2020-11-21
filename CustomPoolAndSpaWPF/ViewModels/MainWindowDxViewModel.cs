using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Common.Domain;

using CustomPoolAndSpa.Domain;
using CustomPoolAndSpa.DomainServices;

using Prism.Mvvm;

using VNC;

namespace CustomPoolAndSpa.ViewModels
{
    public class MainWindowDxViewModel : BindableBase
    {
        // ObservableCollection notifies databinding when collection changes
        // because it implements INotifyCollectionChanged

        public ObservableCollection<Address> Addresses { get; set; }

        public ObservableCollection<Material> Materials { get; set; }

        public IAddressDataService _addressDataService { get; set; }

        public IMaterialDataService _materialDataService { get; set; }

        public MainWindowDxViewModel(
                    IAddressDataService addressDataService,
                    IMaterialDataService materialDataService)
        {
            long startTicks = Log.Debug("Enter", Common.LOG_APPNAME);

            _addressDataService = addressDataService;
            _materialDataService = materialDataService;

            Addresses = new ObservableCollection<Address>();
            Materials = new ObservableCollection<Material>();
        }

        #region This goes away with the new NavigationViewModel


        Address _selectedAddress;

        public Address SelectedAddress
        {
            get { return _selectedAddress; }
            set
            {
                _selectedAddress = value;

                RaisePropertyChanged();
                // TODO(crhodes)
                // Learn what SetProperty does
                //SetProperty(ref _selectedCustomer, value);
            }
        }

        Material _selectedMaterial;

        public Material SelectedMaterial
        {
            get { return _selectedMaterial; }
            set
            {
                _selectedMaterial = value;

                RaisePropertyChanged();
                SetProperty(ref _selectedMaterial, value);
            }
        }

        #endregion

        #region Move to Async loading

        public void Load()
        {
            long startTicks = Log.Debug("Enter", Common.LOG_APPNAME);

            LoadAddresses();
            LoadMaterials();
        }

        public async Task LoadAsync()
        {
            long startTicks = Log.Debug("Enter", Common.LOG_APPNAME);

            await LoadAddressesAsync();
            await LoadMaterialsAsync();

            Log.Debug("Exit", Common.LOG_APPNAME, startTicks);
        }

        private void LoadAddresses()
        {
            long startTicks = Log.Debug("Enter", Common.LOG_APPNAME);

            var addresses = _addressDataService.All();

            Addresses.Clear();

            foreach (var address in addresses)
            {
                Addresses.Add(address);
            }

            Log.Debug("Exit", Common.LOG_APPNAME, startTicks);
        }

        public async Task LoadAddressesAsync()
        {
            long startTicks = Log.Debug("Enter", Common.LOG_APPNAME);

            var addresses = await _addressDataService.AllAsync();

            Addresses.Clear();

            foreach (var address in addresses)
            {
                Addresses.Add(address);
            }

            Log.Debug("Exit", Common.LOG_APPNAME, startTicks);
        }

        private void LoadMaterials()
        {
            long startTicks = Log.Debug("Enter", Common.LOG_APPNAME);

            var materials = _materialDataService.All();

            Materials.Clear();

            foreach (var material in materials)
            {
                Materials.Add(material);
            }

            Log.Debug("Exit", Common.LOG_APPNAME, startTicks);
        }

        public async Task LoadMaterialsAsync()
        {
            long startTicks = Log.Debug("Enter", Common.LOG_APPNAME);

            var materials = await _materialDataService.AllAsync();

            Materials.Clear();

            foreach (var material in materials)
            {
                Materials.Add(material);
            }

            Log.Debug("Exit", Common.LOG_APPNAME, startTicks);
        }

        #endregion

    }
}
