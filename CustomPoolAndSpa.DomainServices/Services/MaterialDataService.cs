using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using CustomPoolAndSpa.Data;
using CustomPoolAndSpa.Domain;
using VNC.Core.DomainServices;

namespace CustomPoolAndSpa.DomainServices
{
    public class MaterialDataService : IMaterialDataService
    {
        private Func<CustomPoolAndSpaDbContext> _contextCreator;

        private ConnectedRepository<Material> _repository;

        public MaterialDataService(Func<CustomPoolAndSpaDbContext> context)
        {
            _contextCreator = context;
        }

        public IEnumerable<Material> All()
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Material>(context);
                return _repository.All();
            }
        }

        public async Task<List<Material>> AllAsync()
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Material>(context);
                return await _repository.AllAsync();
            }
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
