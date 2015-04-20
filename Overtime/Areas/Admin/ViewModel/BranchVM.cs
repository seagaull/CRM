using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages.Html;
using Overtime.Infrastructure;
using Overtime.Models;

namespace Overtime.Areas.Admin.ViewModel
{
    public class BranchIndexVM
    {

       // public SelectList Banks { get; set; }

      //  public int? Selected { get; set; }
        public IList<BranchVM> Branches { get; set; }

       // public Paggination Paggination { get; set; }
    
        public BranchIndexVM()
        {
            Branches=new List<BranchVM>();
        }
    }
    public class BranchVM
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
    }

}