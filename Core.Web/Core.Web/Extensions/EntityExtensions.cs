using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public static IQueryable<T> AddFilter<T>(this IQueryable<T> query, IEnumerable<Filters> filters) where T : class, new()
        {
            T instance = new T();
            foreach (var filter in filters)
            {
                var property = filter.Attribute;

                var type = instance.GetType().GetProperty(property).PropertyType;

                var underlyingType = Nullable.GetUnderlyingType(type);

                if (underlyingType != null)
                    type = underlyingType;

                if (type == typeof(int))
                {
                    bool try1 = int.TryParse(filter.Values.First(), out int value1);
                    bool try2 = int.TryParse(filter.Values.Last(), out int value2);
                    if (try1 && try2)
                    {
                        query.CreateQuery(property, filter.Operator, value1, value2);
                    }
                }
                else if (type == typeof(double))
                {
                    bool try1 = double.TryParse(filter.Values.First(), out double value1);
                    bool try2 = double.TryParse(filter.Values.Last(), out double value2);
                    if (try1 && try2)
                    {
                        query.CreateQuery(property, filter.Operator, value1, value2);
                    }
                }
                else if (type == typeof(bool))
                {
                    string value = property == "1" ? "true" : property == "false" ? "false" : property;
                    query.CreateQuery(property, filter.Operator, value);
                }
                else
                {
                    query.CreateQuery(property, filter.Operator, filter.Values.First(),filter.Values.Last());
                }
            }
            return query;
        }

        private static IQueryable<T> CreateQuery<T>(this IQueryable<T> query, string propertyName, Operator @operator, params string[] propertyValue) where T : class, new()
        {
            switch (@operator)
            {
                case Operator.Between:
                    query = query.Where($"{propertyName} >= {propertyValue[0]} and {propertyName} <= {propertyValue[1]}");
                    break;
                case Operator.Equals:
                    query = query.Where($"{propertyName} == {propertyValue[0]}");
                    break;
                case Operator.GreaterThan:
                    query = query.Where($"{propertyName} > {propertyValue[0]}");
                    break;
                case Operator.GreaterThanOrEquals:
                    query = query.Where($"{propertyName} >= {propertyValue[0]}");
                    break;
                case Operator.In:
                    query = query.Where($"{propertyName}.Contains(\"{propertyValue[0]}\")");
                    break;
                case Operator.LowerThan:
                    query = query.Where($"{propertyName} < {propertyValue[0]}");
                    break;
                case Operator.LowerThanOrEuqals:
                    query = query.Where($"{propertyName} <= {propertyValue[0]}");
                    break;
                case Operator.NotBetween:
                    query = query.Where($"{propertyName} >= {propertyValue[0]} and {propertyName} <= {propertyValue[1]}");
                    break;
                case Operator.NotEquals:
                    query = query.Where($"{propertyName} != {propertyValue[0]}");
                    break;
                case Operator.NotIn:
                    query = query.Where($"!{propertyName}.Contains(\"{propertyValue[0]}\")");
                    break;
            }
            return query;
        }
        private static IQueryable<T> CreateQuery<T>(this IQueryable<T> query, string propertyName, Operator @operator, params int[] propertyValue) where T : class, new()
        {
            switch (@operator)
            {
                case Operator.Between:
                    query = query.Where($"ID >= 1");
                    query = query.Where($"ID <= 100");
                    break;
                case Operator.Equals:
                    query = query.Where($"{propertyName} == {propertyValue}");
                    break;
                case Operator.GreaterThan:
                    query = query.Where($"{propertyName} > {propertyValue}");
                    break;
                case Operator.GreaterThanOrEquals:
                    query = query.Where($"{propertyName} >= {propertyValue}");
                    break;
                case Operator.In:
                    query = query.Where($"{propertyName}.Contains(\"{propertyValue}\")");
                    break;
                case Operator.LowerThan:
                    query = query.Where($"{propertyName} < {propertyValue}");
                    break;
                case Operator.LowerThanOrEuqals:
                    query = query.Where($"{propertyName} <= {propertyValue}");
                    break;
                case Operator.NotBetween:
                    break;
                case Operator.NotEquals:
                    query = query.Where($"{propertyName} != {propertyValue}");
                    break;
                case Operator.NotIn:
                    query = query.Where($"!{propertyName}.Contains(\"{propertyValue}\")");
                    break;
            }
            return query;
        }
        private static IQueryable<T> CreateQuery<T>(this IQueryable<T> query, string propertyName, Operator @operator, params double[] propertyValue) where T : class, new()
        {
            switch (@operator)
            {
                case Operator.Between:
                    query = query.Where($"{propertyName} >= {propertyValue[0]} and {propertyName} <= {propertyValue[1]}");
                    break;
                case Operator.Equals:
                    query = query.Where($"{propertyName} == {propertyValue}");
                    break;
                case Operator.GreaterThan:
                    query = query.Where($"{propertyName} > {propertyValue}");
                    break;
                case Operator.GreaterThanOrEquals:
                    query = query.Where($"{propertyName} >= {propertyValue}");
                    break;
                case Operator.In:
                    query = query.Where($"{propertyName}.Contains(\"{propertyValue}\")");
                    break;
                case Operator.LowerThan:
                    query = query.Where($"{propertyName} < {propertyValue}");
                    break;
                case Operator.LowerThanOrEuqals:
                    query = query.Where($"{propertyName} <= {propertyValue}");
                    break;
                case Operator.NotBetween:
                    break;
                case Operator.NotEquals:
                    query = query.Where($"{propertyName} != {propertyValue}");
                    break;
                case Operator.NotIn:
                    query = query.Where($"!{propertyName}.Contains(\"{propertyValue}\")");
                    break;
            }
            return query;
        }
        private static bool Validate(this object obj, Filters filter)
        {
            if (obj.GetType().GetProperty(filter.Attribute) == null)
                return false;
            if (filter.Values.Count() == 0)
                return false;
            if (filter.Values.Count() == 1)
                return obj.ValidateProperty(filter.Attribute, filter.Values.First());
            else //Multi value in filter
            {
                foreach (string value in filter.Values)
                {
                    if (!obj.ValidateProperty(filter.Attribute, value))
                        return false;
                }
            }

            return true;
        }

        private static bool ValidateProperty(this object obj, string propertyName, string propertyValue)
        {
            var type = obj.GetType().GetProperty(propertyName).PropertyType;
            var underlyingType = Nullable.GetUnderlyingType(type);
            if (underlyingType != null)
                type = underlyingType;
            string value;
            // string "1" can't convert to bool
            if (type == typeof(bool))
            {
                value = propertyValue == "1" ? "true" : propertyValue == "false" ? "false" : propertyValue;
            }
            else
            {
                value = propertyValue;
            }

            if (ValidateType(value, type))
            {
                return true;
            }
            return false;
        }
        private static bool ValidateType(object obj, Type type)
        {
            try
            {
                var parsedValue = System.Convert.ChangeType(obj, type);
                return true;
            }
            catch { return false; }
        }
    }
}
