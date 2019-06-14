using Framework.Refit;
using FunzaCommons;
using FunzaDirectClients.InternalClients.Quote;
using FunzaDirectClients.InternalClients.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Wrap;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Polly.Extensions.Http;
using Polly.Timeout;
using Microsoft.Extensions.Logging;
using System.Threading;
using FunzaDirectClients.Clients;
using FunzaDirectClients.Clients.Season;

namespace WebApi
{
    public static class RefitConfig
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static void Configure(IConfiguration configuration, IServiceCollection services, IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;

            var funzaSettings = configuration.GetSection("FunzaSettings").Get<FunzaSettings>();

           

            var tokenRefreshPolicy = Polly.Policy
             .HandleResult<HttpResponseMessage>(ex => ex.StatusCode == System.Net.HttpStatusCode.Unauthorized)
             .OrTransientHttpError()
             .RetryAsync(3, async (result, retryCount, context) => {
                 //throw new Exception();
                 var logginService = serviceProvider.GetService<ILogger<Startup>>();
                 logginService.LogWarning("Making retry {retry}.", retryCount);

                 var funzaResponse = await Refit.RestService.For<ISecurityClient>("https://ffapswprodcotizadorapi.azurewebsites.net/api/TokenAuth/Authenticate").Authenticate(new FunzaDirectClients.InternalClients.Security.Models.AuthenticationModel { UserNameOrEmailAddress = "miguel@riverdalefarms.com", Password = "LuisRincon18!" });
                 var funzaResult = funzaResponse.Content;
                 context["access_token"] = "";// funzaResult.accessToken;

             });


            var generalPolicy = Polly.Policy
             .HandleResult<HttpResponseMessage>(ex => !ex.IsSuccessStatusCode)
             .WaitAndRetryAsync(3, (retryCount, context) => {
                 //throw new Exception();
                 return TimeSpan.FromMilliseconds(100);
                 //var b = 0;
             },
             onRetry: (outcome, retryAttempt, context) =>
             {
                 var b = 0;
                 //throw new Exception();
                 //services.GetService<ILogger<MyServiceHttpClient>>()
                 //    .LogWarning("Delaying for {delay}ms, then making retry {retry}.", timespan.TotalMilliseconds, retryAttempt);
             });

            var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(10);

            services.AddRefitClient<ISecurityClient>()
                .ConfigureHttpClient(c => {
                    c.BaseAddress = new Uri(new Uri(funzaSettings.FunzaBaseURL), funzaSettings.AuthenticationRelativeURL);
                })
                .AddPolicyHandler(timeoutPolicy)
                .AddPolicyHandler(tokenRefreshPolicy);

            services.AddRefitClient<IQuoteClient>()
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri(new Uri(funzaSettings.FunzaBaseURL), funzaSettings.QuotesRelativeURL);
                })
                .AddPolicyHandler(timeoutPolicy)
                .AddPolicyHandler(tokenRefreshPolicy);

            services.AddRefitClient<ISeasonClient>()
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri(new Uri(funzaSettings.FunzaBaseURL), funzaSettings.SeasonsRelativeURL);
                })
                .AddPolicyHandler(timeoutPolicy)
                .AddPolicyHandler(tokenRefreshPolicy);

            services.AddRefitClient<IGoodPriceClient>()
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri(new Uri(funzaSettings.FunzaBaseURL), funzaSettings.GoodPricesRelativeURL);
                })
                .AddPolicyHandler(timeoutPolicy)
                .AddPolicyHandler(tokenRefreshPolicy);
        }

        public static async Task<T> SetFunzaToken<T>(this T proxy, Microsoft.AspNetCore.Http.HttpRequest request) where T: IRefitClient
        {
            try
            {
                //throw new Exception();
                var logginService = ServiceProvider.GetService<ILogger<Startup>>();
                //logginService.LogWarning("Making retry {retry}.", retryCount);

                var funzaResponse = await Refit.RestService.For<ISecurityClient>("https://ffapswprodcotizadorapi.azurewebsites.net/api/TokenAuth/Authenticate").Authenticate(new FunzaDirectClients.InternalClients.Security.Models.AuthenticationModel { UserNameOrEmailAddress = "miguel@riverdalefarms.com", Password = "LuisRincon18!" });
                var funzaResult = funzaResponse.Content;
                proxy.Client.DefaultRequestHeaders.Add("Authorization", $"Bearer {funzaResult.Result.accessToken}");
            }
            catch (Exception ex)
            {
                throw;
            }

            return proxy;

        }



        public static HttpClient GetHttpClient() {
            return new HttpClient(new AuthenticatedParameterizedHttpClientHandler(GetToken));
        }

        public static async Task<string> GetToken(HttpRequestMessage requestMessage)
        {
            // The AcquireTokenAsync call will prompt with a UI if necessary
            // Or otherwise silently use a refresh token to return
            // a valid access token	
            //var token = await context.AcquireTokenAsync("http://my.service.uri/app", "clientId", new Uri("callback://complete"));

            return await Task.FromResult("");
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
    }
}
