using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Data.Repositories.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TKey : IComparable<TKey> where TEntity : class, IEntity<TKey>
    {
        public readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public TEntity Get(TKey id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        // DON'T USE
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            var ctx = Context.Set<TEntity>();
            var oldEnt = Get(entity.Id);
            if (oldEnt == entity)
            {
                Context.Set<TEntity>().Update(entity);
            }
            else
            {
                // Context.Entry(oldEnt).State = EntityState.Modified;
                CopyProperties(entity, oldEnt);
                Context.Set<TEntity>().Update(oldEnt);
            }
        }

        private void CopyProperties(TEntity src, TEntity dest)
        {
            var srcProperties = src.GetType().GetProperties();
            var destProperties = dest.GetType().GetProperties();
            Type[] ifaces;
            foreach (var srcProperty in srcProperties)
            {
                foreach (var destProperty in destProperties)
                {
                    if (srcProperty.Name == destProperty.Name)
                    {
                        ifaces = srcProperty.PropertyType.GetInterfaces();
                        if (  (!ifaces.Any(
                                    x => x.IsGenericType && 
                                         (x.GetGenericTypeDefinition() == typeof(IEntity<>) ||
                                          x.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                                         )) ||
                              srcProperty.PropertyType == typeof(string))
                            destProperty.SetValue(dest, srcProperty.GetValue(src));
                        break;
                    }
                }
            }
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().UpdateRange(entities);
        }
    }
}
