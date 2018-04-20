namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBookData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookDatas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AuthorID = c.Int(nullable: false),
                        GenreID = c.Int(nullable: false),
                        Title = c.String(),
                        YearPublished = c.Int(nullable: false),
                        ISBN = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Authors", t => t.AuthorID, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreID, cascadeDelete: true)
                .Index(t => t.AuthorID)
                .Index(t => t.GenreID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookDatas", "GenreID", "dbo.Genres");
            DropForeignKey("dbo.BookDatas", "AuthorID", "dbo.Authors");
            DropIndex("dbo.BookDatas", new[] { "GenreID" });
            DropIndex("dbo.BookDatas", new[] { "AuthorID" });
            DropTable("dbo.BookDatas");
        }
    }
}
