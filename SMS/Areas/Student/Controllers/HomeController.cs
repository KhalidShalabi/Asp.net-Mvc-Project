using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Areas.Student.Controllers
{
    public class HomeController : Controller
    {
        masterEntities db = new masterEntities();

        // GET: Student/Home
        public ActionResult Index()
        {

            return View(db.Students.ToList());
        }
    }
}