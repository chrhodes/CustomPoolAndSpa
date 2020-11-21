using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace CustomPoolAndSpa.Presentation.LookupMaintenance.ViewModels
{
    public interface ILookupMaintenanceViewModel : IViewModel
    {
        Task LoadAsync();
    }
}
