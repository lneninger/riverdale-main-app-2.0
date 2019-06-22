using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Refit
{
    public interface IRefitClientConfigurator
    {
        Task<T> SetFunzaToken<T>(T proxy, Microsoft.AspNetCore.Http.HttpRequest request = null) where T : IRefitClient;
    }
}
