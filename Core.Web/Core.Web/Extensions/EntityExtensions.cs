using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Core.Web.Models.ModelsHelper;
using Microsoft.EntityFrameworkCore;

namespace Core.Web.Extensions
{
    public static class EntityExtensions
    {
        public static IQueryable<T> AddFilter<T>(this DbSet<T> entity, DbContext dbContext,IEnumerable<Filters> filters) where T : class
        {
            var query = dbContext.Set<T>();
            foreach(var filter in filters)
            {
                var property = filter.Attribute;
                dbContext.Set<T>().Where(x => x.GetValueByName<T>(filter.Attribute) == filter.Values);
            }
            return query.AsQueryable<T>();
        }

        public static object GetValueByName<T>(this T obj, string propertyName) where T : class
        {
            PropertyInfo prop = typeof(T).GetProperty(propertyName);
            return prop.GetValue(obj);

        }
    }
}
