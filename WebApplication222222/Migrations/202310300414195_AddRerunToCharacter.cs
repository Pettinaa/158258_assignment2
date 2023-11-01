namespace WebApplication222222.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRerunToCharacter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Characters", "Rerun", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Characters", "Rerun");
        }
    }
}
