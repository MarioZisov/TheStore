namespace TheStore.Site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttributeValueAllowNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AttributeValues", "Value", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AttributeValues", "Value", c => c.String(nullable: false));
        }
    }
}
