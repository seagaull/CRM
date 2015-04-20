using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Overtime.Models
{
    public class Bank:AbstractData
    {
        
     
      

        public ICollection<BankBranche> Brancheses { get; set; }

        public Bank()
        {
            Brancheses= new List<BankBranche>();
        }

    }

    public class BankMapping: EntityTypeConfiguration<Bank>
    {
        public BankMapping()
        {
            this.ToTable("tbl_Banks")
                .HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Name).HasColumnType("nvarchar").HasMaxLength(350);
            this.Property(x => x.CreatedBy).IsRequired();
            this.Property(x => x.CreatedTime).IsRequired();
            this.Property(x => x.ModifiedTime).IsOptional();
            this.Property(x => x.DeletedTime).IsOptional();

            this.HasMany(x => x.Brancheses).WithRequired(x => x.Banks).HasForeignKey(x=>x.BankId);

        }
        

    }
}