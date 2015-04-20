using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Overtime.Models;

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