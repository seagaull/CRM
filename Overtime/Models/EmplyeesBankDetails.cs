using System;
using System.Data.Entity.ModelConfiguration;

namespace Overtime.Models
{
    public class EmplyeesBankDetails
    {
        public int Id { get; set; }
        public int? BranchId { get; set; }
        public string AccountNumber { get; set; }
        public string Details { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual BankBranche BankBranche { get; set; }
    }

    public class EmployeeBankDetailsMapping : EntityTypeConfiguration<EmplyeesBankDetails>
    {
        public EmployeeBankDetailsMapping()
        {
            ToTable("tbl_EmplyeesBankDetails").HasKey(x => x.Id);
            Property(x => x.Id);
            Property(x => x.BranchId).IsOptional();

            HasOptional(x => x.BankBranche)
                .WithMany(x => x.StaffDetailses)
                .HasForeignKey(x => x.BranchId)
                .WillCascadeOnDelete(false);
            


            HasRequired(x => x.Employee)
                .WithRequiredDependent(x => x.StaffDetails).WillCascadeOnDelete();
        }
    }
}