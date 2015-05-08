namespace Overtime.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterEmployeesCode : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_Employees", "Code", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_Employees", "Code", c => c.Int());
        }
    }
}
