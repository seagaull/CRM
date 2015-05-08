using System.Web.Mvc;

namespace Overtime.Controllers
{
    public class HomeController : Controller
    {
        private const string Userkey = "SimpleBlog.Auth.UserKey";
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}