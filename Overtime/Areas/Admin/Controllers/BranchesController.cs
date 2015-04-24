using System;

using System.Linq;

using System.Web.Mvc;

using Overtime.Areas.Admin.ViewModel;

using Overtime.Models;


namespace Overtime.Areas.Admin.Controllers
{


    public class BranchesController : Controller
    {

        public OvertimeDbContext _db = new OvertimeDbContext();

        private const int PerPage = 7;

        public ActionResult Index(int? id,int page=1)
        {
           
            var bank = _db.Banks.ToList();
            if (bank == null)
                return HttpNotFound();
            return View(new BranchIndexVM
            {

                Banks = bank,

                
            });

        }

        [HttpPost]
        public ActionResult GetBranches(int? id)
        {


            var branches = from branch in _db.Branches
                           where branch.BankId == id
                           orderby branch.Name
                           select new
                           {
                               Id = branch.Id,
                               Name = branch.Name,
                               BankId = branch.BankId,
                               CreatedBy = branch.CreatedBy,
                               Address = branch.BankAddress



                           };
            if (branches == null)
                return HttpNotFound();
            return Json(branches, JsonRequestBehavior.AllowGet);


        }
        [Authorize(Roles = "admin,moderator")]

        public ActionResult Create()
        {


            return View("Form", new BranchFormVM
            {

                IsNew = true,
                Banks = new SelectList(_db.Banks.ToList(), "Id", "Name")

            });
        }
        [Authorize(Roles = "admin,moderator")]
        public ActionResult Edit(int id)
        {
            var branch = _db.Branches.Find(id);
            if (branch == null)
                return HttpNotFound();


            return View("Form", new BranchFormVM
            {

                IsNew = false,
                Banks = new SelectList(_db.Banks.ToList(), "Id", "Name", branch.BankId),
                Name = branch.Name,
                Id = branch.Id,
                Address = branch.BankAddress,
                SelectedBankId = branch.BankId

            });
        }
        public ActionResult Form(BranchFormVM model)
        {


            model.IsNew = model.Id == null;
            if (!ModelState.IsValid)
                return View(model);
            if (model.IsNew)
            {
                _db.Branches.Add(new BankBranche()
                {
                    BankId = model.SelectedBankId,
                    BankAddress = model.Address,
                    Name = model.Name,
                    CreatedTime = DateTime.UtcNow.AddHours(2),
                    CreatedBy = Auth.User.Name,



                });



            }
            else
            {

                var branch = _db.Branches.Find(model.Id);
                if (branch == null)
                    HttpNotFound();
                branch.BankId = model.SelectedBankId;
                branch.BankAddress = model.Address;
                branch.Name = model.Name;
                branch.ModifiedTime = DateTime.UtcNow.AddHours(2);
            }



            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "admin")]

        [HttpPost]

        public ActionResult Delete(int id)
        {
            var branch = _db.Branches.Find(id);
            if (branch == null)
                HttpNotFound();
            _db.Branches.Remove(branch);
            _db.SaveChanges();

            return Json(new { Success = true });
        }
    }
}