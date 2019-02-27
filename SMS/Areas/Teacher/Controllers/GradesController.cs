using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Areas.Teacher.Controllers
{
    public class GradesController : Controller
    {
        masterEntities db = new masterEntities();
        // GET: Teacher/Grades
        public ActionResult Index()
        {
            ViewBag.ClassList = new SelectList(db.Classes, "ClassId", "ClassName");
            ViewBag.StudentList = new SelectList(db.Students, "StudentId", "FullName");
            ViewBag.SectionList = new SelectList(db.Sections, "SectionId", "Name");
            ViewBag.CourseList = new SelectList(db.Courses, "CoursesId", "CoursesTitle");
            return View();
        }



        [HttpPost]
        public ActionResult Submit(int ClassList, int StudentList, int SectionList, int CourseList, string FirstGrade
            , string SecondGrade, string ThirdGrade, string FinalGrade)
        {
            StudentsGrade sg = new StudentsGrade();
            sg.ClassId = ClassList;
            sg.StudentId = StudentList;
            sg.SectionId = SectionList;
            sg.CourseId = CourseList;
            sg.TeacherId = int.Parse(Session["Teacher"].ToString());
            sg.FirstGrade = FirstGrade;
            sg.SecondGrade = SecondGrade;
            sg.ThirdGrade = ThirdGrade;
            sg.FinalGrade = FinalGrade;
            sg.Avg = Average(sg.FirstGrade, sg.SecondGrade, sg.ThirdGrade, sg.FinalGrade);

            db.StudentsGrades.Add(sg);
            db.SaveChanges();

            return RedirectToAction("Index", "Class");
        }


        public static double Average(string FirstGrade, string SecondGrade, string ThirdGrade, string FinalGrade)
        {
            double avg = double.Parse(FirstGrade + SecondGrade + ThirdGrade + FirstGrade) / 4;

            return avg;
        }
    }
}