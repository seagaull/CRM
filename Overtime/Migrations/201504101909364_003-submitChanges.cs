namespace Overtime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _003submitChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Roles", "CreatedBy", c => c.String(nullable: false));
            AddColumn("dbo.tbl_Roles", "CreatedTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.tbl_Roles", "ModifiedTime", c => c.DateTime());
            AddColumn("dbo.tbl_Roles", "DeletedTime", c => c.DateTime());
            AlterColumn("dbo.tbl_Banks", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("dbo.tbl_BankBranches", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("dbo.tbl_Staffs", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("dbo.tbl_Departments", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("dbo.tbl_Positions", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("dbo.tbl_Users", "Name", c => c.String());
            AlterColumn("dbo.tbl_Users", "CreatedBy", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_Users", "CreatedBy", c => c.Int());
            AlterColumn("dbo.tbl_Users", "Name", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.tbl_Positions", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.tbl_Departments", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.tbl_Staffs", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.tbl_BankBranches", "CreatedBy", c => c.Int(nullable: false));
            AlterColumn("dbo.tbl_Banks", "CreatedBy", c => c.Int(nullable: false));
            DropColumn("dbo.tbl_Roles", "DeletedTime");
            DropColumn("dbo.tbl_Roles", "ModifiedTime");
            DropColumn("dbo.tbl_Roles", "CreatedTime");
            DropColumn("dbo.tbl_Roles", "CreatedBy");
        }
    }
}
