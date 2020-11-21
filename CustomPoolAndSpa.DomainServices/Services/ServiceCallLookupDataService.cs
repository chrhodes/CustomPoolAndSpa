using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using CustomPoolAndSpa.Data;

using VNC.Core.DomainServices;

namespace CustomPoolAndSpa.DomainServices
{
    public class ServiceCallLookupDataService : IServiceCallLookupDataService
    {
        private Func<CustomPoolAndSpaDbContext> _contextCreator;

        public ServiceCallLookupDataService(Func<CustomPoolAndSpaDbContext> context)
        {
            _contextCreator = context;
        }

        public async Task<IEnumerable<LookupItem>> GetServiceCallLookupAsync()
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.ServiceCallSet.AsNoTracking()
                  .Select(f =>
                  new LookupItem
                  {
                      Id = f.Id,
                      DisplayMember = f.ServiceAddress.Address.Address1
                  })
                  .ToListAsync();
            }
        }
    }
}
