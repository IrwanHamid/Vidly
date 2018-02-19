using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Detail(int id)
        {
            var customer = _context.Customers
                                    .Include(c => c.MembershipType)
                                    .SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.Single(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerFormViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                // Repopulate MembershipTypes as the form only send 
                // back the selected MembershipType Id
                viewModel.MembershipTypes = _context.MembershipTypes.ToList();

                return View("CustomerForm", viewModel);
            }


            if (viewModel.Customer.Id == 0)
            {
                //Adding a new customer object into the DbContext
                _context.Customers.Add(viewModel.Customer);
            }
            else
            {
                //find the customer in database using the customer id
                var customerInDb = _context.Customers.Single(c => c.Id == viewModel.Customer.Id);

                customerInDb.Name = viewModel.Customer.Name;
                customerInDb.Birthdate = viewModel.Customer.Birthdate;
                customerInDb.IsSubscribedToNewsletter = viewModel.Customer.IsSubscribedToNewsletter;
                customerInDb.MembershipTypeId = viewModel.Customer.MembershipTypeId;

                //Other option: 1. TryUpdateModel
                //Other Option: 2. AutoMapper library with DTO
            }

            //Save the changes of DbContext to the database
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

    }
}