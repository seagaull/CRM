using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Overtime.Models
{
    public class Staff:AbstractData
    {
   
        public int Code { get; set; }
        public int DepartmentId { get; set; }



        public int BankBranchId { get; set; }
        public virtual BankStaffsDetails StaffDetails { get; set; }
        public virtual ICollection<StaffPosition> Position { get; set; }
        public virtual  Department Department { get; set; }
    }

    public class StaffMapping : EntityTypeConfiguration<Staff>
    {
        public StaffMapping()
        {
            this.ToTable("tbl_Staffs")
                .HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(x => x.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(256)
                .IsRequired();
            this.Property(x => x.CreatedBy).IsRequired();
            this.Property(x => x.CreatedTime).IsRequired();
            this.Property(x => x.ModifiedTime).IsOptional();
            this.Property(x => x.DeletedTime).IsOptional();
          
            this.Property(x => x.DepartmentId).IsRequired();
         
            this.Property(x => x.Code).IsOptional();

            this.Property(x => x.BankBranchId).IsRequired();
            this.HasRequired(x => x.Department).WithMany(t => t.Staffs);

            this.HasRequired(x => x.StaffDetails).WithRequiredPrincipal(x => x.Staff);
 
        }
    }
}