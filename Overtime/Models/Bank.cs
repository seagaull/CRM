using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Overtime.Models
{
    public class Bank : AbstractData
    {
        public Bank()
        {
            Brancheses = new List<BankBranche>();
        }

        public ICollection<BankBranche> Brancheses { get; set; }
    }

    public class BankMapping : EntityTypeConfiguration<Bank>
    {
        public BankMapping()
        {
            ToTable("tbl_Banks")
                .HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnType("nvarchar").HasMaxLength(350);
            Property(x => x.CreatedBy).IsRequired();
            Property(x => x.CreatedTime).IsRequired();
            Property(x => x.ModifiedTime).IsOptional();
            Property(x => x.DeletedTime).IsOptional();

            HasMany(x => x.Brancheses).WithRequired(x => x.Banks).HasForeignKey(x => x.BankId);
        }
    }
}