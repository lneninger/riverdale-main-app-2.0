using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLogic.Business.Commons.Funza.DTOs
{
    public class FunzaPageResult<T>
    {
        public FunzaPageResultInternal<T> Result { get; set; }
        public string TargetUrl { get; set; }
        public bool Success { get; set; }
        public string Error { get; set; }
        public bool UnAuthorizedRequest { get; set; }
    }

    public class FunzaPageResultInternal<T>
    {
        public int TotalCount { get; set; }
        public List<T> Items { get; set; }
    }
}
