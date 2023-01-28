using Chess.RestApi.Data.Common;
using Chess.RestApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chess.RestApi.Data.Repositories
{
    public interface IRepository<TKey, TEntity, TSearchCriteria>
        where TKey : IEquatable<TKey>
        where TEntity : class, IEntity<TKey>
        where TSearchCriteria : class, ISearchCriteria
    {
        DbContext Context { get; }
        Task<TKey> AddAsync(TEntity entity);
        Task<IEnumerable<TKey>> AddRangeAsync(IEnumerable<TEntity> entities);
        Task<TEntity> GetAsync(TKey id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<ISearchResult<TEntity>> SearchAsync(TSearchCriteria criteria);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        Task SaveChangesAsync();
        ITransaction BeginTransaction();
    }
}
