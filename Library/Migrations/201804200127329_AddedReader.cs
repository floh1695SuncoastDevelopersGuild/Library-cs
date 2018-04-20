namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedReader : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Readers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.CheckOutLedgerEntries", "ReaderID", c => c.Int(nullable: false));
            CreateIndex("dbo.CheckOutLedgerEntries", "ReaderID");
            AddForeignKey("dbo.CheckOutLedgerEntries", "ReaderID", "dbo.Readers", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CheckOutLedgerEntries", "ReaderID", "dbo.Readers");
            DropIndex("dbo.CheckOutLedgerEntries", new[] { "ReaderID" });
            DropColumn("dbo.CheckOutLedgerEntries", "ReaderID");
            DropTable("dbo.Readers");
        }
    }
}
