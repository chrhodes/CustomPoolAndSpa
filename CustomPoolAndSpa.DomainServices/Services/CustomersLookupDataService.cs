using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using CustomPoolAndSpa.Data;
using CustomPoolAndSpa.Domain;

using VNC.Core.DomainServices;

namespace CustomPoolAndSpa.DomainServices
{
    public class CustomersLookupDataService : ICustomersLookupDataService
    {
        private Func<CustomPoolAndSpaDbContext> _contextCreator;

        public CustomersLookupDataService(Func<CustomPoolAndSpaDbContext> context)
        {
            _contextCreator = context;
        }

        public async Task<IEnumerable<LookupItem>> GetCustomersLookupAsync()
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.CustomerSet.AsNoTracking()
                  .Select(f =>
                  new LookupItem
                  {
                      Id = f.Id,
                      // Cannot invoke a member here??
                      //DisplayMember = f.FullName()
                      //'The specified type member 'DisplayName' is not supported in LINQ to Entities.
                      // Only initializers, entity members, and entity navigation properties are supported.'
                      //DisplayMember = f.DisplayName
                      // So I guess we are back to this
                      DisplayMember = String.IsNullOrEmpty(f.CompanyName) ? f.FirstName + " " + f.LastName : f.CompanyName

                      //DisplayMember = f.FirstName + " " + f.LastName
                      //DisplayMember = GetFullName(f.FirstName, f.LastName, f.CompanyName)
                  })
                  .ToListAsync();
            }
        }

        public string GetFullName(string firstName, string lastName, string companyName)
        {
            string fullName = "";

            return string.Format("{0}{1}{2}", firstName, lastName, companyName);
        }
    }
}
