namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ordertable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderQuantityDuringScheme = c.Int(nullable: false),
                        OrderQuantityNoScheme = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        SchemeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            DropColumn("dbo.Products", "OrderQuantityDuringScheme");
            DropColumn("dbo.Products", "OrderQuantityNoScheme");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "OrderQuantityNoScheme", c => c.Int());
            AddColumn("dbo.Products", "OrderQuantityDuringScheme", c => c.Int());
            DropTable("dbo.Orders");
        }
    }
}
