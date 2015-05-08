namespace Overtime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterCasscade2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_EmplyeesBankDetails", "Id", "dbo.tbl_Employees");
            AddForeignKey("dbo.tbl_EmplyeesBankDetails", "Id", "dbo.tbl_Employees", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_EmplyeesBankDetails", "Id", "dbo.tbl_Employees");
            AddForeignKey("dbo.tbl_EmplyeesBankDetails", "Id", "dbo.tbl_Employees", "Id");
        }
    }
}
