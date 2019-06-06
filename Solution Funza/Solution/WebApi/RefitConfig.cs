using FunzaCommons;
using FunzaDirectClients.InternalClients.Quote;
using FunzaDirectClients.InternalClients.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public static class RefitConfig
    {
        public static void Configure(IConfiguration configuration, IServiceCollection services) {

            var funzaSettings = configuration.GetSection("FunzaSettings").Get<FunzaSettings>();

            services.AddRefitClient<ISecurityClient>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(new Uri(funzaSettings.FunzaBaseURL), funzaSettings.AuthenticationRelativeURL));

            services.AddRefitClient<IQuoteClient>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(new Uri(funzaSettings.FunzaBaseURL), funzaSettings.QuotesRelativeURL));
        }
    }
}
