namespace WebovaAplikace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Emai", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "Gender", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Street", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Street", c => c.String());
            AlterColumn("dbo.Customers", "City", c => c.String());
            AlterColumn("dbo.Customers", "LastName", c => c.String());
            AlterColumn("dbo.Customers", "FirstName", c => c.String());
            DropColumn("dbo.Customers", "Gender");
            DropColumn("dbo.Customers", "Emai");
        }
    }
}
