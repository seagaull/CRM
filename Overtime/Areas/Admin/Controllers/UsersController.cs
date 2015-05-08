using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;
using Overtime.Areas.Admin.ViewModel;
using Overtime.Infrastructure;
using Overtime.Models;

namespace Overtime.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        private const int PerPage = 5;
        private readonly OvertimeDbContext _db = new OvertimeDbContext();
        // GET: Admin/Users
        [Authorize(Roles = "admin,moderator")]
        public ActionResult Index(int page = 1)
        {
            var totalCount = _db.Users.Count();

            var users = _db.Users.OrderBy(x => x.Name)
                .Skip((page - 1)*PerPage)
                .Take(PerPage).ToList();

            return View(new UsersIndexVM
            {
                Users = users,
                Paggination = new Paggination(totalCount, page, PerPage)
            });
        }

        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View("Form", new UserForm
            {
                IsNew = true,
                Roles = _db.Roles.Select(x => new RolesCheckBox
                {
                    Id = x.Id,
                    Name = x.Name,
                    Checked = false
                }).ToList()
            });
        }

        [Authorize(Roles = "admin,moderator")]
        public ActionResult Edit(int id)
        {
            var user = _db.Users.Find(id);
            if (user == null)
                return HttpNotFound();

            var role = _db.Roles.ToList();
            var form = new UserForm
            {
                Id = user.Id,
                IsNew = false,
                Name = user.Name,
                Roles = role.Select(r => new RolesCheckBox
                {
                    Id = r.Id,
                    Name = r.Name,
                    Checked = user.Roles.Contains(r)
                }).ToList()
            };


            return View("Form", form);
        }

        [HttpPost]
        public ActionResult Form(UserForm model)
        {
            model.IsNew = model.Id == 0;
            var user = new User();

            if (model.Roles.Count(x => x.Checked) == 0)
            {
                ModelState.AddModelError("Roles", "يجب ان تختار صلاحية واحدة على الأقل");
            }

            if (model.IsNew)
            {
                user = new User
                {
                    Name = model.Name,
                    CreatedBy = User.Identity.Name,
                    CreatedTime = DateTime.UtcNow.AddHours(2)
                };
                user.Passwordhash = user.SetPassword(model.Password);
                foreach (var role in model.Roles)
                {
                    if (role.Checked)
                    {
                        user.Roles.Add(_db.Roles.Find(role.Id));
                    }
                }
                _db.Users.Add(user);
            }
            else
            {
                user = _db.Users.Find(model.Id);
                if (user == null)
                    return HttpNotFound();
                user.Name = model.Name;

                user.ModifiedTime = DateTime.UtcNow.AddHours(2);
                var allRoles = _db.Roles.ToList();
                //added roles 
                foreach (var role in model.Roles.Where(x => x.Checked))
                {
                    //if user role dosent have one or more checked role add role
                    if (user.Roles.Any(x => x.Id != role.Id))
                    {
                        user.Roles.Add(allRoles.SingleOrDefault(x => x.Id == role.Id));
                    }
                }

                foreach (var role in model.Roles.Where(x => !x.Checked))
                {
                    //if user role dosent have one or more checked role add role
                    if (user.Roles.Any(x => x.Id == role.Id))
                    {
                        user.Roles.Remove(allRoles.SingleOrDefault(x => x.Id == role.Id));
                    }
                }
                ModelState.Remove("password");
            }
            if (!ModelState.IsValid)
                return View(model);


            try
            {
                _db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }


            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin,moderator")]
        public ActionResult ResetPassword(int id)
        {
            var password = _db.Users.Find(id);
            if (password == null)
                HttpNotFound();


            return View(new ResetPasswordVM
            {
                Id = password.Id,
                Name = password.Name
            });
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult ResetPassword(ResetPasswordVM model)
        {
            var password = _db.Users.Find(model.Id);
            if (password == null)
                HttpNotFound();

            password.Passwordhash = password.SetPassword(model.Password);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            var user = _db.Users.Find(id);
            if (user == null)
                HttpNotFound();
            _db.Users.Remove(user);
            _db.SaveChanges();
            return Json(new {Success = true});
        }
    }
}