using System.Data.Entity;

namespace CustomPoolAndSpa.Application.Interfaces
{
    public interface ILookupService<TEntity> where TEntity : class
    {
        IDbSet<TEntity> Items { get; set; }

        void Save();
    }
}
