namespace Furniture.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Advertisement",
                c => new
                    {
                        Advertisement_ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        C_Description = c.String(maxLength: 500),
                        C_Image = c.String(maxLength: 500),
                        C_Type = c.Int(nullable: false),
                        Link = c.String(maxLength: 500),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Advertisement_ID);
            
            CreateTable(
                "dbo._Order",
                c => new
                    {
                        C_Order_ID = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        CustomerName = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        C_Address = c.String(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.C_Order_ID);
            
            CreateTable(
                "dbo.Order_Details",
                c => new
                    {
                        Order_Details_ID = c.Int(nullable: false, identity: true),
                        C_Order_ID = c.Int(nullable: false),
                        C_Product_ID = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Order_Details_ID)
                .ForeignKey("dbo._Order", t => t.C_Order_ID, cascadeDelete: true)
                .ForeignKey("dbo.C_Product", t => t.C_Product_ID, cascadeDelete: true)
                .Index(t => t.C_Order_ID)
                .Index(t => t.C_Product_ID);
            
            CreateTable(
                "dbo.C_Product",
                c => new
                    {
                        C_Product_ID = c.Int(nullable: false, identity: true),
                        Product_Category_ID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 250),
                        ProductCode = c.String(),
                        C_Description = c.String(),
                        Detail = c.String(),
                        C_Image = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PriceSale = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        IsHome = c.Boolean(nullable: false),
                        IsFeature = c.Boolean(nullable: false),
                        IsHot = c.Boolean(nullable: false),
                        IsSale = c.Boolean(nullable: false),
                        SeoTitle = c.String(),
                        SeoDescription = c.String(),
                        SeoKeywords = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.C_Product_ID)
                .ForeignKey("dbo.Product_Category", t => t.Product_Category_ID, cascadeDelete: true)
                .Index(t => t.Product_Category_ID);
            
            CreateTable(
                "dbo.Product_Category",
                c => new
                    {
                        Product_Category_ID = c.Int(nullable: false, identity: true),
                        Category_ID = c.Int(nullable: false),
                        Title = c.String(),
                        C_Description = c.String(),
                        Icon = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Product_Category_ID)
                .ForeignKey("dbo.Category", t => t.Category_ID, cascadeDelete: true)
                .Index(t => t.Category_ID);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Category_ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        C_Description = c.String(),
                        Position = c.Int(nullable: false),
                        SeoTitle = c.String(),
                        SeoDescription = c.String(),
                        SeoKeywords = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Category_ID);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        News_ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Category_ID = c.Int(nullable: false),
                        C_Description = c.String(),
                        Detail = c.String(),
                        C_Image = c.String(),
                        SeoTitle = c.String(),
                        SeoDescription = c.String(),
                        SeoKeywords = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.News_ID)
                .ForeignKey("dbo.Category", t => t.Category_ID, cascadeDelete: true)
                .Index(t => t.Category_ID);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        Posts_ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 150),
                        Category_ID = c.Int(),
                        C_Description = c.String(),
                        Detail = c.String(),
                        C_Image = c.String(),
                        SeoTitle = c.String(),
                        SeoDescription = c.String(),
                        SeoKeywords = c.String(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Posts_ID)
                .ForeignKey("dbo.Category", t => t.Category_ID)
                .Index(t => t.Category_ID);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        Contact_ID = c.Int(nullable: false, identity: true),
                        C_Name = c.String(nullable: false, maxLength: 150),
                        Website = c.String(),
                        Email = c.String(maxLength: 150),
                        C_Message = c.String(maxLength: 4000),
                        IsRead = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.String(),
                    })
                .PrimaryKey(t => t.Contact_ID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Subscribe",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.System_Setting",
                c => new
                    {
                        SettingKey = c.String(nullable: false, maxLength: 50),
                        SettingValue = c.String(maxLength: 4000),
                        SettingDescription = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.SettingKey);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Fullname = c.String(),
                        Phone = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Product_Category", "Category_ID", "dbo.Category");
            DropForeignKey("dbo.Post", "Category_ID", "dbo.Category");
            DropForeignKey("dbo.News", "Category_ID", "dbo.Category");
            DropForeignKey("dbo.C_Product", "Product_Category_ID", "dbo.Product_Category");
            DropForeignKey("dbo.Order_Details", "C_Product_ID", "dbo.C_Product");
            DropForeignKey("dbo.Order_Details", "C_Order_ID", "dbo._Order");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Post", new[] { "Category_ID" });
            DropIndex("dbo.News", new[] { "Category_ID" });
            DropIndex("dbo.Product_Category", new[] { "Category_ID" });
            DropIndex("dbo.C_Product", new[] { "Product_Category_ID" });
            DropIndex("dbo.Order_Details", new[] { "C_Product_ID" });
            DropIndex("dbo.Order_Details", new[] { "C_Order_ID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.System_Setting");
            DropTable("dbo.Subscribe");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Contact");
            DropTable("dbo.Post");
            DropTable("dbo.News");
            DropTable("dbo.Category");
            DropTable("dbo.Product_Category");
            DropTable("dbo.C_Product");
            DropTable("dbo.Order_Details");
            DropTable("dbo._Order");
            DropTable("dbo.Advertisement");
        }
    }
}
