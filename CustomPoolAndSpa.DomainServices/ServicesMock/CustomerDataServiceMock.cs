
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CustomPoolAndSpa.Domain;
using VNC.Core.DomainServices;

namespace CustomPoolAndSpa.DomainServices
{
    public class CustomerDataServiceMock : ICustomerDataService
    {
        public IEnumerable<Customer> All()
        {
            //// TODO(crhodes)
            //// Load data from real database.
            //// For now just return hard coded list.
            ///
            yield return new Customer
            {
                Id = 1,
                FirstName = "Vikki",
                CellPhone = "714-287-5719",
                HomePhone = "Home Phone",
                MainPhone = "Main Phone",
                WorkPhone = "Work Phone"
            };
            yield return new Customer { Id = 2, FirstName = "Natalie Rhodes" };
            yield return new Customer { Id = 3, FirstName = "Christopher Rhodes" };
            yield return new Customer { Id = 4, FirstName = "Paul Schanz" };
            yield return new Customer { Id = 5, FirstName = "George Lachow" };
            yield return new Customer { Id = 6, FirstName = "Tim Lachow" };
            yield return new Customer { Id = 7, FirstName = "Diane ??" };
        }

        public Task<List<Customer>> AllAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> AllInclude(params Expression<Func<Customer, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> AllIncludeAsync(params Expression<Func<Customer, object>>[] includeProperties)
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

        public IEnumerable<Customer> FindBy(Expression<Func<Customer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> FindByAsync(Expression<Func<Customer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Customer FindById(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> FindByIdAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> FindByInclude(Expression<Func<Customer, bool>> predicate, params Expression<Func<Customer, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> FindByIncludeAsync(Expression<Func<Customer, bool>> predicate, params Expression<Func<Customer, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void Insert(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> InsertAsync(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> UpdateAsync(Customer entity)
        {
            throw new NotImplementedException();
        }

        Task IDataService<Customer>.DeleteAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        Task IDataService<Customer>.InsertAsync(Customer entity)
        {
            throw new NotImplementedException();
        }

        Task IDataService<Customer>.UpdateAsync(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
