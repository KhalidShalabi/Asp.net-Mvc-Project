using SMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Areas.Admin.Controllers
{
    public class ClassMaterialsController : Controller
    {
        masterEntities db = new masterEntities();

        // GET: Admin/ClassMaterials
        public ActionResult ViewClassM()
        {
            return View();
        }



        public ActionResult ClassTable()
        {
            return PartialView(db.ClassMaterials.OrderBy(x=>x.Name).ToList());
        }

       

        [HttpPost]
        public ActionResult Submit(string classMname)
        {
            if (ModelState.IsValid)
            {
                ClassMaterial c = new ClassMaterial
                {

                    Name = classMname
                };
                db.ClassMaterials.Add(c);
                db.SaveChanges();
                return Json(c, JsonRequestBehavior.AllowGet);
            }
            return View();
         
        }

       


        //Handle the edit get in ajax
        [HttpGet]
        public ActionResult Get(int id)
        {
            var r = db.ClassMaterials.Where(x => x.ClassMaterialsId == id)
                .SingleOrDefault();
            if (r==null)
            {
                return HttpNotFound();
            }
            

            return Json(r, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Edit(string ClassMName,int ClassId)
        {
                    ClassMaterial m = new ClassMaterial();
            if (ModelState.IsValid)
            {
                m.Name = ClassMName;
                m.ClassMaterialsId = ClassId;
                //run
                //db.ClassMaterials.Add(m); 
                db.Entry(m).State = EntityState.Modified;

                db.SaveChanges();
                return Json(m, JsonRequestBehavior.AllowGet);
            }
            return View();
           
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var row = db.ClassMaterials.SingleOrDefault(x => x.ClassMaterialsId == id);
            db.ClassMaterials.Remove(row);
            db.SaveChanges();

            return Json(row, JsonRequestBehavior.AllowGet);
        }
    }
}