using AGT.Contracts.Repository;
using AGT.Repository.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AGT.Repository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected DbContext Context { get; private set; }

        public BaseRepository(DbContext repositoryContext)
        {
            Context = repositoryContext;
        }

        public abstract bool Exists(T entity);
        public abstract T Find(int id);

        public IEnumerable<T> FindAll()
        {
            return Context.Set<T>().ToList();
        }

        public IEnumerable<T> FindAllByFilter(Expression<Func<T, bool>> expression)
        {
            return Context.Set<T>().Where(expression);
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            Context.Set<T>().AddRange(entities);
        }

        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);
        }

    }
}
