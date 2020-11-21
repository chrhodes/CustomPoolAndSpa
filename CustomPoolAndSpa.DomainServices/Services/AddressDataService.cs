using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Common.Domain;

using CustomPoolAndSpa.Data;
using VNC.Core.DomainServices;

namespace CustomPoolAndSpa.DomainServices
{
    public class AddressDataService : IAddressDataService // IDataService<Address>
    {
        private Func<CustomPoolAndSpaDbContext> _contextCreator;

        private ConnectedRepository<Address> _repository;

        public AddressDataService(Func<CustomPoolAndSpaDbContext> context)
        {
            _contextCreator = context;
        }

        public IEnumerable<Address> All()
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Address>(context);
                return _repository.All();
            }
        }

        public async Task<List<Address>> AllAsync()
        {
            using (var context = _contextCreator())
            {
                _repository = new ConnectedRepository<Address>(context);
                return await _repository.AllAsync();
            }
        }

        public IEnumerable<Address> AllInclude(params Expression<Func<Address, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Address>> AllIncludeAsync(params Expression<Func<Address, object>>[] includeProperties)
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

        public IEnumerable<Address> FindBy(Expression<Func<Address, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Address>> FindByAsync(Expression<Func<Address, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Address FindById(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Address> FindByIdAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Address> FindByInclude(Expression<Func<Address, bool>> predicate, params Expression<Func<Address, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Address>> FindByIncludeAsync(Expression<Func<Address, bool>> predicate, params Expression<Func<Address, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void Insert(Address entity)
        {
            throw new NotImplementedException();
        }

        public Task<Address> InsertAsync(Address entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Address entity)
        {
            throw new NotImplementedException();
        }

        public Task<Address> UpdateAsync(Address entity)
        {
            throw new NotImplementedException();
        }

        Task IDataService<Address>.DeleteAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        Task IDataService<Address>.InsertAsync(Address entity)
        {
            throw new NotImplementedException();
        }

        Task IDataService<Address>.UpdateAsync(Address entity)
        {
            throw new NotImplementedException();
        }
    }
}
