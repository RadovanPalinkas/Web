
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebovaAplikace.Common.DbContextDataFirst;
using WebovaAplikace.Common.DbContextDataFirst.Interfaces;
using WebovaAplikace.Common.Filters;
using WebovaAplikace.Models;
using WebovaAplikace.Repositories.Interfaces;


namespace WebovaAplikace.Repositories.Implementations
{
    
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {      
        public CustomerRepository(IDbContext context) : base(context)
        {
        }

        public IEnumerable<Customer> GetTopBuyers(Func<Customer,bool> customer)
        {
            return Context.Set<Customer>().Where(customer).ToList();
        }
    }
}