using System.Web.Mvc;

namespace Overtime.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin ,moderator")]
    public class HomeController : Controller
    {
        public ActionResult Index(int page = 1)
        {
            return View();
        }
    }
}