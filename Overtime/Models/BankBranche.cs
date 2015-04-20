using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Overtime.Models
{
    public class BankBranche:AbstractData
    {
       
        public string BankAddress { get; set; }

        public int BankId  { get; set; }
        public Bank Banks { get; set; }

        public ICollection<BankStaffsDetails> StaffDetailses { get; set; }

        public BankBranche()
        {
            StaffDetailses = new List<BankStaffsDetails>();
        }

    }

    public class BankBrancheMapping : EntityTypeConfiguration<BankBranche>
    {
        public BankBrancheMapping()
        {
            this.ToTable("tbl_BankBranches")
                .HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Name);
            this.Property(x => x.CreatedBy).IsRequired();
            this.Property(x => x.CreatedTime).IsRequired();
            this.Property(x => x.ModifiedTime).IsOptional();
            this.Property(x => x.DeletedTime).IsOptional();
            this.Property(x => x.BankAddress).IsOptional();
            this.Property(x => x.BankId).IsRequired();
            this.HasMany(x => x.StaffDetailses).WithRequired(x => x.BankBranche);

        }
    }
}