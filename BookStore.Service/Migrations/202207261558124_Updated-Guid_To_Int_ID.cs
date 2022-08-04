namespace BookStore.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedGuid_To_Int_ID : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Books");
            DropPrimaryKey("dbo.Journals");
            DropColumn("dbo.Books", "Id");
            DropColumn("dbo.Journals", "Id");
            AddColumn("dbo.Books", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Journals", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Books", "Id");
            AddPrimaryKey("dbo.Journals", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Journals");
            DropPrimaryKey("dbo.Books");
            AlterColumn("dbo.Journals", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Books", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Journals", "Id");
            AddPrimaryKey("dbo.Books", "Id");
        }
    }
}
