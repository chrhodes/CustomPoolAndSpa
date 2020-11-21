using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace CustomPoolAndSpa.Presentation.ServiceAddress.ViewModels
{
    public interface IServiceAddressDetailViewModel : IViewModel
    {
        Task LoadAsync(int id);
    }
}
