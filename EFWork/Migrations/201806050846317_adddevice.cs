namespace EFWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddevice : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.DeviceData");
            CreateTable(
                "dbo.Device",
                c => new
                    {
                        DeviceId = c.Int(nullable: false, identity: true),
                        DeviceName = c.String(),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DeviceId)
                .ForeignKey("dbo.DevcieType", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.DevcieType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.DeviceData", "DeviceId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.DeviceData", "DeviceId");
            CreateIndex("dbo.DeviceData", "DeviceId");
            AddForeignKey("dbo.DeviceData", "DeviceId", "dbo.Device", "DeviceId");
            DropColumn("dbo.DeviceData", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DeviceData", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Device", "TypeId", "dbo.DevcieType");
            DropForeignKey("dbo.DeviceData", "DeviceId", "dbo.Device");
            DropIndex("dbo.DeviceData", new[] { "DeviceId" });
            DropIndex("dbo.Device", new[] { "TypeId" });
            DropPrimaryKey("dbo.DeviceData");
            DropColumn("dbo.DeviceData", "DeviceId");
            DropTable("dbo.DevcieType");
            DropTable("dbo.Device");
            AddPrimaryKey("dbo.DeviceData", "Id");
        }
    }
}
