﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WebovaAplikace.Models;

namespace WebovaAplikace.Repository.IRepositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<Customer> GetTopBuyers(Func<Customer, bool> customer );      
    }
}