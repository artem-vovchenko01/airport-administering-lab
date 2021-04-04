using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Entities;

namespace Data.Repositories.Abstract
{
    public interface IRepository<TEntity, TKey> where TEntity : IEntity<TKey> where TKey : IComparable<TKey>
    {
        TEntity Get(TKey id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
    }
}
