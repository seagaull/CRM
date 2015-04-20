using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using Overtime.Infrastructure;
using Overtime.Models;

namespace Overtime.Areas.Admin.ViewModel
{
    public class PositionsIndexVM
    {
        public ICollection<Position> Positions { get; set; }
        public Paggination Paggination { get; set; }

    }

    public class PositionOperationsVM
    {
        public int? Id { get; set; }

        [Display(Name = "الأسم"),
        Required(ErrorMessage = "يجب أدخال البيانات"),
        MaxLength(256, ErrorMessage = "الأسم طويل جدا")]
        public string Name { get; set; }

        public bool IsNew { get; set; }
    }

}