using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebovaAplikace.Models;
using WebovaAplikace.Repository.IRepositories;

namespace WebovaAplikace.Repository.Repositories
{
    class ProductRepository : IProductRepository
    {
        //získá data z naší provizorní nepersistentní databáze
        public List<Product> GetProduct()
        {
            return new List<Product>()
            {
                new Product{Name = "Radovan" , Cena = 500},
                new Product{Name = "Tomáš" , Cena = 500},
                new Product{Name = "Roman" , Cena = 500}
              };
        }
    }
}

