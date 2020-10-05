using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCDay1.Models;
using System.Data.Entity;
using MVCDay1.ViewModel;
using System.Web.UI.WebControls;

namespace MVCDay1.Controllers
{
    [HandleError]
    public class CustomerController : Controller
    {
        private ApplicationDbContext dbContext=null;
        // GET: Customer
        public CustomerController()
        {
            dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
        public List<Customer>GetCustomers()
        {
            return dbContext.customers.ToList();
        }
        //[AllowAnonymous]
        public ActionResult Index()
        {
            // List<Customer> customers = GetCustomers();
            var customers = dbContext.customers.ToList();
            return View(customers);
        }
        //[Authorize(Users ="yasaswini@gmail.com")]
        
        [HttpGet]
        //[HandleError(ExceptionType =typeof(ArgumentNullException),View ="ArgumentNull")]
        public ActionResult Create()
        {
            //ViewBag.GenreId = GetGenderNames();
            var viewModel = new CustomerViewModel
            {
                Customer = new Customer(),
                GetMembership = dbContext.Memberships.ToList(),
                //Gender=GetGender(),
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {var viewModel = new CustomerViewModel
            {
                Customer = new Customer(),
                GetMembership = dbContext.Memberships.ToList(),
                Gender = GetGender(),
            };
            return View("CreateNew", viewModel);
            }
            dbContext.customers.Add(customer);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
        public ActionResult Edit(int id)
        {
            var customer = dbContext.customers.SingleOrDefault(x => x.Id == id);
            if (customer != null)
            {
                var viewModel = new CustomerViewModel
                {
                    Customer = customer,
                    GetMembership = dbContext.Memberships.ToList(),
                    Gender = GetGender(),
                };
                return View(viewModel);
            }
            return HttpNotFound("Customer Id not exist");
        }
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            var customerInDb = dbContext.customers.SingleOrDefault(x => x.Id == id);
            if (customerInDb != null)
            {
                customerInDb.Name = customer.Name;
                customerInDb.DateofBirth = customer.DateofBirth;
                customerInDb.Address = customer.Address;
                customerInDb.MembershipId = customer.MembershipId;
                customerInDb.Gender = customer.Gender;
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Customer");
            }
            return HttpNotFound();
        }
        public ActionResult Delete(int id)
        {
            var customer = dbContext.customers.SingleOrDefault(m => m.Id == id);
            if (customer != null)
            {
                dbContext.customers.Remove(customer);
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Customer");
            }
            return HttpNotFound();
        }

        [NonAction]
        public List<SelectListItem> GetGender()
        {
            return new List<SelectListItem>
            {
                new SelectListItem{Text="Male",Value="Male" },
                new SelectListItem{Text="Female",Value="Female" },
                new SelectListItem{Text="Others",Value="Others" }

            };
           
        }
        [NonAction]
        public IEnumerable<SelectListItem>GetMembershipType()
        {
            var types = dbContext.Memberships.AsEnumerable().Select(x => new SelectListItem
            {
                Text = x.MembershipType,
                Value = x.Id.ToString()
            }).ToList();
            return types;
        }
       // [HandleError(ExceptionType =typeof(NullReferenceException),View ="NullRef")]
            public ActionResult MembershipDetails(int id)
        {
            throw new NullReferenceException();
            //var member = dbContext.customers.Include(m => m.Membership).FirstOrDefault(x => x.Id == id);
            //return View(member);

        }

    }
}