using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebovaAplikace.Models;
using Newtonsoft.Json;
using WebovaAplikace.Models.CodeFirst;


namespace WebovaAplikace.Controllers
{
    public class MainController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        //---------------------------------- ZKUSEBNÍ Entity framework ---------------------------------------------------------------------------------------------------

        public ICustomerModel iCustomerModel;
        //konstruktor se zavolá pro získábí dat pomocí dependency injection

        public MainController(ICustomerModel iCustomerModel)
        {
            this.iCustomerModel = iCustomerModel;
        }
        public ActionResult GetCustomers()
        {
            return Json(iCustomerModel.GetCustomers(), JsonRequestBehavior.AllowGet);
        }

        public void SaveCustomer()
        {
            var listCustomers = iCustomerModel.GetCustomers();

            using (EntityContext ec = new EntityContext())
            {
                foreach (var customer in listCustomers)
                {
                    ec.Customers.Add(customer);                    
                }
                ec.SaveChanges();

            
            }
        }
        public void UpdateCustomer()
        {
            Customer customer;
            using (EntityContext ec = new EntityContext())
            {
                customer = ec.Customers.Single();
                customer.Name = "Martin";
                ec.SaveChanges();
            }
        }
        public string ReadCustomer(int id)
        {
            Customer customer;

            using (EntityContext ec = new EntityContext())
            {
                customer = ec.Customers.Single(e => e.ID == id);
            }
            return JsonConvert.SerializeObject(customer);
        }
        public string ReadAllCustomers()
        {
            IEnumerable<Customer> customer;

            using (EntityContext ec = new EntityContext())
            {
                customer = ec.Customers.AsNoTracking().ToList();
            }
            return JsonConvert.SerializeObject(customer);
        }

        public void DeleteCustomer(int id)
        {
            Customer customer;
            using (var ec = new EntityContext())
            {
                customer = ec.Customers.Single(e => e.ID == 6);
                ec.Customers.Remove(customer);
            }
           



        }
       


    }
}
