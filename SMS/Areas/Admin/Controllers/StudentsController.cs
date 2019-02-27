using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.IO;
using System.Data.Entity.Validation;

namespace SMS.Areas.Admin.Controllers
{
    public class StudentsController : Controller
    {
        masterEntities db = new masterEntities();
        

        // GET: Admin/Students


        public ActionResult Get(int? section_id)
        {
            

            var result = db.Students.ToList();

            if (section_id != null)
            {
                result = result.Where(x => x.SectionId == section_id).ToList();
            }
            

            return View(result);

        }
    
        
        public ActionResult Index(int? section_id)
        {



            //var result = db.Students.ToList();

            //if (section_id != null)
            //{
            //    result = result.Where(x => x.SectionId == section_id).ToList();
            //}


            return View(db.Students.ToList());
        }



        [HttpGet]
        public ActionResult ViewSectionsList(int class_id)
        {
            var row = db.Sections.Where(x =>x.ClassId == class_id);      
            return View(row);
        }
        
        [HttpPost]
        public ActionResult AddAction(string StFirstName,string StSecondName,string StLastName
            ,string StAddress,DateTime StDOB,HttpPostedFileBase ImageUpload, string PhoneNumber,string Email,bool Gender,string National_Number,int Section)
        {

           SMS. Models.Student st = new SMS. Models.Student();
                    if (ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(ImageUpload.FileName);
                        string extension = Path.GetExtension(ImageUpload.FileName);
                        fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                        st.ImagePath = "~/Images/" + fileName;
                        ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Images/"), fileName));
                    }

                    //Set Password
                    st.StPassword = GenerateRandomPassword(st.StFirstName);

                    //Set The remaining Field
                    st.StFirstName = StFirstName;
                    st.StSecondName = StSecondName;
                    st.StLastName = StLastName;
                    st.StAddress = StAddress;
                    st.StDOB = StDOB;
                    st.PhoneNumber = PhoneNumber;
                    st.Email = Email;
                    st.Gender = Gender;
                    st.National_Number = National_Number;
                    st.SectionId = Section;



                    db.Students.Add(st);
           
                db.SaveChanges();

            return RedirectToAction("Index", "Students");



        }



        public ActionResult AddOrEdit(int student_id = 0, int class_id=0)
        {
           ViewBag.ClassList = new SelectList(db.Classes, "ClassId", "ClassName",class_id); //return values of class so we can use loop to control it
               
            if (student_id != 0)
            {
                var studnet = db.Students.SingleOrDefault(x => x.StudentId == student_id);
                ViewBag.ClassList = new SelectList(db.Classes, "ClassId", "ClassName", class_id); //return values of class so we can use loop to control it

                return View(studnet);
            }else
            {
                return View(); 
            }
         
                
                    
        }




        [HttpGet]
        public ActionResult Edit(int student_id,int class_id, int section_id)
        {

           var studnet = db.Students.SingleOrDefault(x => x.StudentId == student_id);
            if (studnet == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassList = new SelectList(db.Classes.Where(x=>x.ClassId == class_id), "ClassId", "ClassName");

            return View("AddOrEdit",studnet);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var row = db.Students.SingleOrDefault(x => x.StudentId == id);
            db.Students.Remove(row);
            db.SaveChanges();

            return Json(row, JsonRequestBehavior.AllowGet);
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