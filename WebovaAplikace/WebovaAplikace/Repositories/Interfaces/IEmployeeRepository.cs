﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebovaAplikace.Models;

namespace WebovaAplikace.Repositories.Interfaces
{
    public interface IEmployeeRepository: IRepository<Employee>
    {
        IEnumerable<Employee> GetEmployeeByAuthorization(int authorization);
        Task<IEnumerable<Employee>> GetEmployeeByAuthorizationAsync(int authorization);
    }
}
