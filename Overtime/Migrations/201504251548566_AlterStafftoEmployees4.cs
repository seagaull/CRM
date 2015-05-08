namespace Overtime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterStafftoEmployees4 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.tbl_EmplyeesBankDetails", new[] { "BranchId" });
            AlterColumn("dbo.tbl_EmplyeesBankDetails", "BranchId", c => c.Int());
            CreateIndex("dbo.tbl_EmplyeesBankDetails", "BranchId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.tbl_EmplyeesBankDetails", new[] { "BranchId" });
            AlterColumn("dbo.tbl_EmplyeesBankDetails", "BranchId", c => c.Int(nullable: false));
            CreateIndex("dbo.tbl_EmplyeesBankDetails", "BranchId");
        }
    }
}
