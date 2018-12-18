namespace WebovaAplikace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Description", c => c.String());
            AddColumn("dbo.Products", "Price", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "Cena");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Cena", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "Price");
            DropColumn("dbo.Products", "Description");
        }
    }
}
