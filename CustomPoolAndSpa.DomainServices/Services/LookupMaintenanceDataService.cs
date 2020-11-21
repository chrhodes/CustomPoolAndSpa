using System.Threading.Tasks;
using CustomPoolAndSpa.Domain.Lookups;

namespace CustomPoolAndSpa.DomainServices.Services
{
    public class LookupMaintenanceDataService : ILookupMaintenanceDataService
    {
        public Task<LookupMaintenance> FindByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
