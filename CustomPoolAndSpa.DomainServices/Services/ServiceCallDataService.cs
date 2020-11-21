using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

using CustomPoolAndSpa.Data;
using CustomPoolAndSpa.Domain;

using VNC.Core.DomainServices;

namespace CustomPoolAndSpa.DomainServices
{
    public class ServiceCallDataService : IServiceCallDataService
    {
        private Func<CustomPoolAndSpaDbContext> _contextCreator;

        private ConnectedRepository<ServiceCall> _repository;

        #region Constructors

        public ServiceCallDataService(Func<CustomPoolAndSpaDbContext> context)
        {
            _contextCreator = context;
        }

        #endregion Constructors

        #region Public Methods

        #region All

        public IEnumerable<ServiceCall> All()
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<ServiceCall>(context);
                return _repository.All();
            }
        }

        public async Task<List<ServiceCall>> AllAsync()
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<ServiceCall>(context);
                return await _repository.AllAsync();
            }
        }

        public IEnumerable<ServiceCall> AllInclude(
            params Expression<Func<ServiceCall, object>>[] includeProperties)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<ServiceCall>(context);
                return _repository.AllInclude(includeProperties);
            }
        }

        public async Task<IEnumerable<ServiceCall>> AllIncludeAsync(
            params Expression<Func<ServiceCall, object>>[] includeProperties)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<ServiceCall>(context);
                return await _repository.AllIncludeAsync(includeProperties);
            }
        }

        #endregion All

        #region Find

        public ServiceCall FindById(int entityId)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<ServiceCall>(context);
                return _repository.FindById(entityId);
            }
        }

        public async Task<ServiceCall> FindByIdAsync(int entityId)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<ServiceCall>(context);
                return await _repository.FindByIdAsync(entityId);
            }
        }

        public IEnumerable<ServiceCall> FindBy(
            Expression<Func<ServiceCall, bool>> predicate)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<ServiceCall>(context);
                return _repository.FindBy(predicate);
            }
        }

        public async Task<IEnumerable<ServiceCall>> FindByAsync(
            Expression<Func<ServiceCall, bool>> predicate)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<ServiceCall>(context);
                return await _repository.FindByAsync(predicate);
            }
        }

        public IEnumerable<ServiceCall> FindByInclude(
            Expression<Func<ServiceCall, bool>> predicate,
            params Expression<Func<ServiceCall, object>>[] includeProperties)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<ServiceCall>(context);
                return _repository.FindByInclude(predicate, includeProperties);
            }
        }

        public async Task<IEnumerable<ServiceCall>> FindByIncludeAsync(
            Expression<Func<ServiceCall, bool>> predicate,
            params Expression<Func<ServiceCall, object>>[] includeProperties)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<ServiceCall>(context);
                return await _repository.FindByIncludeAsync(predicate, includeProperties);
            }
        }

        // TODO(crhodes)
        // Decide if we need FindByKey

        #endregion Find

        #region Insert

        public void Insert(ServiceCall entity)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<ServiceCall>(context);
                _repository.Insert(entity);
            }
        }

        public async Task InsertAsync(ServiceCall entity)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<ServiceCall>(context);
                await _repository.InsertAsync(entity);
            }
        }

        #endregion Insert

        #region Update

        public void Update(ServiceCall entity)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<ServiceCall>(context);
                _repository.Update(entity);
            }
        }

        public async Task UpdateAsync(ServiceCall entity)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<ServiceCall>(context);
                await _repository.UpdateAsync(entity);
            }
        }

        #endregion Update

        #region Delete

        public void Delete(int entityId)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<ServiceCall>(context);
                _repository.Delete(entityId);
            }
        }

        public async Task DeleteAsync(int entityId)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<ServiceCall>(context);
                await _repository.DeleteAsync(entityId);
            }
        }

        #endregion Delete

        #endregion
    }
}
