namespace CRUDModal.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ot : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DataOvertimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Status = c.String(),
                        Price = c.Int(nullable: false),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Employees_Id = c.Int(),
                        OvertimeTypes_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employees_Id)
                .ForeignKey("dbo.OvertimeTypes", t => t.OvertimeTypes_Id)
                .Index(t => t.Employees_Id)
                .Index(t => t.OvertimeTypes_Id);
            
            CreateTable(
                "dbo.OvertimeTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Hours = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DataOvertimes", "OvertimeTypes_Id", "dbo.OvertimeTypes");
            DropForeignKey("dbo.DataOvertimes", "Employees_Id", "dbo.Employees");
            DropIndex("dbo.DataOvertimes", new[] { "OvertimeTypes_Id" });
            DropIndex("dbo.DataOvertimes", new[] { "Employees_Id" });
            DropTable("dbo.OvertimeTypes");
            DropTable("dbo.DataOvertimes");
        }
    }
}
