namespace Overtime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeGender : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Employees", "Gender", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Employees", "Gender");
        }
    }
}
