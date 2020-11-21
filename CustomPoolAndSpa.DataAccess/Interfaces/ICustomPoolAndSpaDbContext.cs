
using System.Data.Entity;

using Common.Domain;

using CustomPoolAndSpa.Domain;

namespace CustomPoolAndSpa.Data
{
    public interface ICustomPoolAndSpaDbContext
    {
        int SaveChanges();

        DbSet<Address> AddressSet { get; set; }
        DbSet<Customer> CustomerSet { get; set; }
        DbSet<Material> MaterialSet { get; set; }
        DbSet<MaterialUsed> MaterialUsedSet { get; set; }
        DbSet<ServiceAddress> ServiceAddressSet { get; set; }
        DbSet<ServiceCall> ServiceCallSet { get; set; }
    }
}
