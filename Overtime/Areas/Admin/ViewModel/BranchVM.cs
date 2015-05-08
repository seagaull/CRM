using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Overtime.Models;

namespace Overtime.Areas.Admin.ViewModel
{
    public class BranchIndexVM
    {
        public BranchIndexVM()
        {
            Banks = new List<Bank>();
            Branches = new List<BankBranche>();
        }

        public IList<Bank> Banks { get; set; }
        public int? Selected { get; set; }
        public IList<BankBranche> Branches { get; set; }
    }

    public class BranchVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }


    public class BranchFormVM
    {
        public int? Id { get; set; }

        [Display(Name = "أسم الفرع")]
        [Required(ErrorMessage = "يجب أدخال اسم الفرع")]
        public string Name { get; set; }

        [Display(Name = "عنوان الفرع")]
        public string Address { get; set; }

        [Display(Name = "البنك")]
        public SelectList Banks { get; set; }

        [Required(ErrorMessage = "يجب أختيار بنك")]
        public int SelectedBankId { get; set; }

        public bool IsNew { get; set; }
    }
}