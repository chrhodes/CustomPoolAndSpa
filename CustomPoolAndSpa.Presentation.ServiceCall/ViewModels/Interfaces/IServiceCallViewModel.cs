using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace CustomPoolAndSpa.Presentation.ServiceCall.ViewModels
{
    public interface IServiceCallViewModel : IViewModel
    {
        Task LoadAsync();
    }
}
