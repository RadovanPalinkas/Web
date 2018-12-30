using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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
        public IEmployeeRepository Employees { get; private set; }

        public UnitOfWork(IDbContext context, ICustomerRepository customer,IEmployeeRepository employee)
        {             
            Context = context;
            Customers = customer;
            Employees = employee;

            Customers.SetDbContext(context);
            Employees.SetDbContext(context);
        }        

        public async Task<int> CompleteAsync()
        {
            return await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}