namespace BookStore.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Single_Journal_Genre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Journals", "Genre", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Journals", "Genre");
        }
    }
}
