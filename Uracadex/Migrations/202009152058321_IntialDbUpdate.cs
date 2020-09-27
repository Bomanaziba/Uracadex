namespace Uracadex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialDbUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SNARS", "ResearchInterest", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SNARS", "ResearchInterest");
        }
    }
}
