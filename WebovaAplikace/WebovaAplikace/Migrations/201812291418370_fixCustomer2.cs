namespace WebovaAplikace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixCustomer2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Customers", "Emai");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Emai", c => c.String(nullable: false));
            DropColumn("dbo.Customers", "Email");
        }
    }
}
