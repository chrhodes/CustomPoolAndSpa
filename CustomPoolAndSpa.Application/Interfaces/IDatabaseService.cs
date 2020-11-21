using System.Data.Entity;

using Common.Domain;

using CustomPoolAndSpa.Domain;

namespace CustomPoolAndSpa.Application.Interfaces
{
    public interface IDatabaseService
    {
        IDbSet<Customer> Customers { get; set; }

        IDbSet<Address> Addresses { get; set; }

        void Save();
    }
}
