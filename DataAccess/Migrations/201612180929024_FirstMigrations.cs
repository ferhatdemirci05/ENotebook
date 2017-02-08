namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gender",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 10, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Note",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NotebookID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 20, unicode: false),
                        Description = c.String(maxLength: 5000, unicode: false),
                        DateOfCration = c.DateTime(nullable: false),
                        Hit = c.Int(nullable: false),
                        Flag = c.Boolean(nullable: false),
                        Share = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Notebook", t => t.NotebookID, cascadeDelete: true)
                .Index(t => t.NotebookID);
            
            CreateTable(
                "dbo.Notebook",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        DateOfCration = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 20, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 50, unicode: false),
                        GenderID = c.Int(nullable: false),
                        EMail = c.String(nullable: false, maxLength: 100, unicode: false),
                        Password = c.String(nullable: false, maxLength: 32, unicode: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Gender", t => t.GenderID)
                .Index(t => t.GenderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Note", "NotebookID", "dbo.Notebook");
            DropForeignKey("dbo.Notebook", "UserID", "dbo.User");
            DropForeignKey("dbo.User", "GenderID", "dbo.Gender");
            DropIndex("dbo.User", new[] { "GenderID" });
            DropIndex("dbo.Notebook", new[] { "UserID" });
            DropIndex("dbo.Note", new[] { "NotebookID" });
            DropTable("dbo.User");
            DropTable("dbo.Notebook");
            DropTable("dbo.Note");
            DropTable("dbo.Gender");
        }
    }
}
