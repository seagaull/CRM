namespace Overtime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _001_UserRoles : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_Users", "Name", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.tbl_Users", "Username");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_Users", "Username", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.tbl_Users", "Name", c => c.String());
        }
    }
}
