using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Overtime.Models;
using Overtime.ViewModel;

namespace Overtime.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        private readonly OvertimeDbContext _db = new OvertimeDbContext();

        public ActionResult Login()
        {
            return View(new UserLogin());
        }

        [HttpPost]
        public ActionResult Login(UserLogin user, string returnurl)
        {
            var loguser = _db.Users.SingleOrDefault(x => x.Name == user.Username);

            if (loguser == null || !(loguser.CheckPassword(user.PasswoedHash)))
                ModelState.AddModelError("Name", "اسم الدخول او كلمة المرور خطأ من فضلك أعد المحاولة");
            if (!ModelState.IsValid)
                return View(user);

            FormsAuthentication.SetAuthCookie(user.Username, user.RemomeberMe);
            if (!string.IsNullOrEmpty(returnurl))
                return Redirect(returnurl);
            return RedirectToRoute("home");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToRoute("home");
        }
    }
}