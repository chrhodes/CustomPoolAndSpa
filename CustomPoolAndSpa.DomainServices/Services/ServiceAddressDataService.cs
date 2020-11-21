using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

using CustomPoolAndSpa.Data;
using CustomPoolAndSpa.Domain;

using VNC.Core.DomainServices;

namespace CustomPoolAndSpa.DomainServices
{
    public class ServiceAddressDataService : IServiceAddressDataService
    {
        private Func<CustomPoolAndSpaDbContext> _contextCreator;

        private ConnectedRepository<ServiceAddress> _repository;

        #region Constructors

        public ServiceAddressDataService(Func<CustomPoolAndSpaDbContext> context)
        {
            _contextCreator = context;
        }

        #endregion Constructors

        #region Public Methods

        #region All

        public IEnumerable<ServiceAddress> All()
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<ServiceAddress>(context);
                return _repository.All();
            }
        }

        public async Task<List<ServiceAddress>> AllAsync()
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<ServiceAddress>(context);
                return await _repository.AllAsync();
            }
        }

        public IEnumerable<ServiceAddress> AllInclude(
            params Expression<Func<ServiceAddress, object>>[] includeProperties)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<ServiceAddress>(context);
                return _repository.AllInclude(includeProperties);
            }
        }

        public async Task<IEnumerable<ServiceAddress>> AllIncludeAsync(
            params Expression<Func<ServiceAddress, object>>[] includeProperties)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<ServiceAddress>(context);
                return await _repository.AllIncludeAsync(includeProperties);
            }
        }

        #endregion All

        #region Find

        public ServiceAddress FindById(int entityId)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<ServiceAddress>(context);
                return _repository.FindById(entityId);
            }
        }

        public async Task<ServiceAddress> FindByIdAsync(int entityId)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<ServiceAddress>(context);
                return await _repository.FindByIdAsync(entityId);
            }
        }

        public IEnumerable<ServiceAddress> FindBy(
            Expression<Func<ServiceAddress, bool>> predicate)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<ServiceAddress>(context);
                return _repository.FindBy(predicate);
            }
        }

        public async Task<IEnumerable<ServiceAddress>> FindByAsync(
            Expression<Func<ServiceAddress, bool>> predicate)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<ServiceAddress>(context);
                return await _repository.FindByAsync(predicate);
            }
        }

        public IEnumerable<ServiceAddress> FindByInclude(
            Expression<Func<ServiceAddress, bool>> predicate,
            params Expression<Func<ServiceAddress, object>>[] includeProperties)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<ServiceAddress>(context);
                return _repository.FindByInclude(predicate, includeProperties);
            }
        }

        public async Task<IEnumerable<ServiceAddress>> FindByIncludeAsync(
            Expression<Func<ServiceAddress, bool>> predicate,
            params Expression<Func<ServiceAddress, object>>[] includeProperties)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<ServiceAddress>(context);
                return await _repository.FindByIncludeAsync(predicate, includeProperties);
            }
        }

        // TODO(crhodes)
        // Decide if we need FindByKey

        #endregion Find

        #region Insert

        public void Insert(ServiceAddress entity)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<ServiceAddress>(context);
                _repository.Insert(entity);
            }
        }

        public async Task InsertAsync(ServiceAddress entity)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<ServiceAddress>(context);
                await _repository.InsertAsync(entity);
            }
        }

        #endregion Insert

        #region Update

        public void Update(ServiceAddress entity)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<ServiceAddress>(context);
                _repository.Update(entity);
            }
        }

        public async Task UpdateAsync(ServiceAddress entity)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<ServiceAddress>(context);
                await _repository.UpdateAsync(entity);
            }
        }

        #endregion Update

        #region Delete

        public void Delete(int entityId)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<ServiceAddress>(context);
                _repository.Delete(entityId);
            }
        }

        public async Task DeleteAsync(int entityId)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<ServiceAddress>(context);
                await _repository.DeleteAsync(entityId);
            }
        }

        #endregion Delete

        #endregion
    }
}
