using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    
    public class HomeController : Controller
    {
        //View To another Areas
        public ActionResult MainView()
        {            
           return View();
        }
      

       
    }
}