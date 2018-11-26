namespace EmotionPlatzi.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeFieldsInHomeAreChanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Homes", "WelcomeMessage", c => c.String(maxLength: 50));
            AlterColumn("dbo.Homes", "FooterMessage", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Homes", "FooterMessage", c => c.String());
            AlterColumn("dbo.Homes", "WelcomeMessage", c => c.String());
        }
    }
}
