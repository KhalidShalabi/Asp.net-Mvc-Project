using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Areas.Teacher.Controllers
{

    public class HomeController : Controller
    {
        masterEntities db = new masterEntities();

        // GET: Teacher/Home
        public ActionResult Index()
        {
            return View(db.Teachers.ToList());
        }
    }
}