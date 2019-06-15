using Framework.EF.DbContextImpl.Persistance.Paging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunzaDirectClients.Clients.Commons
{
    

    public class ListResult<T>
    {
        public int TotalCount { get; set; }
        public List<T> Items { get; set; }
    }


    public static class ListResultExtensions
    {
        public static PageResult<T> ToPageResult<T>(this ListResult<T> listResult, BasePageQuery query = null) where T: class
        {
            var result = new PageResult<T>();
            result.Items = listResult.Items;
            result.Size = query?.PageSize ?? 0;
            result.TotalCount = listResult.TotalCount;
            result.FilteredCount = listResult.TotalCount;

            return result;
        }

        public static PageResult<R> ToPageResult<T, R>(this ListResult<T> listResult, Func<T, R> map, BasePageQuery query = null) where T : class where R: class
        {
            var result = new PageResult<R>();
            result.Items = listResult.Items.Select(map).ToList();
            result.Size = query?.PageSize ?? 0;
            result.TotalCount = listResult.TotalCount;
            result.FilteredCount = listResult.TotalCount;

            return result;
        }

    }

}
