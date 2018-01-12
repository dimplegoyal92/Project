namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PCtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PrimaryCategories",
                c => new
                    {
                        PrimaryCategoryId = c.Int(nullable: false, identity: true),
                        PrimaryCategoryName = c.String(),
                        SchemeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PrimaryCategoryId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PrimaryCategories");
        }
    }
}
