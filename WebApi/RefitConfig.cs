using ApplicationLogic.AppSettings;
using Framework.Refit;
using FunzaInternalClients.Quote;
using FunzaInternalClients.Security;
using FunzaInternalClients.Sync;
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

                    //var policies = new IAsyncPolicy[] {
                    //    c.CustomRefreshTokenConfiguration(),
                    //    c.CustomLoggingConfiguration()
                    //};

                    //(c as CustomHttpClient).Policies = Policy.WrapAsync(policies);
                });

            services.AddRefitClient<IInternalQuoteClient>()
                .AddTypedClient<CustomHttpClient>(c => new CustomHttpClient())
                .ConfigureHttpClient(c => {
                    c.BaseAddress = new Uri(new Uri(funzaSettings.FunzaUrl), "quotes");

                    //var policies = new IAsyncPolicy[] {
                    //    c.CustomRefreshTokenConfiguration(),
                    //    c.CustomLoggingConfiguration()
                    //};

                    //(c as CustomHttpClient).Policies = Policy.WrapAsync(policies);
                });

            services.AddRefitClient<IInternalSyncClient>()
                .AddTypedClient<CustomHttpClient>(c => new CustomHttpClient())
                .ConfigureHttpClient(c => {
                    c.BaseAddress = new Uri(new Uri(funzaSettings.FunzaUrl), "sync");
                });
        }


        public static IAsyncPolicy CustomRefreshTokenConfiguration(this HttpClient c)
        {

            Polly.IAsyncPolicy result = null;

            if (c is CustomHttpClient)
            {
                var customClient = c as CustomHttpClient;
                result = customClient.CreateTokenRefreshPolicy(async (responseResult, retryCount, context) =>
                {
                    if (context.ContainsKey("refresh_token"))
                    {
                        string newAccessToken = await customClient.RefreshAccessToken(context["refresh_token"].ToString());
                        if (newAccessToken != null)
                        {
                            context["access_token"] = newAccessToken;
                        }
                    }
                });
            }

            return result;
        }

        public static IAsyncPolicy CustomLoggingConfiguration(this HttpClient c)
        {

            Polly.IAsyncPolicy result = null;

            if (c is CustomHttpClient)
            {
                var customClient = c as CustomHttpClient;
                result = Policy.Handle<Exception>().FallbackAsync(async (cancelationToken) =>
                {
                    //_logger.Log(exception, context);
                    //throw exception;
                    await Task.FromResult(true);
                },
                async (exception) => {
                    await Task.FromResult(true);
                }
                );
            }

            return result;
        }

    }
}
