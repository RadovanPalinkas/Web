using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebovaAplikace.Repository.IRepositories;
using WebovaAplikace.Repository.Repositories;
using WebovaAplikace.UnitsOfWork.Interfaces;

namespace WebovaAplikace.UnitsOfWork.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext Context;
        public ICustomerRepository Customers { get; private set; }

        public UnitOfWork(DbContext context)
        {
            Context = context;
            Customers = new CustomerRepository(Context);
        }        

        public int Complete()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}