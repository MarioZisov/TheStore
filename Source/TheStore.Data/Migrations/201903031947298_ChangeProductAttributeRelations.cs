namespace TheStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeProductAttributeRelations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductAttributeValues", "ProductAttributeId", "dbo.ProductAttributes");
            DropForeignKey("dbo.ProductAttributeMappings", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductVarieties", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductVarieties", "ProductVarietyId", "dbo.Products");
            DropForeignKey("dbo.ProductAttributeMappings", "ProductAttributeId", "dbo.ProductAttributes");
            DropForeignKey("dbo.ProductAttributeMappings", "ProductAttributeTypeId", "dbo.ProductAttributeTypes");
            DropForeignKey("dbo.ProductAttributeMappings", "ProductAttributeValueId", "dbo.ProductAttributeValues");
            DropIndex("dbo.ProductAttributeValues", new[] { "ProductAttributeId" });
            DropIndex("dbo.ProductAttributeMappings", new[] { "ProductId" });
            DropIndex("dbo.ProductAttributeMappings", new[] { "ProductAttributeId" });
            DropIndex("dbo.ProductAttributeMappings", new[] { "ProductAttributeValueId" });
            DropIndex("dbo.ProductAttributeMappings", new[] { "ProductAttributeTypeId" });
            DropIndex("dbo.ProductVarieties", new[] { "ProductId" });
            DropIndex("dbo.ProductVarieties", new[] { "ProductVarietyId" });
            CreateTable(
                "dbo.Product_Attribute_Mapping",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ProductAttributeId = c.Int(nullable: false),
                        AllowFiltering = c.Boolean(nullable: false),
                        ShowOnPage = c.Boolean(nullable: false),
                        PriceAdjustment = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.ProductAttributes", t => t.ProductAttributeId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.ProductAttributeId);
            
            CreateTable(
                "dbo.Product_Attribute_Value_Mapping",
                c => new
                    {
                        ProductAttributeMappingId = c.Int(nullable: false),
                        AttributeValueId = c.Int(nullable: false),
                        CustomValue = c.String(),
                    })
                .PrimaryKey(t => new { t.ProductAttributeMappingId, t.AttributeValueId })
                .ForeignKey("dbo.ProductAttributeValues", t => t.AttributeValueId, cascadeDelete: true)
                .ForeignKey("dbo.Product_Attribute_Mapping", t => t.ProductAttributeMappingId, cascadeDelete: true)
                .Index(t => t.ProductAttributeMappingId)
                .Index(t => t.AttributeValueId);
            
            CreateTable(
                "dbo.ProductAttribute_AttributeValue_Mapping",
                c => new
                    {
                        AttributeId = c.Int(nullable: false),
                        AttributeValueId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AttributeId, t.AttributeValueId })
                .ForeignKey("dbo.ProductAttributes", t => t.AttributeId, cascadeDelete: true)
                .ForeignKey("dbo.ProductAttributeValues", t => t.AttributeValueId, cascadeDelete: true)
                .Index(t => t.AttributeId)
                .Index(t => t.AttributeValueId);
            
            AddColumn("dbo.ProductAttributes", "Description", c => c.String());
            AddColumn("dbo.ProductAttributeValues", "Description", c => c.String());
            AlterColumn("dbo.ProductAttributeValues", "Value", c => c.String(nullable: false));
            DropColumn("dbo.ProductAttributeValues", "ProductAttributeId");
            DropTable("dbo.ProductAttributeMappings");
            DropTable("dbo.ProductVarieties");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductVarieties",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        ProductVarietyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.ProductVarietyId });
            
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
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ProductAttributeValues", "ProductAttributeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Product_Attribute_Value_Mapping", "ProductAttributeMappingId", "dbo.Product_Attribute_Mapping");
            DropForeignKey("dbo.Product_Attribute_Value_Mapping", "AttributeValueId", "dbo.ProductAttributeValues");
            DropForeignKey("dbo.ProductAttribute_AttributeValue_Mapping", "AttributeValueId", "dbo.ProductAttributeValues");
            DropForeignKey("dbo.ProductAttribute_AttributeValue_Mapping", "AttributeId", "dbo.ProductAttributes");
            DropForeignKey("dbo.Product_Attribute_Mapping", "ProductAttributeId", "dbo.ProductAttributes");
            DropForeignKey("dbo.Product_Attribute_Mapping", "ProductId", "dbo.Products");
            DropIndex("dbo.ProductAttribute_AttributeValue_Mapping", new[] { "AttributeValueId" });
            DropIndex("dbo.ProductAttribute_AttributeValue_Mapping", new[] { "AttributeId" });
            DropIndex("dbo.Product_Attribute_Value_Mapping", new[] { "AttributeValueId" });
            DropIndex("dbo.Product_Attribute_Value_Mapping", new[] { "ProductAttributeMappingId" });
            DropIndex("dbo.Product_Attribute_Mapping", new[] { "ProductAttributeId" });
            DropIndex("dbo.Product_Attribute_Mapping", new[] { "ProductId" });
            AlterColumn("dbo.ProductAttributeValues", "Value", c => c.String());
            DropColumn("dbo.ProductAttributeValues", "Description");
            DropColumn("dbo.ProductAttributes", "Description");
            DropTable("dbo.ProductAttribute_AttributeValue_Mapping");
            DropTable("dbo.Product_Attribute_Value_Mapping");
            DropTable("dbo.Product_Attribute_Mapping");
            CreateIndex("dbo.ProductVarieties", "ProductVarietyId");
            CreateIndex("dbo.ProductVarieties", "ProductId");
            CreateIndex("dbo.ProductAttributeMappings", "ProductAttributeTypeId");
            CreateIndex("dbo.ProductAttributeMappings", "ProductAttributeValueId");
            CreateIndex("dbo.ProductAttributeMappings", "ProductAttributeId");
            CreateIndex("dbo.ProductAttributeMappings", "ProductId");
            CreateIndex("dbo.ProductAttributeValues", "ProductAttributeId");
            AddForeignKey("dbo.ProductAttributeMappings", "ProductAttributeValueId", "dbo.ProductAttributeValues", "Id");
            AddForeignKey("dbo.ProductAttributeMappings", "ProductAttributeTypeId", "dbo.ProductAttributeTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductAttributeMappings", "ProductAttributeId", "dbo.ProductAttributes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductVarieties", "ProductVarietyId", "dbo.Products", "Id");
            AddForeignKey("dbo.ProductVarieties", "ProductId", "dbo.Products", "Id");
            AddForeignKey("dbo.ProductAttributeMappings", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductAttributeValues", "ProductAttributeId", "dbo.ProductAttributes", "Id", cascadeDelete: true);
        }
    }
}
