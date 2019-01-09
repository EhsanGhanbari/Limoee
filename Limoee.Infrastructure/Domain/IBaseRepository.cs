using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Limoee.Infrastructure.Domain
{
    public interface IBaseRepository<T, TId> where T : IAggregateRoot
    {
        void Add(T entity);
        
        void Update(T entity);
        void Remove(T entity);
        void Remove(Expression<Func<T, bool>> where);
        T GetById(TId id);
        PagedResult<T> GetMany(Expression<Func<T, bool>> expressionQuery, int pageIndex = 1, int pageSize = 30);
        IEnumerable<T> GetAll();
        T Get(Expression<Func<T, bool>> where);
    }
}
