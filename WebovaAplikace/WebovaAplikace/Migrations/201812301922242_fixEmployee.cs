namespace WebovaAplikace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "City", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "Street", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "Number", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "ZipCode", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "Competency", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Gender", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Gender", c => c.String());
            AlterColumn("dbo.Employees", "LastName", c => c.String());
            AlterColumn("dbo.Employees", "FirstName", c => c.String());
            DropColumn("dbo.Employees", "Competency");
            DropColumn("dbo.Employees", "ZipCode");
            DropColumn("dbo.Employees", "Number");
            DropColumn("dbo.Employees", "Street");
            DropColumn("dbo.Employees", "City");
            DropColumn("dbo.Employees", "Email");
        }
    }
}
