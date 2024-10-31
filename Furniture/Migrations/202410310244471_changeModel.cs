namespace Furniture.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Post", "Alias", c => c.String(maxLength: 150));
            AlterColumn("dbo.Post", "C_Image", c => c.String(maxLength: 250));
            AlterColumn("dbo.Post", "SeoTitle", c => c.String(maxLength: 250));
            AlterColumn("dbo.Post", "SeoDescription", c => c.String(maxLength: 500));
            AlterColumn("dbo.Post", "SeoKeywords", c => c.String(maxLength: 250));
            AlterColumn("dbo._Product", "Title", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo._Product", "Alias", c => c.String(maxLength: 150));
            AlterColumn("dbo._Product", "ProductCode", c => c.String(maxLength: 50));
            AlterColumn("dbo._Product", "C_Image", c => c.String(maxLength: 250));
            AlterColumn("dbo._Product", "SeoTitle", c => c.String(maxLength: 250));
            AlterColumn("dbo._Product", "SeoDescription", c => c.String(maxLength: 500));
            AlterColumn("dbo._Product", "SeoKeywords", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo._Product", "SeoKeywords", c => c.String());
            AlterColumn("dbo._Product", "SeoDescription", c => c.String());
            AlterColumn("dbo._Product", "SeoTitle", c => c.String());
            AlterColumn("dbo._Product", "C_Image", c => c.String());
            AlterColumn("dbo._Product", "ProductCode", c => c.String());
            AlterColumn("dbo._Product", "Alias", c => c.String());
            AlterColumn("dbo._Product", "Title", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Post", "SeoKeywords", c => c.String());
            AlterColumn("dbo.Post", "SeoDescription", c => c.String());
            AlterColumn("dbo.Post", "SeoTitle", c => c.String());
            AlterColumn("dbo.Post", "C_Image", c => c.String());
            AlterColumn("dbo.Post", "Alias", c => c.String());
        }
    }
}
