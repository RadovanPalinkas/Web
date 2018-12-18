using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebovaAplikace.Models;

//1)vatvořit takovouto třídu které dědí ze třídy DbContext
//2)do app.config vložit conection string <connectionStrings> <add name = "EntityContext" connectionString="Data Source=DESKTOP-ECHHB9J\RADOVANSQL;Initial Catalog=DatabazeProWeb; Integrated Security = True" providerName="System.Data.SqlClient"/> </connectionStrings>
//3)do nuget konzole napsat "enable-migrations"
//4)do nuget konzole napsat "add-migration nazev"
//5)----------------------       BEZ NÁSLEDUJÍCÍHO DPŘÍKAZU DO KONZOLE SE NIC DO DATABÁZE NEZAPÍŠE        -------------------
//update-database -ConfigurationTypeName "WebovaAplikace.Migrations.Configuration" -ProjectName "WebovaAplikace" -ConnectionString "Data Source=DESKTOP-ECHHB9J\RADOVANSQL;Initial Catalog=EshopData; Integrated Security = True" -ConnectionProviderName "System.Data.SqlClient"
//switch mezi migracema "update-database -TargetMigration: 0"
namespace WebovaAplikace.Common.DataFirst
{
    public class DatabazeWebContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

    }
}

