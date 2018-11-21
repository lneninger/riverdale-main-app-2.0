using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.EF.DbContextImpl.Persistance.Paging.Models
{
    public class PageResult<T> where T: class
    {
        public PageResult()
        {
            this.Items = new List<T>();
        }

        public int Size { get; set; }

        public int Total { get; set; }

        public int FilteredTotal { get; set; }

        public List<T> Items { get; set; }


    }
}
