using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Framework.Refit
{
    public interface IRefitClient
    {
        HttpClient Client { get; }
    }
}
