using AGT.Contracts.Repository;
using AGT.Repository.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;

namespace AGT.Repository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected DbContext Context { get; private set; }
        
        protected DomainContext DomainContext
        {
            get { return Context as DomainContext; }
        }

        public BaseRepository(DbContext repositoryContext)
        {
            Context = repositoryContext;
        }

        public bool Exists(T entity)
        {
            try
            {
                return TryExists(entity);
            }
            catch (DbException e)
            {
                throw new DatabaseConnectionException(e);
            }
        }
        protected abstract bool TryExists(T entity);

        public T Find(int id)
        {
            try
            {
                return TryFind(id);
            }
            catch (DbException e)
            {
                throw new DatabaseConnectionException(e);
            }
        }
        protected abstract T TryFind(int id);

        public T Find(T entity)
        {
            try
            {
                return TryFind(entity);
            }
            catch (DbException e)
            {
                throw new DatabaseConnectionException(e);
            }
        }
        protected abstract T TryFind(T entity);

        public IEnumerable<T> FindAll()
        {
            try
            {
                return TryFindAll();
            }
            catch (DbException e)
            {
                throw new DatabaseConnectionException(e);
            }
        }
        protected virtual IEnumerable<T> TryFindAll()
        {
            return Context.Set<T>().ToList();
        }

        public IEnumerable<T> FindAllByFilter(Expression<Func<T, bool>> expression)
        {
            try
            {
                return TryFindAllByFilter(expression);
            }
            catch (DbException e)
            {
                throw new DatabaseConnectionException(e);
            }
        }
        protected virtual IEnumerable<T> TryFindAllByFilter(Expression<Func<T, bool>> expression)
        {
            return Context.Set<T>().Where(expression);
        }

        public void Add(T entity)
        {
            try
            {
                TryAdd(entity);
            }
            catch (DbException e)
            {
                throw new DatabaseConnectionException(e);
            }
        }
        protected virtual void TryAdd(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            try
            {
                TryAddRange(entities);
            }
            catch (DbException e)
            {
                throw new DatabaseConnectionException(e);
            }
        }
        protected virtual void TryAddRange(IEnumerable<T> entities)
        {
            Context.Set<T>().AddRange(entities);
        }

        public void Remove(T entity)
        {
            try
            {
                TryRemove(entity);
            }
            catch (DbException e)
            {
                throw new DatabaseConnectionException(e);
            }
        }
        protected virtual void TryRemove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities) {
            try
            {
                TryRemoveRange(entities);
            }
            catch (DbException e)
            {
                throw new DatabaseConnectionException(e);
            }
        }
        protected virtual void TryRemoveRange(IEnumerable<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);
        }

    }
}
