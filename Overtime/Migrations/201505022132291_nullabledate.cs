namespace Overtime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullabledate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_StaffPositions", "StartDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_StaffPositions", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
