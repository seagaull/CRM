using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Overtime.Models
{
    public class Role:AbstractData
    {

        public ICollection<User> Users { get; set; }


    }



    public class RoleMapping : EntityTypeConfiguration<Role>
    {
        public RoleMapping()
        {
            this.ToTable("tbl_Roles")
                .HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnType("nvarchar").HasMaxLength(128).IsRequired();
            this.Property(x => x.CreatedBy).IsRequired();
            this.Property(x => x.CreatedTime).IsRequired();
            this.Property(x => x.ModifiedTime).IsOptional();
            this.Property(x => x.DeletedTime).IsOptional();
          
            
        }
    }
}