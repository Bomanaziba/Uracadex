namespace Uracadex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SNARS",
                c => new
                    {
                        SNARSId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        MiddleName = c.String(),
                        Phone = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        MatricNo = c.String(),
                        University = c.String(nullable: false),
                        CourseOfStudy = c.String(nullable: false),
                        Category = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SNARSId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SNARS");
        }
    }
}
