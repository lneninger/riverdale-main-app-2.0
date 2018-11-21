using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.EF.DbContextImpl.Persistance.Paging.Models
{
    public class PageQuery<T>: BasePageQuery
    {
        public T CustomerFilter { get; set; }
    }
}
