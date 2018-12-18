using Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebovaAplikace.Repositories.Implementations;
using WebovaAplikace.Repositories.Interfaces;
using WebovaAplikace.UnitsOfWork.Interfaces;

namespace WebovaAplikace.UnitsOfWork.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EshopDataEntities Context;
        public ICustomerRepository Customers { get; private set; }

        public UnitOfWork(EshopDataEntities context)
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