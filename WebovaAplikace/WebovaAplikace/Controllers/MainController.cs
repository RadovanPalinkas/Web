using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebovaAplikace.Models;
using Newtonsoft.Json;
using Infrastructure;
using WebovaAplikace.UnitsOfWork.Interfaces;

namespace WebovaAplikace.Controllers
{
    public class MainController : Controller
    {
        public IUnitOfWork iUmitOfWork ;
        //konstruktor se zavolá pro získábí dat pomocí dependency injection

        public MainController(IUnitOfWork iUmitOfWork)
        {
            this.iUmitOfWork = iUmitOfWork;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }


       
    

       
       


    }
}
