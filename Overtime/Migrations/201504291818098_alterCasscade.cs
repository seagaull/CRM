namespace Overtime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterCasscade : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_EmplyeesBankDetails", "BranchId", "dbo.tbl_BankBranches");
            AddForeignKey("dbo.tbl_EmplyeesBankDetails", "BranchId", "dbo.tbl_BankBranches", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_EmplyeesBankDetails", "BranchId", "dbo.tbl_BankBranches");
            AddForeignKey("dbo.tbl_EmplyeesBankDetails", "BranchId", "dbo.tbl_BankBranches", "Id", cascadeDelete: true);
        }
    }
}
