using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AGT.Contracts.DataAccess
{
    public interface IBaseDataAccess<T>
    {
        bool Exists(T toGet);
        T Find(T toGet);
        IEnumerable<T> FindAll();
        IEnumerable<T> FindAllByFilter(Expression<Func<T, bool>> expression);
        T Add(T toAdd);
        T Update(T toUpdate);
    }
}
