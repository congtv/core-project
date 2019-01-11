using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Web.Models.ModelsHelper;
using Microsoft.EntityFrameworkCore;

namespace Core.Web.Extensions
{
    public static class EntityExtensions
    {
        public static IQueryable AddFilter<T>(this DbSet<T> entity, DbContext dbContext,IEnumerable<Filters> filters) where T : class
        {
            IQueryable query = dbContext.Set<T>();
            foreach(var filter in filters)
            {
                var property = filter.Attribute;
                //dbContext.Set<T>().Where(x => )
            }
            return query;
        }
        public static IQueryable GetTypeOfX<T>(this DbSet<T> entity,Expression<Func<T, bool>> where) where T : class
        {
            return null;
            //return this.Context.MyTypeOfXes.Where(where);
        }
    }
}
