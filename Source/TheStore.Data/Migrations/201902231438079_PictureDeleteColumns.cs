namespace TheStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PictureDeleteColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pictures", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Pictures", "DeletedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pictures", "DeletedDate");
            DropColumn("dbo.Pictures", "Deleted");
        }
    }
}
