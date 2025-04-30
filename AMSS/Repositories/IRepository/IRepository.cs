using AMSS.Aggregates;
using AMSS.Models;
using System.Linq.Expressions;

namespace AMSS.Repositories.IRepository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, string? includeProperties = null,
            int pageSize = 0, int pageNumber = 1);
        Task<IEnumerable<TEntity>> GetRESAsync(
           Expression<Func<TEntity, bool>> expression = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "");

        Task<PaginationResult<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> expression = null,
            int page = 0,
            int pageSize = 10,
            params SortExpression<TEntity>[] sortExpressions);

        IQueryable<TEntity> GetQueryAble(
           int page = 0,
           int pageSize = 10,
           params SortExpression<TEntity>[] sortExpressions);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter = null, bool tracked = true, string? includeProperties = null);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> GetByIdAsync(object id);
        Task CreateAsync(TEntity entity);
        Task CreateRangeAsync(IEnumerable<TEntity> entities);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task RemoveAsync(TEntity entity);
        Task SaveAsync();
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
    }
}
