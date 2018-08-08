using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AGT.Contracts.DataAccess
{
    public interface IBaseDataAccess<T>
    {
        T Find(T entity);
        IEnumerable<T> FindAll();
        IEnumerable<T> FindAllByFilter(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
