namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SCtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Schemes",
                c => new
                    {
                        SchemeId = c.Int(nullable: false, identity: true),
                        SchemeName = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        SchemeType = c.String(),
                        SchemeLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SchemeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Schemes");
        }
    }
}
