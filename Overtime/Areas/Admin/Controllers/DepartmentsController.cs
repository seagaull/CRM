using System;

using System.Linq;

using System.Web.Mvc;
using Overtime.Areas.Admin.ViewModel;
using Overtime.Infrastructure;
using Overtime.Models;

namespace Overtime.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin ,moderator")]
    public class DepartmentsController : Controller
    {
        public OvertimeDbContext _db = new OvertimeDbContext();

        public const int Perpage = 10;
        // GET: Admin/Departments

        public ActionResult Create()
        {
            
            return View("Form", new FormVm()
            {
                IsNew = true
            });
        }

        public ActionResult Index(int page = 1)
        {
            var totalCount = _db.Departments.Count();
            var departments = _db.Departments.
                OrderBy(x => x.Name).
                Skip((page - 1) * Perpage).
                Take(Perpage).ToList();
            if (departments == null)
                return HttpNotFound();
            return View(new DepartmentIndex
            {
             Departments = departments,
             Paggination = new Paggination(totalCount,page,Perpage)
           
           
            });
        }




        public ActionResult Edit(int id)
        {

            var dep = _db.Departments.Find(id);
            if (dep == null)
                HttpNotFound();


            return View("Form", new FormVm()
            {
                IsNew = false,
                Name = dep.Name,
                Id = id
            });
        }
        [HttpPost]
        public ActionResult Create(FormVm model)
        {

            model.IsNew = model.Id == null;

            if (!ModelState.IsValid)
                return View();
            if (model.IsNew)
            {
                _db.Departments.Add(new Department()
                {
                    Name = model.Name,
                    CreatedBy = Auth.User.Name,
                    CreatedTime = DateTime.UtcNow.AddHours(2),


                });
            }
            else
            {
                var dep = _db.Departments.SingleOrDefault(x => x.Id == model.Id);
                if (dep == null)
                    HttpNotFound();
                dep.Name = model.Name;
                dep.ModifiedTime = DateTime.UtcNow.AddHours(2);
            }
            _db.SaveChanges();
            return RedirectToAction("Index","Departments");
        }

        [HttpPost]
        public ActionResult Trash(int id)
        {
            var department = _db.Departments.Find(id);
            
            if(department==null)
                HttpNotFound();
            
                department.DeletedTime = DateTime.UtcNow.AddHours(2);
            _db.SaveChanges();
                return RedirectToAction("Index");
            
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var department = _db.Departments.Find(id);
            if (department == null)
                HttpNotFound();
            _db.Departments.Remove(department);
            _db.SaveChanges();
            return Json(new { Success = true });
        }

        [HttpPost]
        public ActionResult Restore(int id)
        {
            var department = _db.Departments.Find(id);

            if (department == null)
                HttpNotFound();

            department.DeletedTime =null;
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}