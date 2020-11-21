using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

using CustomPoolAndSpa.Data;
using CustomPoolAndSpa.Domain;

using VNC.Core.DomainServices;

namespace CustomPoolAndSpa.DomainServices
{
    // TODO(crhodes)
    // Think we are almost to making this Generic.  But then what is difference 
    // between this and Generic Repository in VNC.Core.
    // Carefully trace through the code path.

    public class CustomerDataService : ICustomerDataService
    {
        private Func<CustomPoolAndSpaDbContext> _contextCreator;

        private ConnectedRepository<Customer> _repository;

        #region Constructors

        public CustomerDataService(Func<CustomPoolAndSpaDbContext> context)
        {
            _contextCreator = context;
        }

        #endregion Constructors

        #region Public Methods

        #region All

        public IEnumerable<Customer> All()
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Customer>(context);
                return _repository.All();
            }
        }

        public async Task<List<Customer>> AllAsync()
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Customer>(context);
                return await _repository.AllAsync();
            }
        }

        public IEnumerable<Customer> AllInclude(
            params Expression<Func<Customer, object>>[] includeProperties)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Customer>(context);
                return _repository.AllInclude(includeProperties);
            }
        }

        public async Task<IEnumerable<Customer>> AllIncludeAsync(
            params Expression<Func<Customer, object>>[] includeProperties)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Customer>(context);
                return await _repository.AllIncludeAsync(includeProperties);
            }
        }

        #endregion All

        #region Find

        public Customer FindById(int entityId)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Customer>(context);
                return _repository.FindById(entityId);
            }
        }

        public async Task<Customer> FindByIdAsync(int entityId)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Customer>(context);
                return await _repository.FindByIdAsync(entityId);
            }
        }

        public IEnumerable<Customer> FindBy(
            Expression<Func<Customer, bool>> predicate)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Customer>(context);
                return _repository.FindBy(predicate);
            }
        }

        public async Task<IEnumerable<Customer>> FindByAsync(
            Expression<Func<Customer, bool>> predicate)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Customer>(context);
                return await _repository.FindByAsync(predicate);
            }
        }

        public IEnumerable<Customer> FindByInclude(
            Expression<Func<Customer, bool>> predicate,
            params Expression<Func<Customer, object>>[] includeProperties)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Customer>(context);
               return _repository.FindByInclude(predicate, includeProperties);
            }
        }

        public async Task<IEnumerable<Customer>> FindByIncludeAsync(
            Expression<Func<Customer, bool>> predicate,
            params Expression<Func<Customer, object>>[] includeProperties)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Customer>(context);
                return await _repository.FindByIncludeAsync(predicate, includeProperties);
            }
        }

        // TODO(crhodes)
        // Decide if we need FindByKey

        #endregion Find

        #region Insert

        public void Insert(Customer entity)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Customer>(context);
                _repository.Insert(entity);
            }
        }

        public async Task InsertAsync(Customer entity)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Customer>(context);
                await _repository.InsertAsync(entity);
            }
        }

        #endregion Insert

        #region Update

        public void Update(Customer entity)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Customer>(context);
                _repository.Update(entity);
            }
        }

        public async Task UpdateAsync(Customer entity)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Customer>(context);
                await _repository.UpdateAsync(entity);
            }
        }

        #endregion Update

        #region Delete

        public void Delete(int entityId)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Customer>(context);
                _repository.Delete(entityId);
            }
        }

        public async Task DeleteAsync(int entityId)
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Customer>(context);
                await _repository.DeleteAsync(entityId);
            }
        }

        #endregion Delete

        #endregion

    }
}
