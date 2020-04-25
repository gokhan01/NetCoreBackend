using NetCoreBackend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NetCoreBackend.Core.DAL
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> expression);
        List<T> GetList(Expression<Func<T, bool>> expression = null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
