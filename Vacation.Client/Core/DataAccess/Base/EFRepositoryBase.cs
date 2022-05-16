using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Core.DataAccess.Base
{
    public  class EFRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext :DbContext, new()
    {


        public void Add(TEntity entity)
        {
            using (TContext context = new ())
            {
                var adddEntity = context.Entry(entity);
                adddEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new ())
            {
                return filter == null ?
                    context.Set<TEntity>().FirstOrDefault() :
                    context.Set<TEntity>().FirstOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new ())
            {
                return filter == null ?
                    context.Set<TEntity>().ToList() :
                    context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new ())
            {
                var adddEntity = context.Entry(entity);
                adddEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
