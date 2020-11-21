using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace CustomPoolAndSpa.Presentation.ServiceAddress.ViewModels
{
    public interface IServiceAddressViewModel : IViewModel
    {
        Task LoadAsync();
    }
}
