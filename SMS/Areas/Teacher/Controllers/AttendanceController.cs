using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Areas.Teacher.Controllers
{
    public class AttendanceController : Controller
    {
        masterEntities db = new masterEntities();

        // GET: Teacher/Attendance
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        [HttpPost]
        public ActionResult Submit(int[] StudentId)
        {
            StudentAttindence s = new StudentAttindence();

            for (int i = 0; i < StudentId.Length; i++)
            {
                s.StudentId = StudentId[i];
                s.Date = DateTime.Today;
                db.StudentAttindences.Add(s);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
    }
}