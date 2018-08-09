using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AGT.Contracts.Repository
{
    public interface IRepository<T> where T : class
    {
        bool Exists(T entity);
        T Find(int id);
        IEnumerable<T> FindAll();
        IEnumerable<T> FindAllByFilter(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
