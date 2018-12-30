using System;
using System.Collections.Generic;
using System.Linq;
using WebovaAplikace.Common.DbContextDataFirst.Interfaces;
using WebovaAplikace.Models;
using WebovaAplikace.Repositories.Interfaces;


namespace WebovaAplikace.Repositories.Implementations
{
    
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {              
        public IEnumerable<Customer> GetTopBuyers(Func<Customer,bool> customer)
        {
            return Context.Set<Customer>().Where(customer).ToList();
        }
    }
}