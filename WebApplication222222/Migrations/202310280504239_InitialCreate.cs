﻿namespace WebApplication222222.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Nationslity = c.String(),
                        ElementID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Elements", t => t.ElementID)
                .Index(t => t.ElementID);
            
            CreateTable(
                "dbo.Elements",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Characters", "ElementID", "dbo.Elements");
            DropIndex("dbo.Characters", new[] { "ElementID" });
            DropTable("dbo.Elements");
            DropTable("dbo.Characters");
        }
    }
}
