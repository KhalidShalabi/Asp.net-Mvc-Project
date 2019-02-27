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
    public class TeachersController : Controller
    {
        private masterEntities db = new masterEntities();

        // GET: Admin/Teachers
        public ActionResult Index()
        {
            return View(db.Teachers.ToList());
        }

       
        // GET: Admin/Teachers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Teachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeacherId,ThFirstName,ThAddress,ThHireDate,ThDegree,ThExperience,ThSecondName,ThLastName,Email,Gender,BirthDate,Image,Password")] SMS.Models.Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                teacher.Password = GenerateRandomPassword(teacher.ThFirstName);
                db.Teachers.Add(teacher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teacher);
        }

        // GET: Admin/Teachers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Admin/Teachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeacherId,ThFirstName,ThAddress,ThHireDate,ThDegree,ThExperience,ThSecondName,ThLastName,Email,Gender,BirthDate,Image,Password")] SMS.Models.Teacher teacher)
        {
            if (ModelState.IsValid)
            {

                db.Entry(teacher).State = System.Data.Entity.EntityState.Modified;
                teacher.Password = GenerateRandomPassword(teacher.ThFirstName);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

        // GET: Admin/Teachers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Admin/Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           
            var teacher = db.Teachers.Find(id);
            db.Teachers.Remove(teacher);
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

        [HttpGet]
        public ActionResult AssignCourse()
        {
            

            ViewBag.TeachersList = new SelectList(db.Teachers, "TeacherId", "FullName");
            ViewBag.CourseList = new SelectList(db.Courses, "CoursesId", "CoursesTitle");


            return View();
        }
      


        public static string GenerateRandomPassword(string username)
        {
            Random r = new Random();
            string RandomPassword = username;
            for (int i = 0; i < 6; i++)
            {

                RandomPassword += r.Next(0, 9);
            }
            return RandomPassword;

        }
    }
}
