using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebovaAplikace.Models;
using Newtonsoft.Json;
using WebovaAplikace.UnitsOfWork.Interfaces;


namespace WebovaAplikace.Controllers
{
    public class MainController : Controller
    {
    
        public IUnitOfWork iUnitOfWork ;
        //konstruktor se zavolá pro získábí dat pomocí dependency injection

        public MainController(IUnitOfWork iUmitOfWork)
        {            
            this.iUnitOfWork = iUmitOfWork;
        }

        public string[] Vypis()
        {
            int i = 0;
            string[] st = new string[2];
            foreach (var item in iUnitOfWork.Customers.GetAll())
            {
                st[i] = JsonConvert.SerializeObject(item);
                i++;
            }
            return st;

        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }


     





    }
}
