namespace WebovaAplikace.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyV1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Customers", newName: "tblCustomers");
            RenameColumn(table: "dbo.tblCustomers", name: "Name", newName: "FirstName");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.tblCustomers", name: "FirstName", newName: "Name");
            RenameTable(name: "dbo.tblCustomers", newName: "Customers");
        }
    }
}
