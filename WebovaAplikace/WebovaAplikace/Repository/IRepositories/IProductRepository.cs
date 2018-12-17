using System.Collections.Generic;
using WebovaAplikace.Models;

namespace WebovaAplikace.Repository.IRepositories
{
    public interface IProductRepository
    {
        List<Product> GetProduct();
    }
}