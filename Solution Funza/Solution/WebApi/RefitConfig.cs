﻿using FunzaCommons;
using FunzaDirectClients.InternalClients.Quote;
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


            services.AddRefitClient<IAuthenticationClient>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(funzaSettings.AuthenticationSettingsCollection["full"].AuthenticationURL));
        }
    }
}
