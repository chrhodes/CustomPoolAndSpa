using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using CustomPoolAndSpa.Data;

using VNC.Core.DomainServices;

namespace CustomPoolAndSpa.DomainServices
{
    public class ServiceAddressLookupDataService : IServiceAddressLookupDataService
    {
        private Func<CustomPoolAndSpaDbContext> _contextCreator;

        public ServiceAddressLookupDataService(Func<CustomPoolAndSpaDbContext> context)
        {
            _contextCreator = context;
        }

        public async Task<IEnumerable<LookupItem>> GetServiceAddressLookupAsync()
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.ServiceAddressSet.AsNoTracking()
                  .Select(f =>
                  new LookupItem
                  {
                      Id = f.Id,
                      DisplayMember = f.Address.Address1
                  })
                  .ToListAsync();
            }
        }
    }
}
