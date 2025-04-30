using AMSS.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using AMSS.Repositories.IRepository;
using AMSS.Aggregates;
using System.Collections.Generic;
using AMSS.Models;
using System.ComponentModel;
using AMSS.Extensions;

namespace AMSS.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<TEntity> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<TEntity>();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            await SaveAsync();
        }

        public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            await dbSet.AddRangeAsync(entities);
            await SaveAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _db.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _db.AddRangeAsync(entities);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null, bool tracked = true, string? includeProperties = null)
        {
            IQueryable<TEntity> query = dbSet;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, string? includeProperties = null, 
            int pageSize = 0, int pageNumber = 1)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (pageSize > 0)
            {
                if (pageSize > 100)
                {
                    pageSize = 100;
                }
                //skip0.take(5)
                //page number- 2     || page size -5
                //skip(5*(1)) take(5)
                query = query.Skip(pageSize * (pageNumber - 1)).Take(pageSize);
            }
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.ToListAsync();
        }

        public async Task RemoveAsync(TEntity entity)
        {
            dbSet.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await dbSet.FirstOrDefaultAsync(expression);
        }

        public virtual async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await dbSet.SingleOrDefaultAsync(expression);
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            dbSet.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            dbSet.UpdateRange(entities);
        }

        public async Task<IEnumerable<TEntity>> GetRESAsync(Expression<Func<TEntity, bool>> expression = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (expression != null)
            {
                query = query.Where(expression);
            }

            foreach (var includeProperty in includeProperties
                         .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return await(orderBy != null ? orderBy(query).ToListAsync() : query.ToListAsync());
        }

        public IQueryable<TEntity> GetQueryAble(int page = 0, int pageSize = 10, params SortExpression<TEntity>[] sortExpressions)
        {
            IQueryable<TEntity> query = dbSet;

            query = GetOrderedQueryable(query, sortExpressions);

            return query;
        }

        public IQueryable<TEntity> GetOrderedQueryable(IQueryable<TEntity> query,
            params SortExpression<TEntity>[] sortExpressions)
        {
            IOrderedQueryable<TEntity> orderedQuery = null;
            for (var i = 0; i < sortExpressions.Length; i++)
            {
                if (i == 0 || orderedQuery == null)
                {
                    orderedQuery = sortExpressions[i].SortDirection == ListSortDirection.Ascending
                        ? query.OrderBy(sortExpressions[i].SortBy)
                        : query.OrderByDescending(sortExpressions[i].SortBy);
                    continue;
                }

                orderedQuery = sortExpressions[i].SortDirection == ListSortDirection.Ascending
                    ? orderedQuery.ThenBy(sortExpressions[i].SortBy)
                    : orderedQuery.ThenByDescending(sortExpressions[i].SortBy);
            }

            query = orderedQuery ?? query;

            return query;
        }

        public async Task<PaginationResult<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> expression = null,
            int page = 1,
            int pageSize = 10,
            params SortExpression<TEntity>[] sortExpressions)
        {
            IQueryable<TEntity> query = dbSet;

            if (expression != null)
            {
                query = query.Where(expression);
            }

            query = GetOrderedQueryable(query, sortExpressions);

            return await query.ToPaginationAsync(page, pageSize);
        }
    }
}
