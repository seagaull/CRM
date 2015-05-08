using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.EnterpriseServices;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Overtime.Areas.Admin.ViewModel;
using Overtime.Infrastructure;
using Overtime.Models;
using WebGrease.Css.Extensions;

namespace Overtime.Areas.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        public EmployeeController()
        {

        }

        OvertimeDbContext _db = new OvertimeDbContext();
        private int PerPage = 10;
        public ActionResult Index(int page = 1)
        {
            var totalCount = _db.Employees.Count();

            return View(new EmployeesIndexVM
            {
                Employees = _db.Employees
            .OrderBy(x => x.Name).
            Skip((page - 1) * PerPage)
            .Take(PerPage)
            .ToList(),
                Paggination = new Paggination(totalCount, page, PerPage)

            });
        }



        [HttpPost]
        public ActionResult Index(EmployeesIndexVM form, int page = 1)
        {
            var totalCount = _db.Employees.Count();



            return View(new EmployeesIndexVM()
            {

                Employees = _db.Employees
               .Where(x => x.Name.StartsWith(
                   form.Search.Name) ||
                   x.Code.StartsWith(form.Search.Code)  ||
                   x.NationalId.StartsWith(form.Search.NationalId) ||
                   x.ATMNum.StartsWith(form.Search.AtmNum) )

           .OrderBy(x => x.Name).
           Skip((page - 1) * PerPage)
           .Take(PerPage)
           .ToList(),
                Paggination = new Paggination(totalCount, page, PerPage)

            });



        }



        public JsonResult GetEmployees(string sidx, string sord, int page, int rows)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var employees = _db.Employees.Select(a => new
            {
                a.Id,
                a.Name,
                a.Code,
                a.NationalId,
                a.ATMNum
                ,DepName=a.Department.Name


            });
            int totalRecords = employees.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sord.ToUpper() == "DESC")
            {
                employees = employees.OrderByDescending(x => x.Name);
                employees = employees.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                employees = employees.OrderBy(x => x.Name);
          //   employees = employees.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = employees

            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

   
        public JsonResult CheckUserId(string nationalId,int? Id)

        {

            if (Id == null)
            {
                var emp = _db.Employees.Where(x => x.NationalId == nationalId);
                if (emp.Count() > 0)
                    return Json(false, JsonRequestBehavior.AllowGet);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }


        }


        public ActionResult Create()
        {



            return View("Form", new EmployeesFormxVM
            {
                IsNew = true,
                Banks = _db.Banks.ToList(),
                Departments = _db.Departments.ToList(),

                Position = _db.Positions.ToList(),

                PositionDate = DateTime.UtcNow.AddHours(2)
                ,ATM = true,Gender= "male"
            });
        }

        public ActionResult Edit(int id)
        {


            var emp = _db.Employees.Find(id);
            if (emp == null)
                HttpNotFound();
            var subs = emp.SubPositions.FirstOrDefault();
            if (subs == null)
                HttpNotFound();
            var parent = _db.SubPositions.Find(subs.PositionId);

            var model = new EmployeesFormxVM()
            {
                IsNew = false,
                Departments = _db.Departments.ToList(),
                Name = emp.Name,
                Address = emp.Address,
                Code = emp.Code,
                Phone = emp.Phone,
                Email = emp.Email,
                ATM = emp.ATM,
                Id = emp.Id,
                SelectedDepartment = emp.DepartmentId,
                Position = _db.Positions.ToList(),
                SelectedPosition = parent.PositionId,
                SelectedGrade = emp.SubPositions.Max(x => x.PositionId),
                ATMNum = emp.ATMNum,
                Banks = _db.Banks.ToList(),
                Description = emp.StaffDetails.Details,
                Gender = emp.Gender,
                NationalId = emp.NationalId,
                Grades = _db.SubPositions.Where(x => x.Position.Id == parent.PositionId).ToList(),

                PositionDate = emp.SubPositions.FirstOrDefault(x => x.Employee.Id == emp.Id).StartDate

            };



            if (emp.StaffDetails.BankBranche != null)
            {


                model.SelectedDepartment = emp.DepartmentId;
                model.SelectedBank = emp.StaffDetails.BankBranche.BankId;
                model.SelectedBranch = emp.StaffDetails.BranchId;
                model.AccountNum = emp.StaffDetails.AccountNumber;
                model.Branches =
                    new SelectList(_db.Branches.Where(x => x.BankId == emp.StaffDetails.BankBranche.BankId), "Id",
                        "Name", emp.StaffDetails.BranchId);


            }


            return View("Form", model);



        }




        [HttpPost]
        public ActionResult Form(EmployeesFormxVM model)
        {

            model.IsNew = model.Id == null;
          

            if (!model.ATM)
            {
                if (model.SelectedBranch == null)
                    ModelState.AddModelError("SelectedBranch", "يجب أختيار بنك ");
                if (model.AccountNum == null)
                    ModelState.AddModelError("SelectedBranch", "يجب أدخال رقم حساب البنك  ");


            }
            if (model.ATM)
            {
               

                ModelState.Remove("SelectedBranch");
            };


            if (!model.IsNew)
                ModelState.Remove("NationalId");
            if (!ModelState.IsValid)
            {
                model.IsNew = model.Id == null;
                model.Banks = _db.Banks.ToList();
                model.Departments = _db.Departments.ToList();
                model.Position = _db.Positions.ToList();
                //GetBranches(model.SelectedBank);
                if (!model.IsNew)
                {
                    var emp2 = _db.Employees.Find(model.Id);
                    model.Grades = _db.SubPositions.Where(x => x.PositionId == model.SelectedPosition).ToList();
                    var mx = emp2.SubPositions.Max(x => x.PositionId);

                    model.Branches =new SelectList( _db.Branches.Where(x=>x.BankId==model.SelectedBank),"Id","Name");
                   
                }
                return View(model);
            }

         

            Employee emp;




            if (model.IsNew)
            {

                emp = new Employee();
                emp.StaffDetails = new EmplyeesBankDetails();
                BindingEmplyeeData(emp, model);
                emp.SubPositions.Add(new StaffPosition()
                {
                    PositionId = model.SelectedGrade,
                    StartDate = model.PositionDate

                });
                emp.CreatedBy = Auth.User.Name;
                emp.CreatedTime = DateTime.UtcNow.AddHours(2);
                _db.Employees.Add(emp);
            }
            else
            {
                emp = _db.Employees.Find(model.Id);
                var maxdata = emp.SubPositions.Max(x => x.StartDate);
                BindingEmplyeeData(emp, model);
                var empposition = emp.SubPositions.SingleOrDefault(x => x.StartDate == maxdata);
                _db.StaffPositions.Remove(empposition);
                emp.SubPositions.Add(new StaffPosition()
                {
                    PositionId = model.SelectedGrade,
                    StartDate = model.PositionDate

                });
                emp.ModifiedTime = DateTime.UtcNow.AddHours(2);


            }




            try
            {
                _db.SaveChanges();
            }
            catch (DbEntityValidationException errors)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var failure in errors.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }

                }


            }
            return RedirectToAction("Index");
        }

     

        private void BindingEmplyeeData(Employee emp, EmployeesFormxVM model)
        {
            emp.Name = model.Name;
            emp.Address = model.Address;
            emp.Phone = model.Phone;
            emp.Code = model.Code;
            emp.NationalId = model.NationalId;
            emp.Gender = model.Gender;
            emp.ATM = model.ATM;
            emp.ATMNum = model.ATMNum;
            emp.Email = model.Email;
            emp.DepartmentId = model.SelectedDepartment;
            emp.ModifiedTime = DateTime.UtcNow.AddHours(2);
            emp.StaffDetails.BranchId = model.SelectedBranch;
            emp.StaffDetails.AccountNumber = model.AccountNum;
            emp.StaffDetails.Details = model.Description;



        }

        public ActionResult GetBranches(int? id)
        {
            var branches = from c in _db.Branches
                           where c.BankId == id
                           orderby c.Name
                           select new
                           {
                               Id = c.Id,
                               Name = c.Name

                           };
            if (branches == null)
                return HttpNotFound();
            return Json(branches, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetSubPosition(int? id)
        {
            var branches = from c in _db.SubPositions
                           where c.PositionId == id
                           orderby c.Name
                           select new
                           {
                               Id = c.Id,
                               Name = c.Name

                           };
            if (branches == null)
                return HttpNotFound();
            return Json(branches, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var Emp = _db.Employees.Find(id);
            if (Emp == null)
                HttpNotFound();
            _db.Employees.Remove(Emp);
            _db.SaveChanges();
            return Json(new { Success = true });
        }

        [HttpPost]
        public ActionResult Restore(int id)
        {
            var emp = _db.Employees.Find(id);

            if (emp == null)
                HttpNotFound();

            emp.DeletedTime = null;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Trash(int id)
        {
            var emp = _db.Employees.Find(id);

            if (emp == null)
                HttpNotFound();

            emp.DeletedTime = DateTime.UtcNow.AddHours(2);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}