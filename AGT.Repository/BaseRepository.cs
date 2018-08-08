using AGT.Contracts.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AGT.Repository
{
    public abstract class BaseRepository<T> : IBaseDataAccess<T> where T : class
    {
        protected RepositoryContext RepositoryContext { get; set; }

        public BaseRepository(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public T Find(T entity)
        {
            return RepositoryContext.Set<T>().Find(entity);
        }

        public IEnumerable<T> FindAll()
        {
            return RepositoryContext.Set<T>();
        }

        public IEnumerable<T> FindAllByFilter(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>().Where(expression);
        }

        public void Create(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
        }

        public void Save()
        {
            RepositoryContext.SaveChanges();
        }
    }
}
