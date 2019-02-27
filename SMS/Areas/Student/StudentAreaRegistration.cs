using System.Web.Mvc;

namespace SMS.Areas.Student
{
    public class StudentAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Student";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Student_default",
                "Student/{controller}/{action}/{id}",
                new { controller = "Account", action = "Login", id = UrlParameter.Optional }

            );
        }
    }
}