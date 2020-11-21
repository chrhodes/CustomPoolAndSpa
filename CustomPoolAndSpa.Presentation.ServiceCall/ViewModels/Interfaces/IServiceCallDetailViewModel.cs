using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace CustomPoolAndSpa.Presentation.ServiceCall.ViewModels
{
    public interface IServiceCallDetailViewModel : IViewModel
    {
        Task LoadAsync(int id);
    }
}
