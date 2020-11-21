using System.Collections.Generic;

namespace CustomPoolAndSpa.Application.Customers.Queries.GetCustomerList
{
    public interface IGetCustomersListQuery
    {
        List<CustomerModel> Execute();
        //List<Customer> Execute();
    }
}
