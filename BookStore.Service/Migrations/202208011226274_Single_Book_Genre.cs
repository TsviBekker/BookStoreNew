namespace BookStore.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Single_Book_Genre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Genre", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Genre");
        }
    }
}
