namespace EFWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menu", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoleProject",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.ProjectId })
                .ForeignKey("dbo.Project", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ParentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Project", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.RoleMenu",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        MenuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.MenuId })
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Menu", t => t.MenuId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.MenuId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoleProject", "RoleId", "dbo.Role");
            DropForeignKey("dbo.RoleProject", "ProjectId", "dbo.Project");
            DropForeignKey("dbo.Project", "ParentId", "dbo.Project");
            DropForeignKey("dbo.RoleMenu", "MenuId", "dbo.Menu");
            DropForeignKey("dbo.RoleMenu", "RoleId", "dbo.Role");
            DropForeignKey("dbo.Menu", "ParentId", "dbo.Menu");
            DropIndex("dbo.RoleMenu", new[] { "MenuId" });
            DropIndex("dbo.RoleMenu", new[] { "RoleId" });
            DropIndex("dbo.Project", new[] { "ParentId" });
            DropIndex("dbo.RoleProject", new[] { "ProjectId" });
            DropIndex("dbo.RoleProject", new[] { "RoleId" });
            DropIndex("dbo.Menu", new[] { "ParentId" });
            DropTable("dbo.RoleMenu");
            DropTable("dbo.Project");
            DropTable("dbo.RoleProject");
            DropTable("dbo.Role");
            DropTable("dbo.Menu");
        }
    }
}
