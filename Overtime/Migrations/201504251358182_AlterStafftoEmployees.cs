namespace Overtime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterStafftoEmployees : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.tbl_BankStaffDetails", newName: "tbl_EmplyeesBankDetails");
            RenameTable(name: "dbo.tbl_Staffs", newName: "tbl_Employees");
            AddColumn("dbo.tbl_Employees", "ATM", c => c.Boolean());
            AddColumn("dbo.tbl_Employees", "Phone", c => c.String());
            AddColumn("dbo.tbl_Employees", "Address", c => c.String());
            AddColumn("dbo.tbl_Employees", "Email", c => c.String());
            DropColumn("dbo.tbl_Employees", "BankBranchId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_Employees", "BankBranchId", c => c.Int(nullable: false));
            DropColumn("dbo.tbl_Employees", "Email");
            DropColumn("dbo.tbl_Employees", "Address");
            DropColumn("dbo.tbl_Employees", "Phone");
            DropColumn("dbo.tbl_Employees", "ATM");
            RenameTable(name: "dbo.tbl_Employees", newName: "tbl_Staffs");
            RenameTable(name: "dbo.tbl_EmplyeesBankDetails", newName: "tbl_BankStaffDetails");
        }
    }
}
