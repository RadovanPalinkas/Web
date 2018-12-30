using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebovaAplikace.Repositories.Interfaces;

namespace WebovaAplikace.UnitsOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository Customers { get;  }
        IEmployeeRepository Employees { get;  }
        Task<int> CompleteAsync();
    }
}
