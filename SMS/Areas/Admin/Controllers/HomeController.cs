using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SMS.Models;

namespace SMS.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            using (var context = new masterEntities())
            {
                ViewBag.Count = context.Students.ToList().Count();
               
            }

            using (var context2 = new masterEntities())
            {
               
                ViewBag.Count2 = context2.Classes.ToList().Count();
            }
            using (var context3 = new masterEntities())
            {
                ViewBag.Count3 = context3.ClassMaterials.ToList().Count();
            }
            using (var context4 = new masterEntities())
            {
                ViewBag.Count4 = context4.Courses.ToList().Count();
            }
                return View();
        }
    }
}