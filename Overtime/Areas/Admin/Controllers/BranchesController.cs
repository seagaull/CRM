using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Overtime.Areas.Admin.ViewModel;
using Overtime.Infrastructure;
using Overtime.Models;
using WebGrease.Css.Extensions;
using SelectListItem = System.Web.WebPages.Html.SelectListItem;

namespace Overtime.Areas.Admin.Controllers
{

    [Authorize(Roles = "admin")]
    public class BranchesController : Controller
    {

        public OvertimeDbContext _db = new OvertimeDbContext();

        private const int PerPage = 7;

        public JsonResult DeleteBran(int? BranID)
        {
            if (BranID!= null )
            
            
           {
                var h = _db.Branches.Find(BranID);
                try
                {
                    _db.Branches.Remove(h);
                    _db.SaveChanges();
                    return Json(true);

                }
                catch (Exception)
                {
                        
                    throw;
                }
            }

            else
            {
                return Json(false);
            }
        }
        public ActionResult Index( int? id)
        {

           

                 

                    return View(new BranchIndexVM
                    {
                        
                    });
                
           
        


        }

        public ActionResult GetBanks()
        {
            var banks = new SelectList( _db.Banks.ToList(),"Id","Name");

            if (HttpContext.Request.IsAjaxRequest())
                return Json(banks.ToArray(), JsonRequestBehavior.AllowGet);
            return RedirectToAction("Index");
        }

        public ActionResult Branches(int id)
        {
            if (id != null)
            {

                {
                    var branches = _db.Branches.Where(x => x.BankId == id).Select(x => new BranchVM()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Address = x.BankAddress
                    }).ToList();


                    if (HttpContext.Request.IsAjaxRequest())
                        return Json(branches.ToArray(), JsonRequestBehavior.AllowGet);

                    
                }
            }
            return View(new BranchIndexVM
                    {

                    });



            
        }


        public ActionResult Creat()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Form(int? id)
        {
            
            return View();
        }
        [HttpPost]
       
        public ActionResult Delete(int  id)
        {
            var branch = _db.Branches.Find(id);
            if (branch == null)
                HttpNotFound();
            _db.Branches.Remove(branch);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}