namespace TheStore.Site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'fc9047bb-08a1-4fdb-ab71-1a02337366d3', N'Customer')
                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'03e79fd9-1747-435a-842e-9303b0315d4b', N'Owner')");
        }
        
        public override void Down()
        {
        }
    }
}
