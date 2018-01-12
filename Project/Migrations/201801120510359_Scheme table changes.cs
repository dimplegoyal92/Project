namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Schemetablechanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "OrderQuantityDuringScheme", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "OrderQuantityNoScheme", c => c.Int(nullable: false));
            AlterColumn("dbo.PrimaryCategories", "PrimaryCategoryName", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "ProductName", c => c.String(nullable: false));
            AlterColumn("dbo.Schemes", "SchemeName", c => c.String(nullable: false));
            AlterColumn("dbo.Schemes", "SchemeType", c => c.String(nullable: false));
            AlterColumn("dbo.SubCategories", "SubCategoryName", c => c.String(nullable: false));
            DropColumn("dbo.Schemes", "SchemeLevel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schemes", "SchemeLevel", c => c.Int(nullable: false));
            AlterColumn("dbo.SubCategories", "SubCategoryName", c => c.String());
            AlterColumn("dbo.Schemes", "SchemeType", c => c.String());
            AlterColumn("dbo.Schemes", "SchemeName", c => c.String());
            AlterColumn("dbo.Products", "ProductName", c => c.String());
            AlterColumn("dbo.PrimaryCategories", "PrimaryCategoryName", c => c.String());
            DropColumn("dbo.Products", "OrderQuantityNoScheme");
            DropColumn("dbo.Products", "OrderQuantityDuringScheme");
            DropColumn("dbo.Products", "Quantity");
        }
    }
}
