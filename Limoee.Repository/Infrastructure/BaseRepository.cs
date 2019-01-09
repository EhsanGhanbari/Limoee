using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Limoee.Infrastructure.Domain;

namespace Limoee.Repository.Infrastructure
{
    public abstract class BaseRepository<T, TId> : IBaseRepository<T, TId> where T : class, IAggregateRoot
    {
        private LimoeeDataContext _dataContext;
        private readonly IDbSet<T> _dbset;
        protected BaseRepository(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            _dbset = DataContext.Set<T>();
        }

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        protected LimoeeDataContext DataContext
        {
            get { return _dataContext ?? (_dataContext = DatabaseFactory.Get()); }
        }
        public virtual void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _dbset.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
        }

        public void Remove(T entity)
        {
            _dbset.Remove(entity);
        }
        public virtual void Remove(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = _dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                _dbset.Remove(obj);
        }

        public T GetById(TId id)
        {
            return _dbset.Find(id);
        }

        public abstract PagedResult<T> GetMany(Expression<Func<T, bool>> expressionQuery, int pageIndex = 1,
            int pageSize = 30);


        public virtual T GetById(string id)
        {
            return _dbset.Find(id);
        }
        public virtual IEnumerable<T> GetAll()
        {
            return _dbset.ToList();
        }
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where).ToList();
        }
        public T Get(Expression<Func<T, bool>> where)
        {
            return _dbset.Where(where).FirstOrDefault<T>();
        }
    }
}