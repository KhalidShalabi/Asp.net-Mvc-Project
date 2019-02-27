using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Models;

namespace SMS.Areas.Admin.Controllers
{
    public class ClassController : Controller
    {
        masterEntities db = new masterEntities();

        // GET: Admin/Class
        //For show table data
        public ActionResult ViewClasses()
        {
            return View(db.Classes.ToList());
        }


        //for modal and ajax
        public ActionResult Index()
        {
            return View();
        }


        //For saving the data
        [HttpPost]
        public ActionResult ClassForm(string Name)
        {
            if (ModelState.IsValid)
            {
                Class cls = new Class
                {
                    ClassName = Name,
                };
                db.Classes.Add(cls);
                db.SaveChanges();
                return Json(cls, JsonRequestBehavior.AllowGet);
            }
            return View();

        }

        [HttpGet]
        public ActionResult DeleteClass(int id)
        {
            var row = db.Classes.SingleOrDefault(x => x.ClassId == id);
            db.Classes.Remove(row);
            db.SaveChanges();

            return Json(row, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Edit(string Name, int class_id)
        {
            Class s = new Class
            {
                ClassName = Name,
                ClassId = class_id

            };

            db.Entry(s).State = EntityState.Modified;
            db.SaveChanges();
            return Json(s, JsonRequestBehavior.AllowGet);

        }

        //it recive the classid from data in ajax
        [HttpGet]
        public ActionResult GetClass(int class_id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            var r = db.Classes.SingleOrDefault(x => x.ClassId == class_id);
            return Json(r, JsonRequestBehavior.AllowGet);
        }

    }
}