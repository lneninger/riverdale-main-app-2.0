using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Retry;
using Refit;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Framework.Refit
{
    public static class RefitExtensions
    {
        public static T InstanciateClient<T>(IServiceProvider serviceProvider = null, HttpMessageHandler messageHandler = null) where T : class
        {
            T result = null;
            HttpClient httpClient = null;
            if (messageHandler != null)
            {
                httpClient = new HttpClient(messageHandler);
            }
            else
            {
                httpClient = new HttpClient();
            }




            return InstanciateClient<T>(httpClient, serviceProvider = null);
        }

        public static T InstanciateClient<T>(HttpClient httpClient, IServiceProvider serviceProvider = null) where T : class
        {
            T result = null;
            if (serviceProvider == null)
            {
                result = RestService.For<T>(httpClient);
            }
            else
            {
                result = RestService.For<T>(httpClient, serviceProvider.GetService<IRequestBuilder<T>>());
            }

            return result;
        }

        public static CustomHttpClient AddPolicy(this CustomHttpClient client, IAsyncPolicy policy)
        {
            client.Policies.Add(policy);
            return client;
        }



        /// <summary>
        /// Adds a Refit client to the DI container
        /// </summary>
        /// <typeparam name="T">Type of the Refit interface</typeparam>
        /// <param name="services">container</param>
        /// <param name="settings">Optional. Settings to configure the instance with</param>
        /// <returns></returns>
        public static IHttpClientBuilder AddCustomRefitClient<T>(this IServiceCollection services, RefitSettings settings = null) where T : class
        {
            services.AddSingleton(provider => RequestBuilder.ForType<T>(settings));

            return services.AddHttpClient(typeof(T).AssemblyQualifiedName)
                           .AddTypedClient((client, serviceProvider) =>
                           {
                               var result = InstanciateClient<T>(client, serviceProvider);
                               return result;
                                   //return RestService.For<T>(client, serviceProvider.GetService<IRequestBuilder<T>>());
                               });
        }

        //public static CustomHttpClient Set

        //public static AsyncRetryPolicy CreateTokenRefreshPolicy(this CustomHttpClient client, Func<DelegateResult<HttpResponseMessage>, int, Context, Task> refreshToken)
        //{
        //    var policy = Policy
        //        .Handle<Exception>(ex => ex is HttpRequestException)
        //        //.HandleResult(message => message.StatusCode == HttpStatusCode.Unauthorized)
        //        .RetryAsync(1, async (result, retryCount, context) =>
        //        {
        //            await refreshToken(result, retryCount, context);
        //        });


        //    return policy;
        //}

        public static AsyncRetryPolicy CreateTokenRefreshPolicy(this CustomHttpClient client, Func<Exception, int, Context, Task> refreshToken)
        {
            var policy = Policy
                .Handle<Exception>(ex => ex is HttpRequestException)
                //.HandleResult(message => message.StatusCode == HttpStatusCode.Unauthorized)
                .RetryAsync(1, async (result, retryCount, context) =>
                {
                    await refreshToken(result, retryCount, context);
                });


            return policy;
        }


        public static async Task<string> RefreshAccessToken(this CustomHttpClient client, string refreshToken)
        {
            var refreshMessage = new HttpRequestMessage(HttpMethod.Post, "/oauth2/v4/token")
            {
                Content = new FormUrlEncodedContent(new KeyValuePair<string, string>[]
                {
                //new KeyValuePair<string, string>("client_id", _configuration["Authentication:Google:ClientId"]),
                //new KeyValuePair<string, string>("client_secret", _configuration["Authentication:Google:ClientSecret"]),
                //new KeyValuePair<string, string>("refresh_token", refreshToken),
                //new KeyValuePair<string, string>("grant_type", "refresh_token")
                })
            };

            var response = await client.SendAsync(refreshMessage);

            if (response.IsSuccessStatusCode)
            {
                //var tokenResponse = await response.Content.ReadAsAsync<TokenResponse>();
                var tokenResponse = new TokenResponse();

                return tokenResponse.AccessToken;
            }

            // return null if we cannot request a new token
            return null;
        }


        public class TokenResponse
        {
            public string AccessToken { get; set; }
        }
    }
}
