using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Overtime.Areas.Admin.ViewModel;
using Overtime.Infrastructure;
using Overtime.Models;

namespace Overtime.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin , moderator")]
    public class PositionsController : Controller
    {
        OvertimeDbContext _db = new OvertimeDbContext();
        private const int PerPage = 10;
        // GET: Admin/Position
        public ActionResult Index(int page = 1)
        {
            var totalCount = _db.Positions.Count();
          
              
            var positions = _db.Positions
                .OrderBy(x => x.Name).
                Skip((page - 1)*PerPage)
                .Take(PerPage).ToList(); 
            if (positions == null)
            return HttpNotFound();
            return View(new PositionsIndexVM
            {
                Positions = positions,
                Paggination = new Paggination(totalCount,page,PerPage)

                
            });
        }


        public ActionResult Create()
        {

            return View("Form",new PositionOperationsVM()
            {
                IsNew = true
            });
        }
        public ActionResult Edit(int id )
        {

            var position = _db.Positions.Find(id);

            return View("Form", new PositionOperationsVM()
            {
                IsNew = false,
                Id = position.Id,
              Name = position.Name
            });
        }

        [HttpPost]
        public ActionResult Create(PositionOperationsVM model)
        {
            model.IsNew = model.Id == null;
            if (!ModelState.IsValid)
                return View();
            if (model.IsNew)
            {
                _db.Positions.Add(new Position()
                {
                    Name = model.Name,
                    CreatedTime = DateTime.UtcNow.AddHours(2),
                    CreatedBy = Auth.User.Name
                });
            }
            else
            {
                var position = _db.Positions.Find(model.Id);
                if (position == null)
                    return HttpNotFound();
                position.Name = model.Name;
                position.ModifiedTime = DateTime.UtcNow.AddHours(2);


            }
            _db.SaveChanges();
            return RedirectToAction("Index","Positions");

        }

        [HttpPost]
        public ActionResult Trash(int id)
        {
            var position = _db.Positions.Find(id);
            if (position == null)
                HttpNotFound();
            position.DeletedTime = DateTime.UtcNow.AddHours(2);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Restore(int id)
        {
            var position = _db.Positions.Find(id);
            if (position == null)
                HttpNotFound();
            position.DeletedTime = null;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var position = _db.Positions.Find(id);
            if (position == null)
                HttpNotFound();
            _db.Positions.Remove(position);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}