namespace AnimalStore2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Animals", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Animals", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Animals", "Breed", c => c.String(nullable: false));
            AlterColumn("dbo.Animals", "ColorOfAnimal", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Animals", "ColorOfAnimal", c => c.String());
            AlterColumn("dbo.Animals", "Breed", c => c.String());
            AlterColumn("dbo.Animals", "Description", c => c.String());
            AlterColumn("dbo.Animals", "Name", c => c.String());
        }
    }
}
