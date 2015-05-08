using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using Overtime.Infrastructure;
using Overtime.Models;

namespace Overtime.Areas.Admin.ViewModel
{
    public class EmployeesIndexVM
    {
        public EmplyeeSearchVm Search { get; set; }
        public List<Employee> Employees { get; set; }
        public Paggination Paggination { get; set; }

    }


    public class EmplyeeSearchVm
    {
           [Display(Name = "الأسم")]
        public string Name { get; set; }

        public int SelectedBranch { get; set; }
        public int SelectedDepartment { get; set; }
           [Display(Name = "رقم البطاقة")]
        public string NationalId { get; set; }
           [Display(Name = "رقم الكارت")]
        public string AtmNum { get; set; }
           [Display(Name = "الكود ")]
        public string Code { get; set; }

    }






    public class Emp
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

    }



    public class EmployeesFormxVM
    {


        public EmployeesFormxVM()
        {
            this.Departments=new List<Department>();
            this.Banks= new List<Bank>();
            
      
            
        }


      
        public bool IsNew { get; set; }
        public int? Id { get; set; }
        [Display(Name = "الأسم",Prompt = "أدخل الأسم")]
        [Required(ErrorMessage = "يجيب أدخال الأسم")]
        public string Name { get; set; }
        [Display(Name = "النوع")]
        [Required(ErrorMessage = "يجيب اختيار النوع")]
        public string Gender { get; set; }
        [Display(Name = "العنوان",Prompt = "أدخل العنوان")]
        public string Address { get; set; }
        [Display(Name = "تليفون", Prompt = "أدخل رقم تليفون")]
        public string Phone { get; set; }
        [Display(Name = "بريد ألأكترونى")]
        [DataType(DataType.EmailAddress, ErrorMessage = "من فضلك تأكد من عنوان البريد الألكتورنى")]

        public string Email { get; set; }
        [Display(Name = "رقم الكارت ")]
        [RegularExpression(@"\d{19}", ErrorMessage = "تأكد من رقم البطاقة")]
        public string ATMNum { get; set; }
        [Display(Name = "الرقم القومى"), Remote("CheckUserId", "Employee", "admin",AdditionalFields = "Id", ErrorMessage = "رقم البطاقة مسجل مسبقا")]
      
        [RegularExpression(@"\d{14}", ErrorMessage = "تأكد من رقم البطاقة")]
        
        public string NationalId { get; set; }

        [Display(Name = "القسم")]
        public List<Department> Departments { get; set; }
     
        public int? SelectedDepartment { get; set; }
        

        [Display(Name = "القسم")]
        public List<Position> Position { get; set; }
         public int SelectedPosition { get; set; }
       

        public List<SubPosition> Grades { get; set; }
        [Required(ErrorMessage = "يجب أختيار درجة")]
        public int SelectedGrade { get; set; }

        [Required(ErrorMessage = "يجب تحديد تاريخ الحصول على الدرجة")]

        [Display(Name = "تاريخ الحصول على الدرجة")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PositionDate { get; set; }


        [Required (ErrorMessage = "يجب أختيار و سيلة للدفع") ]
        [Display(Name = "طريقة الدفع")]
        public bool ATM { get; set; }
        [Display(Name = "كود الموظف")]
        public string Code { get; set; }


        [Display(Name = "البنك")]
        
        public List<Bank> Banks { get; set; }
        public int? SelectedBank { get; set; }
        public SelectList Branches { get; set; }
        public int? SelectedBranch { get; set; }
          [Display(Name = "رقم الحساب")]
    
        public string AccountNum { get; set; }
          [Display(Name = "ملاحظات ")]
        public string Description { get; set; }

       // public StaffPosition SataffPosition { get; set; }




    }


    public class SubPositionVM
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }

        public DateTime StartDate { get; set; }

    }

}