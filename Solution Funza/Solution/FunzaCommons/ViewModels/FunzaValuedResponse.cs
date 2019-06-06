using Framework.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ViewModels
{
    public class FunzaResponse<T> : OperationResponse<T>
    {
        public string NewToken { get; set; }
    }
}
