using System.Collections.Generic;
using System.Threading.Tasks;
using VNC.Core.DomainServices;

namespace CustomPoolAndSpa.DomainServices.Services
{
    public class LookupMaintenanceLookupDataService : ILookupMaintenanceLookupDataService
    {
        public Task<IEnumerable<LookupItem>> GetLookupMaintenanceLookupAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
