using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Overtime.Models
{
    public class BankBranche : AbstractData
    {
        public BankBranche()
        {
            StaffDetailses = new List<EmplyeesBankDetails>();
        }

        public string BankAddress { get; set; }
        public int BankId { get; set; }
        public Bank Banks { get; set; }
        public ICollection<EmplyeesBankDetails> StaffDetailses { get; set; }
    }

    public class BankBrancheMapping : EntityTypeConfiguration<BankBranche>
    {
        public BankBrancheMapping()
        {
            ToTable("tbl_BankBranches")
                .HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name);
            Property(x => x.CreatedBy).IsRequired();
            Property(x => x.CreatedTime).IsRequired();
            Property(x => x.ModifiedTime).IsOptional();
            Property(x => x.DeletedTime).IsOptional();
            Property(x => x.BankAddress).IsOptional();
            Property(x => x.BankId).IsRequired();
            HasMany(x => x.StaffDetailses).WithOptional(x => x.BankBranche);
        }
    }
}