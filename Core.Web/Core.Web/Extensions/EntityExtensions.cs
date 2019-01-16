using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Core.Web.Models.ModelsHelper;
using Microsoft.EntityFrameworkCore;

namespace Core.Web.Extensions
{
    public static class EntityExtensions
    {
        public static IQueryable<T> AddFilter<T>(this IQueryable<T> query,IEnumerable<Filters> filters) where T : class, new()
        {
            T t = new T();
            foreach (var filter in filters)
            {
                var property = filter.Attribute;

                if (t.Validate(filter))
                {
                    if(filter.Operator == Operator.In)
                    {
                        query = query.Where("@0.Contains(@1)", property, filter.Values.First());
                        var list = query.ToList();
                    }
                    if(filter.Operator == Operator.NotIn)
                    {
                        var format = $"!{property}.Contains(\"{filter.Values.First()}\")";
                        query = query.Where(format);
                        var list = query.ToList();
                    }
                    else
                    {
                        var format = $"{property}.Contains(\"{filter.Values.First()}\")";
                        query = query.Where(format);
                        var list = query.ToList();
                    }
                }
            }
            return query;
        }

        public static bool Validate(this object obj, Filters filter)
        {
            bool ret = true;
            if(obj.GetType().GetProperty(filter.Attribute) == null)
            {
                return false;
            }

            if (filter.Values.Count() == 0)
                return false;
            if(filter.Values.Count() == 1)
            {
                var type = obj.GetType().GetProperty(filter.Attribute).PropertyType;
                if(!type.TryParse(filter.Values.First()))
                {
                    return false;
                }
            }
            else
            {

            }

            return ret;
        }
        private static bool TryParse(this Type type, string value)
        {
            if(type == typeof(Int32))
            {
                if (Int32.TryParse(value, out int result))
                    return true;
            }
            return false;
        }
    }
}
