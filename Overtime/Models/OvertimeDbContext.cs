using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Overtime.Models
{
    public class OvertimeDbContext:DbContext
    {
        public OvertimeDbContext():base("name=MainDB")
        {
           Database.SetInitializer<OvertimeDbContext>(new CreateDatabaseIfNotExists<OvertimeDbContext>());
         
        }

        public  DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Bank> Banks { get; set; }

        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<BankBranche> Branches { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<SubPosition> SubPositions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          
            modelBuilder.Configurations.Add(new BankMapping());
            modelBuilder.Configurations.Add(new BankBrancheMapping());
            modelBuilder.Configurations.Add(new PositionMapping());
            modelBuilder.Configurations.Add(new DepartmentMapping());
            modelBuilder.Configurations.Add(new StaffMapping());
            modelBuilder.Configurations.Add(new RoleMapping());
            modelBuilder.Configurations.Add(new UserMapping()); 
            modelBuilder.Configurations.Add(new StaffPositionMapping());
            modelBuilder.Configurations.Add(new BankStaffDetailsMapping());
       
        }
    }
}