using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Models;

namespace SMS.Areas.Teacher.Controllers
{
    public class AccountController : Controller
    {
        masterEntities db = new masterEntities();

        // GET: Teacher/Account
       
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Models.Teacher Th)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    //Read userdata
                    var user = db.Teachers.Where(x => x.ThFirstName == Th.ThFirstName && x.Password == Th.Password).FirstOrDefault();
                    if (user != null)
                    {
                                               
                        Session["Teacher"] = user.TeacherId;
                        Session["role"] = "Teacher";
                        string fname = user.ThFirstName;
                        string Lname= user.ThLastName;
                        string fullname = fname + Lname;
                        Session["FullName"] = fullname;
                      

                        return RedirectToAction("Index", "Home", new { area = "Teacher" });


                    }
                    
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Verfiy UserName Or Password");
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session["Teacher"] = null;
            Session.Clear();
            return RedirectToAction("Login", "Account", new { area = "Teacher" });
        }
    }
}