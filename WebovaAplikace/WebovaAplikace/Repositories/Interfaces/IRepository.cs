using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace WebovaAplikace.Repositories.Interfaces
{
    public interface IRepository <T> where T :class
    {
        T Get(int id);
        Task<T> GetAsync(int id);
        IEnumerable<T> GetAll();        
        Task<IEnumerable<T>> GetAllAsync();        
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        void Add(T entity);        
        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);
        void RemoveRenge(IEnumerable<T> entities);
    }
}