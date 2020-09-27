namespace Uracadex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigrationUnknown : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SNARS", "MiddleName");
            DropColumn("dbo.SNARS", "MatricNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SNARS", "MatricNo", c => c.String());
            AddColumn("dbo.SNARS", "MiddleName", c => c.String());
        }
    }
}
