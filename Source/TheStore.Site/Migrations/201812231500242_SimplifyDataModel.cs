namespace TheStore.Site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SimplifyDataModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AdditionalAttributeValues", "ProductId", "dbo.Products");
            DropForeignKey("dbo.AttributeCategories", "AttributeId", "dbo.Attributes");
            DropForeignKey("dbo.AttributeTranslations", "AttributeId", "dbo.Attributes");
            DropForeignKey("dbo.AttributeValueTranslations", "AttributeValueId", "dbo.AttributeValues");
            DropForeignKey("dbo.AttributeCategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.CategoryTranslations", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.ProductPriceCurrencies", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductTranslations", "ProductId", "dbo.Products");
            DropForeignKey("dbo.AdditionalAttributeValueTranslations", "AdditionalAttributeValueId", "dbo.AdditionalAttributeValues");
            DropIndex("dbo.AdditionalAttributeValues", new[] { "ProductId" });
            DropIndex("dbo.AttributeCategories", new[] { "AttributeId" });
            DropIndex("dbo.AttributeCategories", new[] { "CategoryId" });
            DropIndex("dbo.AttributeTranslations", new[] { "AttributeId" });
            DropIndex("dbo.AttributeValueTranslations", new[] { "AttributeValueId" });
            DropIndex("dbo.CategoryTranslations", new[] { "CategoryId" });
            DropIndex("dbo.ProductPriceCurrencies", new[] { "ProductId" });
            DropIndex("dbo.ProductTranslations", new[] { "ProductId" });
            DropIndex("dbo.AdditionalAttributeValueTranslations", new[] { "AdditionalAttributeValueId" });
            DropTable("dbo.AdditionalAttributeValues");
            DropTable("dbo.AttributeCategories");
            DropTable("dbo.AttributeTranslations");
            DropTable("dbo.AttributeValueTranslations");
            DropTable("dbo.CategoryTranslations");
            DropTable("dbo.ProductPriceCurrencies");
            DropTable("dbo.ProductTranslations");
            DropTable("dbo.AdditionalAttributeValueTranslations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AdditionalAttributeValueTranslations",
                c => new
                    {
                        AdditionalAttributeValueId = c.Int(nullable: false),
                        Culture = c.String(nullable: false, maxLength: 5),
                        Name = c.String(nullable: false),
                        Value = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.AdditionalAttributeValueId, t.Culture });
            
            CreateTable(
                "dbo.ProductTranslations",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        Culture = c.String(nullable: false, maxLength: 5),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => new { t.ProductId, t.Culture });
            
            CreateTable(
                "dbo.ProductPriceCurrencies",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        Currency = c.String(nullable: false, maxLength: 3),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.ProductId, t.Currency });
            
            CreateTable(
                "dbo.CategoryTranslations",
                c => new
                    {
                        CategoryId = c.Int(nullable: false),
                        Culture = c.String(nullable: false, maxLength: 5),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.CategoryId, t.Culture });
            
            CreateTable(
                "dbo.AttributeValueTranslations",
                c => new
                    {
                        AttributeValueId = c.Int(nullable: false),
                        Culture = c.String(nullable: false, maxLength: 5),
                        Value = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.AttributeValueId, t.Culture });
            
            CreateTable(
                "dbo.AttributeTranslations",
                c => new
                    {
                        AttributeId = c.Int(nullable: false),
                        Culture = c.String(nullable: false, maxLength: 5),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.AttributeId, t.Culture });
            
            CreateTable(
                "dbo.AttributeCategories",
                c => new
                    {
                        AttributeId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AttributeId, t.CategoryId });
            
            CreateTable(
                "dbo.AdditionalAttributeValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Value = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.AdditionalAttributeValueTranslations", "AdditionalAttributeValueId");
            CreateIndex("dbo.ProductTranslations", "ProductId");
            CreateIndex("dbo.ProductPriceCurrencies", "ProductId");
            CreateIndex("dbo.CategoryTranslations", "CategoryId");
            CreateIndex("dbo.AttributeValueTranslations", "AttributeValueId");
            CreateIndex("dbo.AttributeTranslations", "AttributeId");
            CreateIndex("dbo.AttributeCategories", "CategoryId");
            CreateIndex("dbo.AttributeCategories", "AttributeId");
            CreateIndex("dbo.AdditionalAttributeValues", "ProductId");
            AddForeignKey("dbo.AdditionalAttributeValueTranslations", "AdditionalAttributeValueId", "dbo.AdditionalAttributeValues", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductTranslations", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductPriceCurrencies", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CategoryTranslations", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AttributeCategories", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AttributeValueTranslations", "AttributeValueId", "dbo.AttributeValues", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AttributeTranslations", "AttributeId", "dbo.Attributes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AttributeCategories", "AttributeId", "dbo.Attributes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AdditionalAttributeValues", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
