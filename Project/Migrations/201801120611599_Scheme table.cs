namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Schemetable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PrimaryCategories", "SchemeId", c => c.Int());
            AlterColumn("dbo.Products", "SchemeId", c => c.Int());
            AlterColumn("dbo.Products", "Quantity", c => c.Int());
            AlterColumn("dbo.Products", "OrderQuantityDuringScheme", c => c.Int());
            AlterColumn("dbo.Products", "OrderQuantityNoScheme", c => c.Int());
            AlterColumn("dbo.SubCategories", "SchemeId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SubCategories", "SchemeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "OrderQuantityNoScheme", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "OrderQuantityDuringScheme", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "Quantity", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "SchemeId", c => c.Int(nullable: false));
            AlterColumn("dbo.PrimaryCategories", "SchemeId", c => c.Int(nullable: false));
        }
    }
}
