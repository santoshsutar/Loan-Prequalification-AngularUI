using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProEnt.LoanPrequalification.UI.MVC.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {            
            ViewData["Message"] = "Welcome to Chapter 12!";

            return View();
        }      
    }    
}


