namespace EFWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataaddname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DeviceData", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DeviceData", "Name");
        }
    }
}
