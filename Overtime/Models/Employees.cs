using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Overtime.Models
{
    public class Employee : AbstractData
    {
        public Employee()
        {
            SubPositions = new List<StaffPosition>();
        }

        public string Gender { get; set; }
        public string Code { get; set; }
        public bool ATM { get; set; }
        public string ATMNum { get; set; }
        public string NationalId { get; set; }
        public int? DepartmentId { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        
        public virtual EmplyeesBankDetails StaffDetails { get; set; }
        public virtual ICollection<StaffPosition> SubPositions { get; set; }

        public virtual Department Department { get; set; }
    }

    public class EmployeeMapping : EntityTypeConfiguration<Employee>
    {
        public EmployeeMapping()
        {
            ToTable("tbl_Employees")
                .HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(256)
                .IsRequired();
            Property(x => x.CreatedBy).IsRequired();
            Property(x => x.CreatedTime).IsRequired();
            Property(x => x.ModifiedTime).IsOptional();
            Property(x => x.DeletedTime).IsOptional();
            Property(x => x.Gender).IsRequired();
            Property(x => x.DepartmentId).IsOptional();
            Property(x => x.NationalId).IsOptional();
            Property(x => x.ATMNum).IsOptional();
            Property(x => x.Code).IsOptional();

            Property(x => x.ATM).IsOptional();
            Property(x => x.Address).IsOptional();
            Property(x => x.Phone).IsOptional();
            Property(x => x.Email).IsOptional();
            HasOptional(x => x.Department).WithMany(t => t.Employees);

            HasRequired(x => x.StaffDetails).WithRequiredPrincipal(x => x.Employee);
        }
    }
}