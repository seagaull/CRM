using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace Overtime.Models
{
    public class BankStaffsDetails
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
        public string AccountNumber { get; set; }
        public string Details { get; set; }

        public virtual Staff Staff { get; set; }
        public virtual BankBranche BankBranche { get; set; }

    }

    public class BankStaffDetailsMapping : EntityTypeConfiguration<BankStaffsDetails>
    {
        public BankStaffDetailsMapping()
        {
            this.ToTable("tbl_BankStaffDetails").HasKey(x => x.Id);
            this.Property(x => x.Id);
            this.Property(x => x.BranchId);
            this.HasRequired(x => x.BankBranche).WithMany(x => x.StaffDetailses).HasForeignKey(x=>x.BranchId);
            this.HasRequired(x => x.Staff).WithRequiredDependent(x => x.StaffDetails);
        }
    }
}