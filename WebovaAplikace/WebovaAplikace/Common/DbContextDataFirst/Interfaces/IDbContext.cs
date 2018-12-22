using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebovaAplikace.Common.DbContextDataFirst.Interfaces
{
    public interface IDbContext : IDisposable
    {
        DbSet<T> Set<T>() where T : class;

        Task<int> SaveChangesAsync();
    }
}
