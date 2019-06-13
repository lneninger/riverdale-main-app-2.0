using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunzaDirectClients.Clients
{
    public interface IRefitClient
    {
        HttpClient Client { get; }
    }
}
