namespace BookStore.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Code_First_Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AuthorName = c.String(),
                        Title = c.String(),
                        Edition = c.Int(nullable: false),
                        Summary = c.String(),
                        Description = c.String(),
                        PublicationDate = c.DateTime(nullable: false),
                        BasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductImageSource = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Journals",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IssueNumber = c.Int(nullable: false),
                        EditorName = c.String(),
                        Name = c.String(),
                        JournalFrequency = c.Int(nullable: false),
                        Description = c.String(),
                        PublicationDate = c.DateTime(nullable: false),
                        BasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductImageSource = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Journals");
            DropTable("dbo.Books");
        }
    }
}
