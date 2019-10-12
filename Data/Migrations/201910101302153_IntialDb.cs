namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        City = c.String(maxLength: 50),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Address = c.String(maxLength: 200),
                        Email = c.String(maxLength: 50),
                        PhoneNumber = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Deposits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Balance = c.Int(nullable: false),
                        AccountNumber = c.Int(nullable: false),
                        RegistrationDate = c.DateTime(),
                        CutomerId = c.Int(),
                        BranchId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .ForeignKey("dbo.Customers", t => t.CutomerId)
                .Index(t => t.CutomerId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.EmployeeBranches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CutomerId = c.Int(),
                        BranchId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branches", t => t.BranchId)
                .ForeignKey("dbo.Employees", t => t.CutomerId)
                .Index(t => t.CutomerId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeBranches", "CutomerId", "dbo.Employees");
            DropForeignKey("dbo.EmployeeBranches", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Deposits", "CutomerId", "dbo.Customers");
            DropForeignKey("dbo.Deposits", "BranchId", "dbo.Branches");
            DropIndex("dbo.EmployeeBranches", new[] { "BranchId" });
            DropIndex("dbo.EmployeeBranches", new[] { "CutomerId" });
            DropIndex("dbo.Deposits", new[] { "BranchId" });
            DropIndex("dbo.Deposits", new[] { "CutomerId" });
            DropTable("dbo.Employees");
            DropTable("dbo.EmployeeBranches");
            DropTable("dbo.Deposits");
            DropTable("dbo.Customers");
            DropTable("dbo.Branches");
        }
    }
}
