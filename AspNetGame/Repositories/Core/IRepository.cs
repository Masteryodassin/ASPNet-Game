using AspNetGame.Models.Game.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AspNetGame.Repositories
{
    public interface IRepository<TEntity, TId> : IDisposable
        where TId : struct, IComparable<TId>
        where TEntity : BaseEntity<TId>
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<IEnumerable<TEntity>> GetAllIncluding(params Expression<Func<TEntity, object>>[] includedProperties);

        Task<TEntity> Find(TId id);

        Task<TEntity> Find(TId id, params Expression<Func<TEntity, object>>[] includes);

        /*IEnumerable<TEntity> FindBy(
            params Tuple<Expression<Func<TEntity, object>>, object>[] criterion);*/

        Task<TEntity> Find(Predicate<TEntity> predicate);

        void Insert(TEntity entity);

        void BulkInsert(IEnumerable<TEntity> entities);
        void Delete(TId id);
        void Update(TEntity entity);
        Task Save();

        TEntity Attach(TEntity entity);
    }
}
