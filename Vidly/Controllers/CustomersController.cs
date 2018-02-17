using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private List<Customer> _customers;

        public CustomersController()
        {
            _customers = new List<Customer>
            {
                new Customer { Id=1, Name="John Smith" },
                new Customer { Id=2, Name="Marry William" }
            };

        }
        
        public ActionResult Index()
        {
            return View(_customers);
        }

        public ActionResult Detail(int id)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }
    }
}