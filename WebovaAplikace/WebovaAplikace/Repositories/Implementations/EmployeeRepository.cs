using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebovaAplikace.Common.DbContextDataFirst.Interfaces;
using WebovaAplikace.Models;
using WebovaAplikace.Repositories.Interfaces;

namespace WebovaAplikace.Repositories.Implementations
{
    public class EmployeeRepository: Repository<Employee>, IEmployeeRepository
    {       

        public IEnumerable<Employee> GetEmployeeByCompetency(int authorization)
        {
            return Context.Set<Employee>().Where(a=>a.Authorization == authorization).ToList();
        }
        public async Task<IEnumerable<Employee>> GetEmployeeByCompetencyAsync(int authorization)
        {
            return await Task.Run(()=>Context.Set<Employee>().Where(a=>a.Authorization == authorization).ToList());
        }
    }
}