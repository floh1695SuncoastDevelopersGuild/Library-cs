namespace Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNullableDates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authors", "Born", c => c.DateTime());
            AlterColumn("dbo.Authors", "Died", c => c.DateTime());
            AlterColumn("dbo.Books", "DueBackDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Books", "DueBackDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Authors", "Died", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Authors", "Born", c => c.DateTime(nullable: false));
        }
    }
}
