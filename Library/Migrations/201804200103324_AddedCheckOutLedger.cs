namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCheckOutLedger : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CheckOutLedgerEntries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        Timestamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .Index(t => t.BookID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CheckOutLedgerEntries", "BookID", "dbo.Books");
            DropIndex("dbo.CheckOutLedgerEntries", new[] { "BookID" });
            DropTable("dbo.CheckOutLedgerEntries");
        }
    }
}
