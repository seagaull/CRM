namespace Overtime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeenationalId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Employees", "ATMNum", c => c.String());
            AddColumn("dbo.tbl_Employees", "NationalId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Employees", "NationalId");
            DropColumn("dbo.tbl_Employees", "ATMNum");
        }
    }
}
