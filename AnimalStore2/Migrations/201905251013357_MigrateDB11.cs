namespace AnimalStore2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animals", "ImageData", c => c.Binary());
            AddColumn("dbo.Animals", "ImageMimeType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Animals", "ImageMimeType");
            DropColumn("dbo.Animals", "ImageData");
        }
    }
}
