using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebovaAplikace.Repository.IRepositories
{
    public interface IRepository <T>
    {
        void Add(T entity);
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Remove(T entity);
    }
}