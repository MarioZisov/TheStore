namespace TheStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableDateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pictures", "UploadDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "UpdatedOn", c => c.DateTime());
            AlterColumn("dbo.Categories", "UpdatedOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Categories", "UpdatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "UpdatedOn", c => c.DateTime(nullable: false));
            DropColumn("dbo.Pictures", "UploadDate");
        }
    }
}
