using System.Threading.Tasks;

using VNC.Core.Mvvm;

namespace CustomPoolAndSpa.Presentation.Customer.ViewModels
{
    public interface ICustomerViewModel : IViewModel
    {
        Task LoadAsync();
    }
}
