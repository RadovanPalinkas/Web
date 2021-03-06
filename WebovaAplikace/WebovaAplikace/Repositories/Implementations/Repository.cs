﻿
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using WebovaAplikace.Common.DbContextDataFirst.Interfaces;
using WebovaAplikace.Common.Filters;
using WebovaAplikace.Models;
using WebovaAplikace.Repositories.Interfaces;


namespace WebovaAplikace.Repositories.Implementations
{

    public class Repository<T> : IRepository<T> where T : class
    {
        protected IDbContext Context { get; private set; }

        public void SetDbContext(IDbContext context)
        {
            Context = context;
        }
        public void Add(T entity)
        {
            if (!Context.ObjectContext.DatabaseExists())
                throw new EntityException();
            Context.Set<T>().Add(entity);
        }
        public async Task AddAsync(T entity)
        {
            if (!Context.ObjectContext.DatabaseExists())
                throw new EntityException();
            await Task.Run(() => Context.Set<T>().Add(entity));
        }
        public void AddRange(IEnumerable<T> entities)
        {
            Context.Set<T>().AddRange(entities);
        }
        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await Task.Run(()=>Context.Set<T>().AddRange(entities));
        }
        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }
        public async Task<IEnumerable<T>> FindAsync(Func<T, bool> predicate)
        {
            return await Task.Run(() => Context.Set<T>().Where(predicate));
        }       
        public T Get(int id)
        {
            return Context.Set<T>().Find(id);
        }
        public async Task<T> GetAsync(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }
        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }
        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }
        public async Task RemoveAsync(T entity)
        {
            await Task.Run(() => Context.Set<T>().Remove(entity));
        }
        public void RemoveRenge(IEnumerable<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);
        }
        public async Task RemoveRengeAsync(IEnumerable<T> entities)
        {
            await Task.Run(() => Context.Set<T>().RemoveRange(entities));
        }
    }
}