using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Framework.EF.DbContextImpl.Persistance.Models.Sorting
{
    public delegate IEnumerable<SortItem<T>> DefaultSortItemsDelegate<T>();
    public class SortingDTO<T>
    {
        public SortingDTO(Dictionary<string, string> rawSorting, List<Expression<Func<T, object>>> sortExpressions)
        {
            this.RawSorting = rawSorting;
            this.SortExpressions = sortExpressions;
        }

        public Dictionary<string, string> RawSorting { get; set; }

        public List<Expression<Func<T, object>>> SortExpressions { get; set; }

        public DefaultSortItemsDelegate<T> DefaultSortItemsDelegate { get; set; }

        public Dictionary<string, string> CustomFilterPropertyMapping { get; set; }
    }
}
