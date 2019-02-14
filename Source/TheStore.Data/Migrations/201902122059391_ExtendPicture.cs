namespace TheStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtendPicture : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pictures", "FullPath", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pictures", "FullPath");
        }
    }
}
