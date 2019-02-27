using Microsoft.AspNet.Identity;
using SMS.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace SMS.Areas.Admin.Controllers
{
    public class SectionController : Controller
    {
        masterEntities db = new masterEntities();

        // GET: Admin/Section 
        //Modal and ajax and its handle the ClassId Request
        [HttpGet]
        public ActionResult Index(int class_id)
        {
            //Get class ID
            var r = db.Sections.Where(x => x.ClassId == class_id);
            return View(r);
        }


       

        //Save the data
        [HttpPost]
        public ActionResult FormSubmit(string Name,int class_id)
        {
            if (ModelState.IsValid)
            {
                Section s = new Section
                {
                    Name = Name,
                    ClassId = class_id,
                    
                };
                db.Sections.Add(s);
                db.SaveChanges();

                return Json(s, JsonRequestBehavior.AllowGet);
            }
            
            return View();

        }

       


        //in his view we create table to hold the data and its recive class id
        [HttpGet]
        public ActionResult ViewSection(int class_id)
        {
            var r = db.Sections.Where(x => x.ClassId == class_id);
          //  ViewBag.Section = r;
            return View(r);
        }

        //DeleteRow
        [HttpGet]
        public ActionResult Delete(int id)
        {
            //get the row
            var row = db.Sections.SingleOrDefault(x => x.SectionId == id);
            db.Sections.Remove(row);
            db.SaveChanges();

            return Json(row, JsonRequestBehavior.AllowGet);
        }


        //Get section Id for Edit
        [HttpGet]
        public ActionResult GetSection(int section_id)
        {
            //Solve a get error
            db.Configuration.ProxyCreationEnabled = false;

            var r = db.Sections.SingleOrDefault(x => x.SectionId == section_id);
            return Json(r, JsonRequestBehavior.AllowGet);
        }


        //Post the Data After Editing
        [HttpPost]
        public ActionResult Edit(string Name, int section_id, int class_id)
        {
            Section s = new Section
            {
                Name = Name,
                SectionId = section_id,
                ClassId = class_id

            };


            db.Entry(s).State = EntityState.Modified;
            db.SaveChanges();
            return Json(s, JsonRequestBehavior.AllowGet);
        }

    }
}