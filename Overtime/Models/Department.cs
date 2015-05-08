using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Overtime.Models
{
    public class Department : AbstractData
    {
        public Department()
        {
            Employees = new List<Employee>();
        }

        public ICollection<Employee> Employees { get; set; }
    }

    public class DepartmentMapping : EntityTypeConfiguration<Department>
    {
        public DepartmentMapping()
        {
            ToTable("tbl_Departments")
                .HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name).HasColumnType("nvarchar").HasMaxLength(256);
            Property(x => x.CreatedBy).IsRequired();
            Property(x => x.CreatedTime).IsRequired();
            Property(x => x.ModifiedTime).IsOptional();
            Property(x => x.DeletedTime).IsOptional();
            HasMany(x => x.Employees).WithOptional(x => x.Department)
                .HasForeignKey(x => x.DepartmentId).WillCascadeOnDelete();
        }
    }
}