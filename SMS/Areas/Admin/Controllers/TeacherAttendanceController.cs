using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Areas.Admin.Controllers
{
    public class TeacherAttendanceController : Controller
    {
        masterEntities db = new masterEntities();

        // GET: Admin/TeacherAttendance
        public ActionResult Index()
        {
            return View(db.Teachers.ToList());
        }



        [HttpPost]
        public ActionResult submit(int[] TeacherId)
        {
            DayDate d = new DayDate();
            for (int i = 0; i < TeacherId.Length; i++)
            {
                d.TeacherId = TeacherId[i];
                d.Date = DateTime.Today;
                db.DayDates.Add(d);
                db.SaveChanges();
            }


            return RedirectToAction("Index", "Home");
        }




    }
}