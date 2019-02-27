using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Areas.Admin.Controllers
{
    public class StudyScController : Controller
    {
        masterEntities db = new masterEntities();

        // GET: Admin/StudySc
        public ActionResult Index()
        {
            ViewBag.TeacherList = new SelectList(db.Teachers, "TeacherId", "ThFirstName");
            ViewBag.CourseList = new SelectList(db.Courses, "CoursesId", "CoursesTitle");
            ViewBag.DayList = new SelectList(db.Days, "Id", "Day1");
            ViewBag.SectionList = new SelectList(db.Sections, "SectionId", "Name");



            return View();
        }


        [HttpPost]
        public ActionResult Save(int TeacherList, int CourseList, int DayList, int SectionList)
        {
            // var ss = int.Parse(Session["Student"].ToString());

            var st = new StudySchedule
            {

                TeacherId = TeacherList,
                CourseId = CourseList,
                DayId = DayList,
                SectionId = SectionList
            };
            db.StudySchedules.Add(st);
            db.SaveChanges();
            return RedirectToAction("Show");
        }



        public ActionResult Show()
        {
            var Query = db.StudySchedules.ToList();
            return View(Query);
        }
       
    }
}