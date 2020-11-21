using System.Threading.Tasks;
using CustomPoolAndSpa.Domain.Lookups;

namespace CustomPoolAndSpa.DomainServices
{
    public interface ILookupMaintenanceDataService
    {
        Task<LookupMaintenance> FindByIdAsync(int id);
    }
}