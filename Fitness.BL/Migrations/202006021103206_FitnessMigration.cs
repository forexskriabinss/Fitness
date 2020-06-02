﻿namespace Fitness.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FitnessMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CaloriesPerMinute = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Eatings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Moment = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        GenderId = c.Int(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Weight = c.Double(nullable: false),
                        Height = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genders", t => t.GenderId, cascadeDelete: true)
                .Index(t => t.GenderId);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Exercises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActivityId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Start = c.DateTime(nullable: false),
                        Finish = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Activities", t => t.ActivityId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ActivityId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Calories = c.Double(nullable: false),
                        Proteins = c.Double(nullable: false),
                        Fats = c.Double(nullable: false),
                        Carbohydrate = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exercises", "UserId", "dbo.Users");
            DropForeignKey("dbo.Exercises", "ActivityId", "dbo.Activities");
            DropForeignKey("dbo.Eatings", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "GenderId", "dbo.Genders");
            DropIndex("dbo.Exercises", new[] { "UserId" });
            DropIndex("dbo.Exercises", new[] { "ActivityId" });
            DropIndex("dbo.Users", new[] { "GenderId" });
            DropIndex("dbo.Eatings", new[] { "UserId" });
            DropTable("dbo.Foods");
            DropTable("dbo.Exercises");
            DropTable("dbo.Genders");
            DropTable("dbo.Users");
            DropTable("dbo.Eatings");
            DropTable("dbo.Activities");
        }
    }
}
