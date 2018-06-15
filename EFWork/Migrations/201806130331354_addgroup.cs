namespace EFWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addgroup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeviceTypeTemplate",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TemplateName = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        BStandard = c.Boolean(nullable: false),
                        Token = c.String(nullable: false, maxLength: 128),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DevcieType", t => t.TypeId, cascadeDelete: true)
                .ForeignKey("dbo.Group", t => t.Token, cascadeDelete: true)
                .Index(t => t.Token)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        Token = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.Token);
            
            CreateTable(
                "dbo.TypeDefine",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataKey = c.String(),
                        DataName = c.String(),
                        Unit = c.String(),
                        DataType = c.String(),
                        DefaultValue = c.String(),
                        TemplateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DeviceTypeTemplate", t => t.TemplateId, cascadeDelete: true)
                .Index(t => t.TemplateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TypeDefine", "TemplateId", "dbo.DeviceTypeTemplate");
            DropForeignKey("dbo.DeviceTypeTemplate", "Token", "dbo.Group");
            DropForeignKey("dbo.DeviceTypeTemplate", "TypeId", "dbo.DevcieType");
            DropIndex("dbo.TypeDefine", new[] { "TemplateId" });
            DropIndex("dbo.DeviceTypeTemplate", new[] { "TypeId" });
            DropIndex("dbo.DeviceTypeTemplate", new[] { "Token" });
            DropTable("dbo.TypeDefine");
            DropTable("dbo.Group");
            DropTable("dbo.DeviceTypeTemplate");
        }
    }
}
