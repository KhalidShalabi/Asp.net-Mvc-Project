using SMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Areas.Student.Controllers
{
    public class ShowAttendanceController : Controller
    {
        masterEntities db = new masterEntities();

        // GET: Student/ShowAttendance
        public ActionResult Index()
        {
            var ss = int.Parse(Session["Student"].ToString());

            var query = db.StudentAttindences.Where(x => x.StudentId == ss)
                .Include(x => x.Student).ToList();

            return View(query);
        }
    }
}