namespace TheStore.Site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialStoreModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdditionalAttributeValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Value = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.CategoryId })
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AttributeCategories",
                c => new
                    {
                        AttributeId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AttributeId, t.CategoryId })
                .ForeignKey("dbo.Attribute", t => t.AttributeId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.AttributeId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Attribute",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AttributeTranslations",
                c => new
                    {
                        AttributeId = c.Int(nullable: false),
                        Culture = c.String(nullable: false, maxLength: 5),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.AttributeId, t.Culture })
                .ForeignKey("dbo.Attribute", t => t.AttributeId, cascadeDelete: true)
                .Index(t => t.AttributeId);
            
            CreateTable(
                "dbo.AttributeValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AttributeId = c.Int(nullable: false),
                        Value = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Attribute", t => t.AttributeId, cascadeDelete: true)
                .Index(t => t.AttributeId);
            
            CreateTable(
                "dbo.ProductAttributeValues",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        AttributeValueId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.AttributeValueId })
                .ForeignKey("dbo.AttributeValues", t => t.AttributeValueId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.AttributeValueId);
            
            CreateTable(
                "dbo.AttributeValueTranslations",
                c => new
                    {
                        AttributeValueId = c.Int(nullable: false),
                        Culture = c.String(nullable: false, maxLength: 5),
                        Value = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.AttributeValueId, t.Culture })
                .ForeignKey("dbo.AttributeValues", t => t.AttributeValueId, cascadeDelete: true)
                .Index(t => t.AttributeValueId);
            
            CreateTable(
                "dbo.CategoryTranslations",
                c => new
                    {
                        CategoryId = c.Int(nullable: false),
                        Culture = c.String(nullable: false, maxLength: 5),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.CategoryId, t.Culture })
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.ProductPriceCurrencies",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        Currency = c.String(nullable: false, maxLength: 3),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.ProductId, t.Currency })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductTranslations",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        Culture = c.String(nullable: false, maxLength: 5),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => new { t.ProductId, t.Culture })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.AdditionalAttributeValueTranslations",
                c => new
                    {
                        AdditionalAttributeValueId = c.Int(nullable: false),
                        Culture = c.String(nullable: false, maxLength: 5),
                        Name = c.String(nullable: false),
                        Value = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.AdditionalAttributeValueId, t.Culture })
                .ForeignKey("dbo.AdditionalAttributeValues", t => t.AdditionalAttributeValueId, cascadeDelete: true)
                .Index(t => t.AdditionalAttributeValueId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        OrderDate = c.DateTime(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.OrderProducts",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ProductId })
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Subcategories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false),
                        SubcategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CategoryId, t.SubcategoryId })
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.Categories", t => t.SubcategoryId)
                .Index(t => t.CategoryId)
                .Index(t => t.SubcategoryId);
            
            CreateTable(
                "dbo.ProductVarieties",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        VarietyProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.VarietyProductId })
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.Products", t => t.VarietyProductId)
                .Index(t => t.ProductId)
                .Index(t => t.VarietyProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderProducts", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AdditionalAttributeValueTranslations", "AdditionalAttributeValueId", "dbo.AdditionalAttributeValues");
            DropForeignKey("dbo.ProductVarieties", "VarietyProductId", "dbo.Products");
            DropForeignKey("dbo.ProductVarieties", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductTranslations", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductPriceCurrencies", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductCategories", "ProductId", "dbo.Products");
            DropForeignKey("dbo.CategoryTranslations", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Subcategories", "SubcategoryId", "dbo.Categories");
            DropForeignKey("dbo.Subcategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.ProductCategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.AttributeCategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.AttributeValueTranslations", "AttributeValueId", "dbo.AttributeValues");
            DropForeignKey("dbo.ProductAttributeValues", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductAttributeValues", "AttributeValueId", "dbo.AttributeValues");
            DropForeignKey("dbo.AttributeValues", "AttributeId", "dbo.Attribute");
            DropForeignKey("dbo.AttributeTranslations", "AttributeId", "dbo.Attribute");
            DropForeignKey("dbo.AttributeCategories", "AttributeId", "dbo.Attribute");
            DropForeignKey("dbo.AdditionalAttributeValues", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductVarieties", new[] { "VarietyProductId" });
            DropIndex("dbo.ProductVarieties", new[] { "ProductId" });
            DropIndex("dbo.Subcategories", new[] { "SubcategoryId" });
            DropIndex("dbo.Subcategories", new[] { "CategoryId" });
            DropIndex("dbo.OrderProducts", new[] { "ProductId" });
            DropIndex("dbo.OrderProducts", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.AdditionalAttributeValueTranslations", new[] { "AdditionalAttributeValueId" });
            DropIndex("dbo.ProductTranslations", new[] { "ProductId" });
            DropIndex("dbo.ProductPriceCurrencies", new[] { "ProductId" });
            DropIndex("dbo.CategoryTranslations", new[] { "CategoryId" });
            DropIndex("dbo.AttributeValueTranslations", new[] { "AttributeValueId" });
            DropIndex("dbo.ProductAttributeValues", new[] { "AttributeValueId" });
            DropIndex("dbo.ProductAttributeValues", new[] { "ProductId" });
            DropIndex("dbo.AttributeValues", new[] { "AttributeId" });
            DropIndex("dbo.AttributeTranslations", new[] { "AttributeId" });
            DropIndex("dbo.AttributeCategories", new[] { "CategoryId" });
            DropIndex("dbo.AttributeCategories", new[] { "AttributeId" });
            DropIndex("dbo.ProductCategories", new[] { "CategoryId" });
            DropIndex("dbo.ProductCategories", new[] { "ProductId" });
            DropIndex("dbo.AdditionalAttributeValues", new[] { "ProductId" });
            DropTable("dbo.ProductVarieties");
            DropTable("dbo.Subcategories");
            DropTable("dbo.OrderProducts");
            DropTable("dbo.Orders");
            DropTable("dbo.AdditionalAttributeValueTranslations");
            DropTable("dbo.ProductTranslations");
            DropTable("dbo.ProductPriceCurrencies");
            DropTable("dbo.CategoryTranslations");
            DropTable("dbo.AttributeValueTranslations");
            DropTable("dbo.ProductAttributeValues");
            DropTable("dbo.AttributeValues");
            DropTable("dbo.AttributeTranslations");
            DropTable("dbo.Attribute");
            DropTable("dbo.AttributeCategories");
            DropTable("dbo.Categories");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Products");
            DropTable("dbo.AdditionalAttributeValues");
        }
    }
}
