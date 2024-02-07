using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Repositories.Extensions
{
    public static class RepositoryExtensions
    {
        public static IQueryable<T> OrderByQuery<T>(this IQueryable<T> queryable, string queryString)
        {
            if (string.IsNullOrWhiteSpace(queryString)) 
            {
                return queryable;
            }
            // account,datacreated desc
            var orderParams = queryString.Trim().Split(',');
            var propertyInfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);//反射
            var orderQueryBuilder = new StringBuilder();
            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;
                var propertyFromQueryName = param.Split(' ')[0];
                var objectProperty = propertyInfo.FirstOrDefault(pi => pi.Name.Equals(
                    propertyFromQueryName,StringComparison.InvariantCultureIgnoreCase));
                if (objectProperty == null)
                    continue;
                var sortingOrder = param.EndsWith("desc")?"descending":"ascending";
                orderQueryBuilder.Append($"{objectProperty.Name} {sortingOrder},");
            }
            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',',' ');

            // account ascending,datacreated descending
            return queryable.OrderBy(orderQuery);
        }
    }
}
