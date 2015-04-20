
using System.Web.Mvc;
using System.Web.Routing;
using Overtime.Areas.Admin.Controllers;
using HomeController = Overtime.Controllers.HomeController;

namespace Overtime
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var namespaces = new[] { typeof(HomeController).Namespace };


            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


  

            routes.MapRoute("Admin", "admin", new { controller = "Home", action = "Index",area="admin" }, namespaces);

            routes.MapRoute("logout", "logout", new { controller = "Auth", action = "logout" }, namespaces);

            routes.MapRoute("Login", "login", new { controller = "Auth", action = "Login" }, namespaces);

            routes.MapRoute("Home", "", new { controller = "Home", action = "Index" }, namespaces);




        }
    }
}