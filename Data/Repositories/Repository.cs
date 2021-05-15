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
        protected readonly MyDbContext _context;

        public Repository(MyDbContext context)
        {
            _context = context;
        }

        public TEntity Get(TKey id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        // DON'T USE
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            var ctx = _context.Set<TEntity>();
            var oldEnt = Get(entity.Id);
            if (oldEnt == entity)
            {
                _context.Set<TEntity>().Update(entity);
            }
            else
            {
                // Context.Entry(oldEnt).State = EntityState.Modified;
                CopyProperties(entity, oldEnt);
                _context.Set<TEntity>().Update(oldEnt);
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
            _context.Set<TEntity>().UpdateRange(entities);
        }
    }
}
