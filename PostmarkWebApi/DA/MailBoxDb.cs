using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace PostmarkWebApi.DA
{
    internal class MailboxDb
    {
        public TEntity Add<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity == null)
            {
                return null;
            }

            using (var context = new MailboxContext())
            {
                var addedEntity = context.Set<TEntity>().Add(entity);
                context.SaveChanges();
                return addedEntity;
            }
        }

        public TEntity Update<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity == null)
            {
                return null;
            }

            using (var context = new MailboxContext())
            {
                // Make sure DbContext is tracking this entry
                var entry = context.Entry(entity);
                if (entry.State == EntityState.Detached)
                {
                    context.Set<TEntity>().Attach(entity);
                }

                entry.State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
        }

        public TEntity Delete<TEntity>(TEntity entity) where TEntity : class
        {
            if (entity == null)
            {
                return null;
            }

            using (var context = new MailboxContext())
            {
                // Make sure DbContext is tracking this entry
                var entry = context.Entry(entity);
                if (entry.State == EntityState.Detached)
                {
                    context.Set<TEntity>().Attach(entity);
                }

                var deletedEntity = context.Set<TEntity>().Remove(entity);
                return deletedEntity;
            }
        }

        public IQueryable<TEntity> Get<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class
        {
            using (var context = new MailboxContext())
            {
                IQueryable<TEntity> query = context.Set<TEntity>();

                query = filter != null ? query.Where(filter) : query;

                return query;
            }
        }


        
    }
}