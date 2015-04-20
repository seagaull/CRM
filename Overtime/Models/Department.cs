using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Overtime.Models
{
    public class Department:AbstractData
    {

        public Department()
        {
            Staffs = new List<Staff>();
        }

        public ICollection<Staff> Staffs { get; set; }

    }

    public class DepartmentMapping : EntityTypeConfiguration<Department>
    {
        public DepartmentMapping()
        {
            this.ToTable("tbl_Departments")
                .HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(x => x.Name).HasColumnType("nvarchar").HasMaxLength(256);
            this.Property(x => x.CreatedBy).IsRequired();
            this.Property(x => x.CreatedTime).IsRequired();
            this.Property(x => x.ModifiedTime).IsOptional();
            this.Property(x => x.DeletedTime).IsOptional();
            this.HasMany(x => x.Staffs).WithRequired(x => x.Department)
                .HasForeignKey(x=>x.DepartmentId).WillCascadeOnDelete();
        }

    }
}