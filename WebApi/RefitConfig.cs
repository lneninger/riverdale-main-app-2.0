using ApplicationLogic.AppSettings;
using Framework.Refit;
using FunzaInternalClients.Quote;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Retry;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApi
{
    public static class RefitConfig
    {
        public static void Configure(IConfiguration configuration, IServiceCollection services) {

            var funzaSettings = configuration.GetSection("FunzaSettings").Get<FunzaSettings>();

            var settings = new RefitSettings();
            services.AddRefitClient<IInternalSecurityClient>()
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri(new Uri(funzaSettings.FunzaUrl), "security");
                });

            services.AddRefitClient<IInternalQuoteClient>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(new Uri(funzaSettings.FunzaUrl), "quotes"));
        }

       
    }
}
