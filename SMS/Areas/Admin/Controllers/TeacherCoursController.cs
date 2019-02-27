using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SMS.Models;

namespace SMS.Areas.Admin.Controllers
{
    public class TeacherCoursController : Controller
    {
        private SchoolEntities1 db = new SchoolEntities1();

        // GET: Admin/TeacherCours
        public ActionResult Index()
        {
            var teacherCourses = db.TeacherCourses.Include(t => t.Cours).Include(t => t.Teacher);
            return View(teacherCourses.ToList());
        }

        // GET: Admin/TeacherCours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherCours teacherCours = db.TeacherCourses.Find(id);
            if (teacherCours == null)
            {
                return HttpNotFound();
            }
            return View(teacherCours);
        }

        // GET: Admin/TeacherCours/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CoursesId", "CoursesTitle");
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "ThFirstName");
            return View();
        }

        // POST: Admin/TeacherCours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,TeacherId,Id")] TeacherCours teacherCours)
        {
            if (ModelState.IsValid)
            {
                db.TeacherCourses.Add(teacherCours);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CoursesId", "CoursesTitle", teacherCours.CourseId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "ThFirstName", teacherCours.TeacherId);
            return View(teacherCours);
        }

        // GET: Admin/TeacherCours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherCours teacherCours = db.TeacherCourses.Find(id);
            if (teacherCours == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CoursesId", "CoursesTitle", teacherCours.CourseId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "ThFirstName", teacherCours.TeacherId);
            return View(teacherCours);
        }

        // POST: Admin/TeacherCours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,TeacherId,Id")] TeacherCours teacherCours)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacherCours).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CoursesId", "CoursesTitle", teacherCours.CourseId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "ThFirstName", teacherCours.TeacherId);
            return View(teacherCours);
        }

        // GET: Admin/TeacherCours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherCours teacherCours = db.TeacherCourses.Find(id);
            if (teacherCours == null)
            {
                return HttpNotFound();
            }
            return View(teacherCours);
        }

        // POST: Admin/TeacherCours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeacherCours teacherCours = db.TeacherCourses.Find(id);
            db.TeacherCourses.Remove(teacherCours);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
