namespace TheStore.Site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialStoreModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductAttributes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductAttributeValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductAttributeId = c.Int(nullable: false),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductAttributes", t => t.ProductAttributeId, cascadeDelete: true)
                .Index(t => t.ProductAttributeId);
            
            CreateTable(
                "dbo.ProductAttributeMappings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ProductAttributeId = c.Int(nullable: false),
                        ProductAttributeValueId = c.Int(),
                        ProductAttributeTypeId = c.Int(nullable: false),
                        CustomValue = c.String(),
                        XmlValue = c.String(),
                        AllowFiltering = c.Boolean(nullable: false),
                        ShowOnPage = c.Boolean(nullable: false),
                        PriceAdjustment = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.ProductAttributes", t => t.ProductAttributeId, cascadeDelete: true)
                .ForeignKey("dbo.ProductAttributeTypes", t => t.ProductAttributeTypeId, cascadeDelete: true)
                .ForeignKey("dbo.ProductAttributeValues", t => t.ProductAttributeValueId)
                .Index(t => t.ProductId)
                .Index(t => t.ProductAttributeId)
                .Index(t => t.ProductAttributeValueId)
                .Index(t => t.ProductAttributeTypeId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Deleted = c.Boolean(nullable: false),
                        CretedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
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
                        IsPrimary = c.Boolean(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CretedOn = c.DateTime(nullable: false),
                        UpdatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductPictures",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        PictureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.PictureId })
                .ForeignKey("dbo.Pictures", t => t.PictureId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.PictureId);
            
            CreateTable(
                "dbo.Pictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductAttributeTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        CreatedOn = c.DateTime(nullable: false),
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
                "dbo.CategorySubcategories",
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
                        ProductVarietyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.ProductVarietyId })
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.Products", t => t.ProductVarietyId)
                .Index(t => t.ProductId)
                .Index(t => t.ProductVarietyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderProducts", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProductAttributeMappings", "ProductAttributeValueId", "dbo.ProductAttributeValues");
            DropForeignKey("dbo.ProductAttributeMappings", "ProductAttributeTypeId", "dbo.ProductAttributeTypes");
            DropForeignKey("dbo.ProductAttributeMappings", "ProductAttributeId", "dbo.ProductAttributes");
            DropForeignKey("dbo.ProductVarieties", "ProductVarietyId", "dbo.Products");
            DropForeignKey("dbo.ProductVarieties", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductAttributeMappings", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductPictures", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductPictures", "PictureId", "dbo.Pictures");
            DropForeignKey("dbo.ProductCategories", "ProductId", "dbo.Products");
            DropForeignKey("dbo.CategorySubcategories", "SubcategoryId", "dbo.Categories");
            DropForeignKey("dbo.CategorySubcategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.ProductCategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.ProductAttributeValues", "ProductAttributeId", "dbo.ProductAttributes");
            DropIndex("dbo.ProductVarieties", new[] { "ProductVarietyId" });
            DropIndex("dbo.ProductVarieties", new[] { "ProductId" });
            DropIndex("dbo.CategorySubcategories", new[] { "SubcategoryId" });
            DropIndex("dbo.CategorySubcategories", new[] { "CategoryId" });
            DropIndex("dbo.OrderProducts", new[] { "ProductId" });
            DropIndex("dbo.OrderProducts", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.ProductPictures", new[] { "PictureId" });
            DropIndex("dbo.ProductPictures", new[] { "ProductId" });
            DropIndex("dbo.ProductCategories", new[] { "CategoryId" });
            DropIndex("dbo.ProductCategories", new[] { "ProductId" });
            DropIndex("dbo.ProductAttributeMappings", new[] { "ProductAttributeTypeId" });
            DropIndex("dbo.ProductAttributeMappings", new[] { "ProductAttributeValueId" });
            DropIndex("dbo.ProductAttributeMappings", new[] { "ProductAttributeId" });
            DropIndex("dbo.ProductAttributeMappings", new[] { "ProductId" });
            DropIndex("dbo.ProductAttributeValues", new[] { "ProductAttributeId" });
            DropTable("dbo.ProductVarieties");
            DropTable("dbo.CategorySubcategories");
            DropTable("dbo.OrderProducts");
            DropTable("dbo.Orders");
            DropTable("dbo.ProductAttributeTypes");
            DropTable("dbo.Pictures");
            DropTable("dbo.ProductPictures");
            DropTable("dbo.Categories");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Products");
            DropTable("dbo.ProductAttributeMappings");
            DropTable("dbo.ProductAttributeValues");
            DropTable("dbo.ProductAttributes");
        }
    }
}
