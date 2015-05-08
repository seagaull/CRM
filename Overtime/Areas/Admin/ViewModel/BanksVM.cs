using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Overtime.Infrastructure;
using Overtime.Models;

namespace Overtime.Areas.Admin.ViewModel
{
    public class BanksVMIndex
    {
        public IList<Bank> Banks { get; set; }
        public Paggination Paggination { get; set; }
    }


    public class BankFormsVM
    {
        public int? Id { get; set; }

        [Display(Name = "أسم البنك")]
        [Required]
        public string Name { get; set; }

        public bool IsNew { get; set; }
    }
}