using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace SMS.Areas.Admin.Controllers
{
    public class CourseController : Controller
    {
        // GET: Admin/Course
        masterEntities db = new masterEntities();





        //Handle the view and Recive the classid form url
        [HttpGet]
        public ActionResult Index(int class_id)
        {
            //Get class ID
            ViewBag.ClassMId = new SelectList(db.ClassMaterials, "ClassMaterialsId", "Name");

            var r = db.Courses.Where(x => x.ClassId == class_id);
            return View(r);
        }




        //Save the data
        [HttpPost]
        public ActionResult FormSubmit(string Title, int class_id,string Desc, int ClassMId)
        {
            if (ModelState.IsValid)
            {
                Cours s = new Cours
                {
                    CoursesTitle = Title,
                    ClassId = class_id,
                    Description = Desc,
                    ClassMaterialsId = ClassMId
                    

                };
                db.Courses.Add(s);
                db.SaveChanges();

                return Json(s, JsonRequestBehavior.AllowGet);
            }

            return View();

        }




        //in this view we create table to hold the data and its recive class id
        [HttpGet]
        public ActionResult Table(int class_id)
        {
            var r = db.Courses.Where(x => x.ClassId == class_id);
            return View(r);
        }

        //DeleteRow
        [HttpGet]
        public ActionResult Delete(int id)
        {
            //get the row
            var row = db.Courses.SingleOrDefault(x => x.CoursesId == id);
            db.Courses.Remove(row);
            db.SaveChanges();

            return Json(row, JsonRequestBehavior.AllowGet);
        }


        //Get section Id for Edit
        [HttpGet]
        public ActionResult GetCourse(int Course_id)
        {
            //Solve a get error
            db.Configuration.ProxyCreationEnabled = false;

            var r = db.Courses.SingleOrDefault(x => x.CoursesId == Course_id);
            return Json(r, JsonRequestBehavior.AllowGet);
        }


        //Post the Data After Editing
        [HttpPost]
        public ActionResult Edit(string Title,string desc, int Course_id, int class_id, int ClassMId)
        {
            Cours s = new Cours
            {
                CoursesTitle = Title,
                CoursesId = Course_id,
                ClassId = class_id,
                ClassMaterialsId = ClassMId,
                Description = desc

            };
                

            db.Entry(s).State = EntityState.Modified;
            db.SaveChanges();
            return Json(s, JsonRequestBehavior.AllowGet);
        }

    }
}



