using AMSS.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Linq.Expressions;

namespace AMSS.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<PaginationResult<T>> ToPaginationAsync<T>(this IQueryable<T> query,
            int page, int limit) where T : class
        {
            if (limit <= 0) limit = 1;
            var skip = (page - 1) * limit;
            var queryCount = await query.CountAsync();
            return new PaginationResult<T>
            {
                CurrentPage = page,
                Limit = limit,
                TotalRow = queryCount,
                TotalPage = queryCount / limit,
                Skip = skip,
                Data = await query.Skip(skip).Take(limit).ToListAsync()
            };
        }

        public static IQueryable<T> OrderByPropertyName<T>(this IQueryable<T> query, string propertyName,
            ListSortDirection listSortDirection) where T : class
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentException("Order by property should not empty", nameof(propertyName));
            }

            var type = typeof(T);
            var arg = Expression.Parameter(type, "x");
            var propertyInfo = type.GetProperty(propertyName);
            var expression = Expression.Property(arg, propertyInfo!);
            type = propertyInfo.PropertyType;

            var delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            var lambda = Expression.Lambda(delegateType, expression, arg);

            var methodName = listSortDirection == ListSortDirection.Descending ? "OrderByDescending" : "OrderBy";
            var result = typeof(Queryable).GetMethods().Single(
                    method => method.Name == methodName
                              && method.IsGenericMethodDefinition
                              && method.GetGenericArguments().Length == 2
                              && method.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(T), type)
                .Invoke(null, new object[] { query, lambda });
            return (IQueryable<T>)result!;
        }
    }
}
