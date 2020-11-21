using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CustomPoolAndSpa.Domain;
using VNC.Core.DomainServices;

namespace CustomPoolAndSpa.DomainServices
{
    public class MaterialDataServiceMock : IMaterialDataService
    {
        public IEnumerable<Material> All()
        {
            //// TODO(crhodes)
            //// Load data from real database.
            //// For now just return hard coded list.

            yield return new Material { Id = 1, ItemName = "MaterialA", Description = "Material A Description"};
            yield return new Material { Id = 2, ItemName = "MaterialB", Description = "Material B Description" };
            yield return new Material { Id = 3, ItemName = "MaterialC", Description = "Material C Description" };
            yield return new Material { Id = 4, ItemName = "MaterialD", Description = "Material D Description" };
        }

        public Task<List<Material>> AllAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Material> AllInclude(params Expression<Func<Material, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Material>> AllIncludeAsync(params Expression<Func<Material, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Material> FindBy(Expression<Func<Material, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Material>> FindByAsync(Expression<Func<Material, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Material FindById(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Material> FindByIdAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Material> FindByInclude(Expression<Func<Material, bool>> predicate, params Expression<Func<Material, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Material>> FindByIncludeAsync(Expression<Func<Material, bool>> predicate, params Expression<Func<Material, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void Insert(Material entity)
        {
            throw new NotImplementedException();
        }

        public Task<Material> InsertAsync(Material entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Material entity)
        {
            throw new NotImplementedException();
        }

        public Task<Material> UpdateAsync(Material entity)
        {
            throw new NotImplementedException();
        }

        Task IDataService<Material>.DeleteAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        Task IDataService<Material>.InsertAsync(Material entity)
        {
            throw new NotImplementedException();
        }

        Task IDataService<Material>.UpdateAsync(Material entity)
        {
            throw new NotImplementedException();
        }
    }
}
