using System.Linq.Expressions;

namespace Chess.RestApi.Data.Extensions
{
    public static class IQueryableExtensions
    {
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, IEnumerable<string> sortOrder)
        {
            var first = sortOrder?.FirstOrDefault();
            if (first == null) return source.OrderBy(x => 0);

            var property = first.Split(" ");
            var query = source.OrderBy(property[0], property[1]);

            foreach (var item in sortOrder.Skip(1))
            {
                property = item.Split(" ");
                query = query.ThenBy(property[0], property[1]);
            }

            return query;
        }

        private static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName, string order)
        {
            propertyName = char.ToUpper(propertyName[0]) + propertyName.Substring(1);
            return order == "asc" ? 
                source.OrderBy(propertyName) : 
                source.OrderByDescending(propertyName);
        }

        private static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string propertyName, string order)
        {
            propertyName = char.ToUpper(propertyName[0]) + propertyName.Substring(1);
            return order == "asc" ?
                source.ThenBy(propertyName) :
                source.ThenByDescending(propertyName);
        }

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName)
        {
            return source.OrderBy(ToLambda<T>(propertyName));
        }

        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string propertyName)
        {
            return source.OrderByDescending(ToLambda<T>(propertyName));
        }

        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string propertyName)
        {
            return source.ThenBy(ToLambda<T>(propertyName));
        }

        public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> source, string propertyName)
        {
            return source.ThenByDescending(ToLambda<T>(propertyName));
        }

        private static Expression<Func<T, object>> ToLambda<T>(string propertyName)
        {
            var parameter = Expression.Parameter(typeof(T));
            var property = Expression.Property(parameter, propertyName);
            var propAsObject = Expression.Convert(property, typeof(object));
            return Expression.Lambda<Func<T, object>>(propAsObject, parameter);
        }
    }
}
