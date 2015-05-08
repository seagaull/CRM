using System.Data.Entity.Migrations;

namespace Overtime.Migrations
{
    public partial class _201504101542351_Initialization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_Banks",
                c => new
                {
                    Id = c.Int(false, true),
                    Name = c.String(maxLength: 350),
                    CreatedBy = c.String(false),
                    CreatedTime = c.DateTime(false),
                    ModifiedTime = c.DateTime(),
                    DeletedTime = c.DateTime()
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.tbl_BankBranches",
                c => new
                {
                    Id = c.Int(false, true),
                    BankAddress = c.String(),
                    BankId = c.Int(false),
                    Name = c.String(),
                    CreatedBy = c.String(false),
                    CreatedTime = c.DateTime(false),
                    ModifiedTime = c.DateTime(),
                    DeletedTime = c.DateTime()
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tbl_Banks", t => t.BankId, true)
                .Index(t => t.BankId);

            CreateTable(
                "dbo.tbl_BankStaffDetails",
                c => new
                {
                    Id = c.Int(false),
                    BranchId = c.Int(false),
                    AccountNumber = c.String(),
                    Details = c.String()
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tbl_Staffs", t => t.Id)
                .ForeignKey("dbo.tbl_BankBranches", t => t.BranchId, true)
                .Index(t => t.Id)
                .Index(t => t.BranchId);

            CreateTable(
                "dbo.tbl_Staffs",
                c => new
                {
                    Id = c.Int(false, true),
                    Code = c.Int(),
                    DepartmentId = c.Int(false),
                    BankBranchId = c.Int(false),
                    Name = c.String(false, 256),
                    CreatedBy = c.String(false),
                    CreatedTime = c.DateTime(false),
                    ModifiedTime = c.DateTime(),
                    DeletedTime = c.DateTime()
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tbl_Departments", t => t.DepartmentId, true)
                .Index(t => t.DepartmentId);

            CreateTable(
                "dbo.tbl_Departments",
                c => new
                {
                    Id = c.Int(false, true),
                    Name = c.String(maxLength: 256),
                    CreatedBy = c.String(false),
                    CreatedTime = c.DateTime(false),
                    ModifiedTime = c.DateTime(),
                    DeletedTime = c.DateTime()
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.tbl_StaffPositions",
                c => new
                {
                    PositionId = c.Int(false),
                    StaffId = c.Int(false),
                    StartDate = c.DateTime(false)
                })
                .PrimaryKey(t => new {t.PositionId, t.StaffId})
                .ForeignKey("dbo.tbl_Staffs", t => t.StaffId, true)
                .ForeignKey("dbo.SubPositions", t => t.PositionId, true)
                .Index(t => t.PositionId)
                .Index(t => t.StaffId);

            CreateTable(
                "dbo.SubPositions",
                c => new
                {
                    Id = c.Int(false, true),
                    PositionId = c.Int(false),
                    Name = c.String(),
                    CreatedBy = c.String(),
                    CreatedTime = c.DateTime(false),
                    ModifiedTime = c.DateTime(),
                    DeletedTime = c.DateTime()
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tbl_Positions", t => t.PositionId, true)
                .Index(t => t.PositionId);

            CreateTable(
                "dbo.tbl_Positions",
                c => new
                {
                    Id = c.Int(false, true),
                    Name = c.String(maxLength: 256),
                    CreatedBy = c.String(false),
                    CreatedTime = c.DateTime(false),
                    ModifiedTime = c.DateTime(),
                    DeletedTime = c.DateTime()
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.tbl_Roles",
                c => new
                {
                    Id = c.Int(false, true),
                    Name = c.String(false, 128),
                    CreatedBy = c.String(false),
                    CreatedTime = c.DateTime(false),
                    ModifiedTime = c.DateTime(),
                    DeletedTime = c.DateTime()
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.tbl_Users",
                c => new
                {
                    Id = c.Int(false, true),
                    Passwordhash = c.String(false, 256),
                    Name = c.String(),
                    CreatedBy = c.String(),
                    CreatedTime = c.DateTime(false),
                    ModifiedTime = c.DateTime(),
                    DeletedTime = c.DateTime()
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.tbl_UsersRole",
                c => new
                {
                    UserId = c.Int(false),
                    RoleId = c.Int(false)
                })
                .PrimaryKey(t => new {t.UserId, t.RoleId})
                .ForeignKey("dbo.tbl_Users", t => t.UserId, true)
                .ForeignKey("dbo.tbl_Roles", t => t.RoleId, true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.tbl_UsersRole", "RoleId", "dbo.tbl_Roles");
            DropForeignKey("dbo.tbl_UsersRole", "UserId", "dbo.tbl_Users");
            DropForeignKey("dbo.tbl_BankBranches", "BankId", "dbo.tbl_Banks");
            DropForeignKey("dbo.tbl_BankStaffDetails", "BranchId", "dbo.tbl_BankBranches");
            DropForeignKey("dbo.tbl_StaffPositions", "PositionId", "dbo.SubPositions");
            DropForeignKey("dbo.SubPositions", "PositionId", "dbo.tbl_Positions");
            DropForeignKey("dbo.tbl_StaffPositions", "StaffId", "dbo.tbl_Staffs");
            DropForeignKey("dbo.tbl_BankStaffDetails", "Id", "dbo.tbl_Staffs");
            DropForeignKey("dbo.tbl_Staffs", "DepartmentId", "dbo.tbl_Departments");
            DropIndex("dbo.tbl_UsersRole", new[] {"RoleId"});
            DropIndex("dbo.tbl_UsersRole", new[] {"UserId"});
            DropIndex("dbo.SubPositions", new[] {"PositionId"});
            DropIndex("dbo.tbl_StaffPositions", new[] {"StaffId"});
            DropIndex("dbo.tbl_StaffPositions", new[] {"PositionId"});
            DropIndex("dbo.tbl_Staffs", new[] {"DepartmentId"});
            DropIndex("dbo.tbl_BankStaffDetails", new[] {"BranchId"});
            DropIndex("dbo.tbl_BankStaffDetails", new[] {"Id"});
            DropIndex("dbo.tbl_BankBranches", new[] {"BankId"});
            DropTable("dbo.tbl_UsersRole");
            DropTable("dbo.tbl_Users");
            DropTable("dbo.tbl_Roles");
            DropTable("dbo.tbl_Positions");
            DropTable("dbo.SubPositions");
            DropTable("dbo.tbl_StaffPositions");
            DropTable("dbo.tbl_Departments");
            DropTable("dbo.tbl_Staffs");
            DropTable("dbo.tbl_BankStaffDetails");
            DropTable("dbo.tbl_BankBranches");
            DropTable("dbo.tbl_Banks");
        }
    }
}