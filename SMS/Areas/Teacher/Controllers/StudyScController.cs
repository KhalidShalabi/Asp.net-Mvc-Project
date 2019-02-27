using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Areas.Teacher.Controllers
{
    public class StudyScController : Controller
    {
        // GET: Teacher/StudySc
        public ActionResult Index()
        {
            masterEntities db = new masterEntities();
            var Query = db.StudySchedules.ToList();
            return View(Query);
           
        }
    }
}