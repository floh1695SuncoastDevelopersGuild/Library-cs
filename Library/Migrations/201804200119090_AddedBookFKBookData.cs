namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBookFKBookData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "BookDataID", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "BookDataID");
            AddForeignKey("dbo.Books", "BookDataID", "dbo.BookDatas", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "BookDataID", "dbo.BookDatas");
            DropIndex("dbo.Books", new[] { "BookDataID" });
            DropColumn("dbo.Books", "BookDataID");
        }
    }
}
