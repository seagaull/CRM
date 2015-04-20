using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Overtime.Models;
using Overtime.ViewModel;

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