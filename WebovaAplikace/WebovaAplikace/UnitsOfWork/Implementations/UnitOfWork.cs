using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

using WebovaAplikace.Common.DbContextDataFirst.Interfaces;
using WebovaAplikace.Repositories.Implementations;
using WebovaAplikace.Repositories.Interfaces;
using WebovaAplikace.UnitsOfWork.Interfaces;

namespace WebovaAplikace.UnitsOfWork.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext Context;
        public ICustomerRepository Customers { get; private set; }

        public UnitOfWork(IDbContext context)
        {
            Context = context;
            Customers = new CustomerRepository(Context);
        }        

        public async Task<int> Complete()
        {
            return await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}