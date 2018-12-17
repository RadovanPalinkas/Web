using System.Collections.Generic;
using WebovaAplikace.Models;

namespace WebovaAplikace.Repository.IRepositories
{

    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer GetByName(string name);
    }

}