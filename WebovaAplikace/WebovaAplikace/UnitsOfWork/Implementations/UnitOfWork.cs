using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebovaAplikace.Common.DataFirst;
using WebovaAplikace.Repositories.Implementations;
using WebovaAplikace.Repositories.Interfaces;
using WebovaAplikace.UnitsOfWork.Interfaces;

namespace WebovaAplikace.UnitsOfWork.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabazeWebContext Context;
        public ICustomerRepository Customers { get; private set; }

        public UnitOfWork(DatabazeWebContext context)
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