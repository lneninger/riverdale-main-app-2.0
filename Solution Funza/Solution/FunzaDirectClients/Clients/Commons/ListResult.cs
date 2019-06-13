using System;
using System.Collections.Generic;
using System.Text;

namespace FunzaDirectClients.Clients.Commons
{
    

    public class ListResult<T>
    {
        public int TotalCount { get; set; }
        public List<T> Items { get; set; }
    }
}
