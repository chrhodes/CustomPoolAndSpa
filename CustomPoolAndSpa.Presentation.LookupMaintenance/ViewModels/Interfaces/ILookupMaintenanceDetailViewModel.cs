using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace CustomPoolAndSpa.Presentation.LookupMaintenance.ViewModels
{
    public interface ILookupMaintenanceDetailViewModel : IViewModel
    {
        Task LoadAsync(int id);
    }
}
