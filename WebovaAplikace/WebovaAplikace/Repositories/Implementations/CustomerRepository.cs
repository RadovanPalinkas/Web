
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebovaAplikace.Common.DataFirst;
using WebovaAplikace.Models;
using WebovaAplikace.Repositories.Interfaces;

namespace WebovaAplikace.Repositories.Implementations
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {      
        public CustomerRepository(DatabazeWebContext context) : base(context)
        {
        }

        public IEnumerable<Customer> GetTopBuyers(Func<Customer,bool> customer)
        {
            return Context.Set<Customer>().Where(customer).ToList();
        }
    }
}