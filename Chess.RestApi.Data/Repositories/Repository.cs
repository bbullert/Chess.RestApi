using Chess.RestApi.Data.Common;
using Chess.RestApi.Data.Entities;
using Chess.RestApi.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Chess.RestApi.Data.Repositories
{
    public class Repository<TKey, TEntity, TSearchCriteria> : IRepository<TKey, TEntity, TSearchCriteria>
        where TKey : IEquatable<TKey>
        where TEntity : class, IEntity<TKey>
        where TSearchCriteria : class, ISearchCriteria
    {
        protected readonly DbContext context;
        protected readonly DbSet<TEntity> dbSet;

        public DbContext Context => context;

        public Repository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetAsync(TKey id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<ISearchResult<TEntity>> SearchAsync(TSearchCriteria criteria)
        {
            return await SearchAsync(criteria, dbSet);
        }

        protected async Task<ISearchResult<TEntity>> SearchAsync(TSearchCriteria criteria, IQueryable<TEntity> query)
        {
            var count = await query.CountAsync();
            var rows = await query
                .OrderBy(criteria.SortOrder)
                .Skip((criteria.PageIndex - 1) * criteria.PageSize)
                .Take(criteria.PageSize)
                .ToListAsync();

            return new SearchResult<TEntity>()
            {
                PageIndex = criteria.PageIndex,
                PageSize = criteria.PageSize,
                TotalRows = count,
                Rows = rows
            };
        }

        public virtual async Task<TKey> AddAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            return entity.Id;
        }

        public virtual async Task<IEnumerable<TKey>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await dbSet.AddRangeAsync(entities);
            return entities.Select(x => x.Id);
        }

        public virtual void Remove(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public virtual void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public ITransaction BeginTransaction()
        {
            return new Transaction(context);
        }
    }
}
