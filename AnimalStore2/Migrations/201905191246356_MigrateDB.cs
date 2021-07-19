namespace AnimalStore2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Animals", "OrderId", c => c.Int());
            CreateIndex("dbo.Animals", "OrderId");
            AddForeignKey("dbo.Animals", "OrderId", "dbo.Orders", "OrderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Animals", "OrderId", "dbo.Orders");
            DropIndex("dbo.Animals", new[] { "OrderId" });
            DropColumn("dbo.Animals", "OrderId");
        }
    }
}
