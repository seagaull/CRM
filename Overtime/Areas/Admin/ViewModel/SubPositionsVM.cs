using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Overtime.Models;

namespace Overtime.Areas.Admin.ViewModel
{
    public class SubPositionsIndexVM
    {
        public SelectList Positions { get; set; }
        public int SelectedPosition { get; set; }
        private List<SubPosition> SubPositions { get; set; }
    }

    public class SubPositionsFormVM
    {
        public SelectList Positions { get; set; }

        [Required(ErrorMessage = "يجب أن تختار نوع الظيفة")]
        public int SelectedPosition { get; set; }

        public int? Id { get; set; }

        [Display(Name = "الدرجة الوظيفية")]
        [Required(ErrorMessage = "يجب أدخال الدرجة الوظيفية")]
        public string Name { get; set; }

        public bool IsNew { get; set; }
    }
}