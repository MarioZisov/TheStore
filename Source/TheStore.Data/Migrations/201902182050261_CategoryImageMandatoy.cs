namespace TheStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryImageMandatoy : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Categories", "PictureId", "dbo.Pictures");
            DropIndex("dbo.Categories", new[] { "PictureId" });
            AlterColumn("dbo.Categories", "PictureId", c => c.Int(nullable: false));
            CreateIndex("dbo.Categories", "PictureId");
            AddForeignKey("dbo.Categories", "PictureId", "dbo.Pictures", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "PictureId", "dbo.Pictures");
            DropIndex("dbo.Categories", new[] { "PictureId" });
            AlterColumn("dbo.Categories", "PictureId", c => c.Int());
            CreateIndex("dbo.Categories", "PictureId");
            AddForeignKey("dbo.Categories", "PictureId", "dbo.Pictures", "Id");
        }
    }
}
