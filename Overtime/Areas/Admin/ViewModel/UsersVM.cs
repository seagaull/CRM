using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Overtime.Infrastructure;
using Overtime.Models;

namespace Overtime.Areas.Admin.ViewModel
{

    public class RolesCheckBox
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Checked { get; set; }

    }

    public class UserForm
    {
        public bool IsNew { get; set; }
        public int Id { get; set; }
        [Display(Name = "الأسم")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "كلمة المرور")]
        [Required]
        public string Password { get; set; }
        public IList<RolesCheckBox> Roles { get; set; }

        public UserForm()
        {
            Roles = new List<RolesCheckBox>();
        }
    }

    public class UsersIndexVM
    {
        public List<User> Users { get; set; }
        public Paggination Paggination { get; set; }
    }


    public class ResetPasswordVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}