using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Areas.Student.Controllers
{
    public class CalendarController : Controller
    {
        // GET: Student/Event
        public ActionResult Index()
        {
            return View();
        }
    }
}