using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Overtime.Models;

namespace Overtime.ViewModel
{
    public class UserLogin
    {


        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string PasswoedHash { get; set; }
        public bool RemomeberMe { get; set; }

    }
}