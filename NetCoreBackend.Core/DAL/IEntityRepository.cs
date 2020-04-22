using NetCoreBackend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NetCoreBackend.Core.DAL
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> expression);
        List<T> GetList(Expression<Func<T, bool>> expression = null);
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
