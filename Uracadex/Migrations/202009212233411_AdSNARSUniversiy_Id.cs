namespace Uracadex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdSNARSUniversiy_Id : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SNARS", "UniversityId", c => c.Int(nullable: false));
            AddColumn("dbo.SNARS", "Request", c => c.String(nullable: false));
            DropColumn("dbo.SNARS", "University");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SNARS", "University", c => c.String(nullable: false));
            DropColumn("dbo.SNARS", "Request");
            DropColumn("dbo.SNARS", "UniversityId");
        }
    }
}
