using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Areas.Teacher.Controllers
{
    public class CalendarController : Controller
    {
        // GET: Teacher/Calendar
        public ActionResult Index()
        {
            return View();
        }
    }
}