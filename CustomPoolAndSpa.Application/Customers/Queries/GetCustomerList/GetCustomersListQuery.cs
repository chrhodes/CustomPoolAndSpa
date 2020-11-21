using System.Collections.Generic;
using System.Linq;

using CustomPoolAndSpa.Application.Interfaces;

namespace CustomPoolAndSpa.Application.Customers.Queries.GetCustomerList
{
    public class GetCustomersListQuery : IGetCustomersListQuery
    {
        private readonly IDatabaseService _database;

        public GetCustomersListQuery(IDatabaseService database)
        {
            _database = database;
        }

        public List<CustomerModel> Execute()
        //public List<Customer> Execute()
        {
            //using (var context = new CustomPoolAndSpaDbContext())
            //{
            //    return context.CustomerSet.AsNoTracking()
            //        .OrderBy(c => c.Name)
            //        .ToList();
            //}

            //var customers = _database.Customers.ToList();
            //return customers;

            var customers = _database.Customers
                .Select(p => new CustomerModel()
                {
                    Id = p.Id,
                    Name = p.FirstName
                });

            return customers.ToList();
        }
    }
}
