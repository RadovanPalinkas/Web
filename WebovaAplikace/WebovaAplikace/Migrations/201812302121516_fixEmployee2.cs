namespace WebovaAplikace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixEmployee2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Authorization", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "Competency");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Competency", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "Authorization");
        }
    }
}
