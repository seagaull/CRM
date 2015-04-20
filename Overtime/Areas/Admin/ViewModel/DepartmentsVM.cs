using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Metadata;
using System.Web;
using Overtime.Infrastructure;
using Overtime.Models;

namespace Overtime.Areas.Admin.ViewModel
{
    public class FormVm
    {
        public int? Id { get; set; }

        [Display(Name = "الأسم"),
        Required(ErrorMessage = "يجب أدخال البيانات"),
        MaxLength(256,ErrorMessage = "الأسم طويل جدا")]
        public string Name { get; set; }

        public bool IsNew { get; set; }

    }


    public class DepartmentIndex
    {
     // public DataPaging<Department> Departments { get; set; }
       public List<Department> Departments { get; set; }

        public Paggination Paggination { get; set; }
    }
}