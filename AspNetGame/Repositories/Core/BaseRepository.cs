using AspNetGame.Models.Game.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace AspNetGame.Repositories
{
    public class BaseRepository<TEntity, TId> : IRepository<TEntity, TId>
        where TId : struct, IComparable<TId>
        where TEntity : BaseEntity<TId>
    {

        protected BaseRepository(DbContext context)
        {
            Context = context;
        }

        public DbContext Context { get; }
        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual Expression<Func<TEntity, object>>[] DefaultIncludedProperties()
        {
            return new Expression<Func<TEntity, object>>[] { };
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await GetAllIncluding(DefaultIncludedProperties());
        }

        /*public virtual async Task<IEnumerable<TEntity>> GetAll(params string[] includedProperties)
        {
             DbQuery<TEntity> dbQuery = null;
             DbSet<TEntity> dbSet = Context.Set<TEntity>();
             foreach (string include in includedProperties)
             {
                 dbQuery = dbSet.Include(include);
             }

             return dbQuery.AsEnumerable();
        }*/
        public async Task<IEnumerable<TEntity>> GetAllIncluding(
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> queryable = Context.Set<TEntity>();
            foreach (var includeProperty in includeProperties)
            {
                queryable = queryable.Include(includeProperty);
            }

            return await queryable.ToListAsync();
        } 


        public virtual async Task<TEntity> Find(TId id)
        {
            return (await GetAll()).SingleOrDefault(e => e.Id.Equals(id));
        }

        public virtual async Task<TEntity> Find(TId id, params Expression<Func<TEntity, object>>[] includes)
        {
            return (await GetAllIncluding(includes)).SingleOrDefault(e => e.Id.Equals(id));
        }

        public virtual void Insert(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public virtual void BulkInsert(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
        }

        public virtual void Delete(TId id)
        {
            Context.Set<TEntity>().Remove(Context.Set<TEntity>().Find(id));
        }

        public virtual void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual async Task Save()
        {
            await Context.SaveChangesAsync();
        }
    }
}