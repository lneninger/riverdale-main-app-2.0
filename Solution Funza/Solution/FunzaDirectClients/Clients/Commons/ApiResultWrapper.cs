using System;
using System.Collections.Generic;
using System.Text;

namespace FunzaDirectClients.Clients.Commons
{
    public class ApiResultWrapper<T>
    {
        public T Result { get; set; }

        public string TargetUrl { get; set; }

        public bool Success { get; set; }

        public bool unAuthorizedRequest { get; set; }

        public bool __abp { get; set; }
    }
}
