using System;
using System.Linq;
using System.Web.Mvc;
using Overtime.Areas.Admin.ViewModel;
using Overtime.Models;

namespace Overtime.Areas.Admin.Controllers
{
    public class SubPositionsController : Controller
    {
        private readonly OvertimeDbContext _db = new OvertimeDbContext();
        // GET: Admin/SubPositions
        public ActionResult Index()
        {
            return View(new SubPositionsIndexVM
            {
                Positions = new SelectList(_db.Positions.ToList(), "Id", "Name")
            });
        }

        public ActionResult GetSubs(int id)
        {
            var grade = from c in _db.SubPositions
                where c.PositionId == id
                select new
                {
                    c.Name,
                    Position = c.Position.Name,
                    c.Id,
                    c.CreatedBy
                };


            return Json(grade, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            return View("Form", new SubPositionsFormVM
            {
                IsNew = true,
                Positions = new SelectList(_db.Positions.ToList(), "Id", "Name")
            });
        }

        public ActionResult Edit(int id)
        {
            var sub = _db.SubPositions.Find(id);
            if (sub == null)
                return HttpNotFound();
            return View("Form", new SubPositionsFormVM
            {
                Id = sub.Id,
                Name = sub.Name,
                IsNew = false,
                Positions = new SelectList(_db.Positions.ToList(), "Id", "Name", sub.PositionId),
                SelectedPosition = sub.PositionId
            });
        }

        public ActionResult Form(SubPositionsFormVM model)
        {
            model.IsNew = model.Id == null;

            if (!ModelState.IsValid)
                return View(model);
            if (model.IsNew)
            {
                _db.SubPositions.Add(new SubPosition
                {
                    Name = model.Name,
                    PositionId = model.SelectedPosition,
                    CreatedBy = Auth.User.Name,
                    CreatedTime = DateTime.UtcNow.AddHours(2)
                });
            }
            else
            {
                var sub = _db.SubPositions.Find(model.Id);
                sub.Name = model.Name;
                sub.ModifiedTime = DateTime.UtcNow.AddHours(2);
                sub.PositionId = model.SelectedPosition;
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var sub = _db.SubPositions.Find(id);
            if (sub == null)
                HttpNotFound();
            _db.SubPositions.Remove(sub);
            _db.SaveChanges();

            return Json(new {Success = true});
        }
    }
}