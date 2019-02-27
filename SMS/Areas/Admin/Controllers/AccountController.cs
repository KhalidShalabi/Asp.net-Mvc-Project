using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Areas.Admin.Controllers
{

    //Login For Admin
    public class AccountController : Controller
    {
        masterEntities db = new masterEntities();
        // GET: Admin/Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Manager man)
        {
            if (ModelState.IsValidField("Name")&& ModelState.IsValidField("Password"))
            {
                
                try
                {
                    //Read userdata
                    var user = db.Managers.Where(x => x.Name == man.Name && x.Password == man.Password).FirstOrDefault();
                    if (user!= null)
                    {
                        
                        Session["Admin"] = user.Id ;
                        Session["role"] = "Admin";
                        return RedirectToAction("Index", "Home", new { area = "Admin" });

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
            Session["Admin"] = null;
             Session.Clear();
            return RedirectToAction("Login", "Account", new { area = "Admin" });
        }
    }
}