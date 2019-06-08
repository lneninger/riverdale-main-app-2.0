using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Framework.Refit
{
    public static class RefitExtensions
    {
        private static AsyncRetryPolicy<HttpResponseMessage> CreateTokenRefreshPolicy(this CustomHttpClient client, Func<string, Task> tokenRefreshed)
        {
            var policy = Policy
                .HandleResult<HttpResponseMessage>(message => message.StatusCode == HttpStatusCode.Unauthorized)
                .RetryAsync(1, async (result, retryCount, context) =>
                {
                    if (context.ContainsKey("refresh_token"))
                    {
                        var newAccessToken = await client.RefreshAccessToken(context["refresh_token"].ToString());
                        if (newAccessToken != null)
                        {
                            await tokenRefreshed(newAccessToken);

                            context["access_token"] = newAccessToken;
                        }
                    }
                });

            return policy;
        }

        private static async Task<string> RefreshAccessToken(this CustomHttpClient client, string refreshToken)
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
