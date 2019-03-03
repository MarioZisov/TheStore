namespace TheStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttributeType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product_Attribute_Mapping", "AttributeTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.ProductAttributeTypes", "Description", c => c.String());
            CreateIndex("dbo.Product_Attribute_Mapping", "AttributeTypeId");
            AddForeignKey("dbo.Product_Attribute_Mapping", "AttributeTypeId", "dbo.ProductAttributeTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product_Attribute_Mapping", "AttributeTypeId", "dbo.ProductAttributeTypes");
            DropIndex("dbo.Product_Attribute_Mapping", new[] { "AttributeTypeId" });
            DropColumn("dbo.ProductAttributeTypes", "Description");
            DropColumn("dbo.Product_Attribute_Mapping", "AttributeTypeId");
        }
    }
}
