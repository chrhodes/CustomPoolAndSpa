using System.Web.Mvc;
using CustomPoolAndSpa.Application.Customers.Queries.GetCustomerList;

namespace CustomPoolAndSpaMVC.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IGetCustomersListQuery _query;

        public CustomersController(IGetCustomersListQuery query)
        {
            _query = query;
        }

        public ViewResult Index()
        {
            var customers = _query.Execute();

            return View(customers);
        }
    }
}