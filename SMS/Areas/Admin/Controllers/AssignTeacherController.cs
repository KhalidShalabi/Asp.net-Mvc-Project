using SMS.Models;
using System.Web.Mvc;
using System.Linq;



namespace SMS.Areas.Admin.Controllers
{
    public class AssignTeacherController : Controller
    {
        masterEntities db = new masterEntities();


        // GET: Admin/AssignTeacher
        public ActionResult Index()
        {
            ViewBag.TeacherList = new SelectList(db.Teachers, "TeacherId", "FullName");
            ViewBag.CourseList = new SelectList(db.Courses, "CoursesId", "CoursesTitle");
            ViewBag.SectionList = new SelectList(db.Sections, "SectionId", "Name");

            return View();
        }

        [HttpPost]
        public ActionResult Submit(int TeacherList,int CourseList,int SectionList)
        {
           
            TeacherCours tc = new TeacherCours
            {
                TeacherId = TeacherList,
                CourseId = CourseList
              
            };
            db.TeacherCourses.Add(tc);
            db.SaveChanges();

            TeacherSection ts = new TeacherSection();
            ts.TeacherId = TeacherList;
            ts.SectinId = SectionList;
            db.TeacherSections.Add(ts);
            db.SaveChanges();
            return RedirectToAction("Index","Teachers");
        }


        public ActionResult ViewTeacher(int section_id)
        {
            var view = db.TeacherSections.Where(x => x.SectinId == section_id);
            return View(view);
        }

        public ActionResult ViewCourse(int Course_id)
        {
            var view = db.TeacherCourses.Where(x => x.CourseId == Course_id);
            return View(view);
        }
    }
}