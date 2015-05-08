namespace Overtime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterStafftoEmployees3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.tbl_Employees", new[] { "DepartmentId" });
            AlterColumn("dbo.tbl_Employees", "DepartmentId", c => c.Int());
            CreateIndex("dbo.tbl_Employees", "DepartmentId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.tbl_Employees", new[] { "DepartmentId" });
            AlterColumn("dbo.tbl_Employees", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.tbl_Employees", "DepartmentId");
        }
    }
}
