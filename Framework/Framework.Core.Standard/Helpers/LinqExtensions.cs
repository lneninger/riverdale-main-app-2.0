﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Core.ReflectionHelpers
{
    public static class LinqExtensions
    {
        public static bool IsOrdered<T>(this IQueryable<T> queryable)
        {
            if (queryable == null)
            {
                throw new ArgumentNullException("queryable");
            }

            return queryable.Expression.Type == typeof(IOrderedQueryable<T>);
        }
    }
}
