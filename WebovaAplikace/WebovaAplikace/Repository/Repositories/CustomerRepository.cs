using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebovaAplikace.Models;
using WebovaAplikace.Repository.IRepositories;

namespace WebovaAplikace.Repository.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {      
        public CustomerRepository(DbContext context) : base(context)
        {
        }
        public IEnumerable<Customer> GetTopBuyers(Func<Customer,bool> customer)
        {
            return Context.Set<Customer>().Where(customer).ToList();
        }
    }
}