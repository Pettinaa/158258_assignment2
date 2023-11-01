namespace WebApplication222222.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyMigrationName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Characters", "Nationality", c => c.String());
            DropColumn("dbo.Characters", "Nationslity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Characters", "Nationslity", c => c.String());
            DropColumn("dbo.Characters", "Nationality");
        }
    }
}
