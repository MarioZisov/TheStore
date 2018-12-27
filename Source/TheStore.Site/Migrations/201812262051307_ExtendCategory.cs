namespace TheStore.Site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtendCategory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Visible", c => c.Boolean(nullable: false));
            AddColumn("dbo.Categories", "DisplayOrder", c => c.Int(nullable: false));
            AddColumn("dbo.Categories", "PictureId", c => c.Int());
            CreateIndex("dbo.Categories", "PictureId");
            AddForeignKey("dbo.Categories", "PictureId", "dbo.Pictures", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "PictureId", "dbo.Pictures");
            DropIndex("dbo.Categories", new[] { "PictureId" });
            DropColumn("dbo.Categories", "PictureId");
            DropColumn("dbo.Categories", "DisplayOrder");
            DropColumn("dbo.Categories", "Visible");
        }
    }
}
