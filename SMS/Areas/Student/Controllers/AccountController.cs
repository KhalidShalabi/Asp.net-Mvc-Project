using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Models;

namespace SMS.Areas.Student.Controllers
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
        public ActionResult Login(Models.Student st)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    //Read userdata
                    var user = db.Students.Where(x => x.StFirstName == st.StFirstName && x.StPassword == st.StPassword).FirstOrDefault();
                    if (user != null)
                    {

                        Session["Student"] = user.StudentId;
                        Session["role"] = "Student";
                        string fname = user.StFirstName;
                        string Lname = user.StLastName;
                        string fullnames = fname + Lname;
                        Session["stfullname"] = fullnames;
                        return RedirectToAction("Index", "Home", new { area = "Student" });

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
            Session["Student"] = null;
            Session.Clear();
            return RedirectToAction("Login", "Account", new { area = "Student" });
        }
    }
}