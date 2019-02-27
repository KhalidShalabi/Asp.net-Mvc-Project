using Microsoft.AspNet.Identity;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Areas.Teacher.Controllers
{
    public class ClassController : Controller
    {
        masterEntities db = new masterEntities();

        // GET: Teacher/Class
        public ActionResult Index()
        {
            var ss = int.Parse(Session["Teacher"].ToString());
            var query = db.sp_getTeacher(ss);

            return View(query.ToList());
        }
    }
}