using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using WebovaAplikace.Common.DbContextDataFirst.Interfaces;

namespace WebovaAplikace.Repositories.Interfaces
{
    public interface IRepository <T> where T :class
    {
        void SetDbContext(IDbContext context);

        T Get(int id);
        Task<T> GetAsync(int id);
        IEnumerable<T> GetAll();        
        Task<IEnumerable<T>> GetAllAsync();        
        IEnumerable<T> Find(Func<T, bool> predicate);
        Task<IEnumerable<T>> FindAsync(Func<T, bool> predicate);

        void Add(T entity);        
        Task AddAsync(T entity);        
        void AddRange(IEnumerable<T> entities);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Remove(T entity);
        Task RemoveAsync(T entity);        
        void RemoveRenge(IEnumerable<T> entities);
        Task RemoveRengeAsync(IEnumerable<T> entities);
    }
}