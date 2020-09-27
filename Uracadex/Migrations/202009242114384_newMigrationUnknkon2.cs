namespace Uracadex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigrationUnknkon2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SNARS", "Level", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SNARS", "Level");
        }
    }
}
