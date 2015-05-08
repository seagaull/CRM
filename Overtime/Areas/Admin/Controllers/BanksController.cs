using System;
using System.Linq;
using System.Web.Mvc;
using Overtime.Areas.Admin.ViewModel;
using Overtime.Infrastructure;
using Overtime.Models;

namespace Overtime.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin ,moderator")]
    public class BanksController : Controller
    {
        // GET: Admin/Home
        private const int PerPage = 7;
        public OvertimeDbContext _db = new OvertimeDbContext();
        // GET: Admin/Banks
        public ActionResult Index(int page = 1)
        {
            var totalCount = _db.Banks.Count();
            var banks = _db.Banks.OrderBy(x => x.Name).Skip((page - 1)*PerPage).Take(PerPage).ToList();
            return View(new BanksVMIndex
            {
                Banks = banks,
                Paggination = new Paggination(totalCount, page, PerPage)
            });
        }

        public ActionResult Create()
        {
            return View("Form", new BankFormsVM
            {
                IsNew = true
            });
        }

        public ActionResult Edit(int id)
        {
            var bank = _db.Banks.Find(id);
            if (bank == null)
                return HttpNotFound();


            return View("Form", new BankFormsVM
            {
                IsNew = false,
                Name = bank.Name,
                Id = bank.Id
            });
        }

        [HttpPost]
        public ActionResult Form(BankFormsVM model)
        {
            model.IsNew = model.Id == null;
            Bank bank;
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.IsNew)
            {
                bank = new Bank
                {
                    Name = model.Name,
                    CreatedBy = Auth.User.Name,
                    CreatedTime = DateTime.UtcNow.AddHours(2)
                };
                _db.Banks.Add(bank);
            }
            else
            {
                bank = _db.Banks.Find(model.Id);
                if (bank == null)
                    return HttpNotFound();
                bank.Name = model.Name;
                bank.ModifiedTime = DateTime.UtcNow.AddHours(2);
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Trash(int id)
        {
            var bank = _db.Banks.Find(id);
            if (bank == null)
                return HttpNotFound();
            bank.DeletedTime = DateTime.UtcNow.AddHours(2);
            _db.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpPost]
        public ActionResult Restore(int id)
        {
            var bank = _db.Banks.Find(id);
            if (bank == null)
                return HttpNotFound();
            bank.DeletedTime = null;
            _db.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var bank = _db.Banks.Find(id);
            if (bank == null)
                return HttpNotFound();
            _db.Banks.Remove(bank);
            _db.SaveChanges();
            return Json(new {Success = true});
        }
    }
}