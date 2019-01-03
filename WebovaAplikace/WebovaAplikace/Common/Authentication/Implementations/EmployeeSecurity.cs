using System;
using System.Linq;
using System.Runtime.CompilerServices;
using WebovaAplikace.Common.Authentication.Interfaces;
using WebovaAplikace.Common.DbContextDataFirst.Implementations;
using WebovaAplikace.Common.DbContextDataFirst.Interfaces;
using WebovaAplikace.Models;

namespace WebovaAplikace.Common.Authentication.Implementations
{
    public class EmployeeSecurity 
    {
        
        public static bool Login(string email, string pass)
        {
            using (var iDbContext = new DatabazeWebContext())
            {
                return iDbContext.Set<Employee>().Any(e => e.Email.Equals(email, StringComparison.OrdinalIgnoreCase)
                        && e.Password == pass);
            }                
        }
    }
}