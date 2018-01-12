namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Schemetab : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schemes", "SchemeLevel", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Schemes", "SchemeLevel");
        }
    }
}
