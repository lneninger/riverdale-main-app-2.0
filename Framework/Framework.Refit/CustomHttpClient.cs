using Polly;
using Polly.Wrap;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Refit
{
    public class CustomHttpClient: HttpClient
    {
        public IList<IAsyncPolicy> Policies { get; set; }
        public HttpClient OriginalHttpClient { get; internal set; }

        //protected AsyncPolicyWrap PolicyWrap { get; set; }


        public CustomHttpClient()
        {

        }

        public CustomHttpClient(HttpMessageHandler handler) : base(handler)
        {
        }

        public new async Task<HttpResponseMessage> DeleteAsync(Uri requestUri, CancellationToken cancellationToken)
        {
            IAsyncPolicy policy = this.CombinePolicies();
            var context = new Context(requestUri.ToString(), new Dictionary<string, object>() { { "HttpClient", this } });

            if (policy != null)
            {
                return await policy.ExecuteAsync<HttpResponseMessage>(async(_context) => await base.DeleteAsync(requestUri, cancellationToken), context);
            }
            else
            {
                return await base.DeleteAsync(requestUri, cancellationToken);
            }
        }

       

        public new async Task<HttpResponseMessage> DeleteAsync(string requestUri, CancellationToken cancellationToken)
        {
            IAsyncPolicy policy = this.CombinePolicies();
            var context = new Context(requestUri.ToString(), new Dictionary<string, object>() { { "HttpClient", this } });

            if (policy != null)
            {
                return await policy.ExecuteAsync<HttpResponseMessage>(async() => await base.DeleteAsync(requestUri, cancellationToken));
            }
            else
            {
                return await base.DeleteAsync(requestUri, cancellationToken);
            }
        }

        public new async Task<HttpResponseMessage> DeleteAsync(string requestUri)
        {
            IAsyncPolicy policy = this.CombinePolicies();
            var context = new Context(requestUri.ToString(), new Dictionary<string, object>() { { "HttpClient", this } });

            if (policy != null)
            {
                return await policy.ExecuteAsync<HttpResponseMessage>(async() => await base.DeleteAsync(requestUri));
            }
            else
            {
                return await base.DeleteAsync(requestUri);
            }
        }

        public new async Task<HttpResponseMessage> DeleteAsync(Uri requestUri)
        {
            IAsyncPolicy policy = this.CombinePolicies();
            var context = new Context(requestUri.ToString(), new Dictionary<string, object>() { { "HttpClient", this } });

            if (policy != null)
            {
                return await policy.ExecuteAsync<HttpResponseMessage>(async() => await base.DeleteAsync(requestUri));
            }
            else
            {
                return await base.DeleteAsync(requestUri);
            }
        }

        public new async Task<HttpResponseMessage> GetAsync(string requestUri, CancellationToken cancellationToken)
        {
            IAsyncPolicy policy = this.CombinePolicies();
            var context = new Context(requestUri.ToString(), new Dictionary<string, object>() { { "HttpClient", this } });

            if (policy != null)
            {
                return await policy.ExecuteAsync<HttpResponseMessage>(async() => await base.GetAsync(requestUri, cancellationToken));
            }
            else
            {
                return await base.GetAsync(requestUri, cancellationToken);
            }
        }

        public new async Task<HttpResponseMessage> GetAsync(Uri requestUri)
        {
            IAsyncPolicy policy = this.CombinePolicies();
            var context = new Context(requestUri.ToString(), new Dictionary<string, object>() { { "HttpClient", this } });

            if (policy != null)
            {
                return await policy.ExecuteAsync<HttpResponseMessage>(async() => await base.GetAsync(requestUri));
            }
            else
            {
                return await base.GetAsync(requestUri);
            }
        }

        public new async Task<HttpResponseMessage> GetAsync(Uri requestUri, HttpCompletionOption completionOption)
        {
            IAsyncPolicy policy = this.CombinePolicies();
            var context = new Context(requestUri.ToString(), new Dictionary<string, object>() { { "HttpClient", this } });

            if (policy != null)
            {
                return await policy.ExecuteAsync(async() => await base.GetAsync(requestUri, completionOption));
            }
            else
            {
                return await base.GetAsync(requestUri, completionOption);
            }
        }

        public new async Task<HttpResponseMessage> GetAsync(string requestUri, HttpCompletionOption completionOption)
        {
            IAsyncPolicy policy = this.CombinePolicies();
            var context = new Context(requestUri.ToString(), new Dictionary<string, object>() { { "HttpClient", this } });

            if (policy != null)
            {
                return await policy.ExecuteAsync<HttpResponseMessage>(async () => await base.GetAsync(requestUri, completionOption));
            }
            else
            {
                return await base.GetAsync(requestUri, completionOption);
            }
        }

        public new async Task<HttpResponseMessage> GetAsync(Uri requestUri, CancellationToken cancellationToken)
        {
            IAsyncPolicy policy = this.CombinePolicies();
            var context = new Context(requestUri.ToString(), new Dictionary<string, object>() { { "HttpClient", this } });

            if (policy != null)
            {
                return await policy.ExecuteAsync<HttpResponseMessage>(async () => await base.DeleteAsync(requestUri, cancellationToken));
            }
            else
            {
                return await base.DeleteAsync(requestUri, cancellationToken);
            }
        }

        public new async Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            IAsyncPolicy policy = this.CombinePolicies();
            var context = new Context(requestUri.ToString(), new Dictionary<string, object>() { { "HttpClient", this } });

            if (policy != null)
            {
                return await policy.ExecuteAsync<HttpResponseMessage>(async () => await base.DeleteAsync(requestUri));
            }
            else
            {
                return await base.DeleteAsync(requestUri);
            }
        }

        public new async Task<HttpResponseMessage> GetAsync(string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken)
        {
            IAsyncPolicy policy = this.CombinePolicies();
            var context = new Context(requestUri.ToString(), new Dictionary<string, object>() { { "HttpClient", this } });

            if (policy != null)
            {
                return await policy.ExecuteAsync<HttpResponseMessage>(async () => await base.GetAsync(requestUri, completionOption, cancellationToken));
            }
            else
            {
                return await base.GetAsync(requestUri, completionOption, cancellationToken);
            }
        }

        public new async Task<HttpResponseMessage> GetAsync(Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken)
        {
            IAsyncPolicy policy = this.CombinePolicies();
            var context = new Context(requestUri.ToString(), new Dictionary<string, object>() { { "HttpClient", this } });

            if (policy != null)
            {
                return await policy.ExecuteAsync<HttpResponseMessage>(async () => await base.DeleteAsync(requestUri, cancellationToken));
            }
            else
            {
                return await base.DeleteAsync(requestUri, cancellationToken);
            }
        }

        public new async Task<byte[]> GetByteArrayAsync(string requestUri)
        {
            IAsyncPolicy policy = this.CombinePolicies();
            var context = new Context(requestUri.ToString(), new Dictionary<string, object>() { { "HttpClient", this } });

            if (policy != null)
            {
                return await policy.ExecuteAsync<byte[]>(async () => await base.GetByteArrayAsync(requestUri));
            }
            else
            {
                return await base.GetByteArrayAsync(requestUri);
            }
        }

        public new async Task<byte[]> GetByteArrayAsync(Uri requestUri)
        {
            IAsyncPolicy policy = this.CombinePolicies();
            var context = new Context(requestUri.ToString(), new Dictionary<string, object>() { { "HttpClient", this } });

            if (policy != null)
            {
                return await policy.ExecuteAsync<byte[]>(async () => await base.GetByteArrayAsync(requestUri));
            }
            else
            {
                return await base.GetByteArrayAsync(requestUri);
            }
        }

        public new async Task<Stream> GetStreamAsync(string requestUri)
        {
            IAsyncPolicy policy = this.CombinePolicies();
            var context = new Context(requestUri.ToString(), new Dictionary<string, object>() { { "HttpClient", this } });

            if (policy != null)
            {
                return await policy.ExecuteAsync<Stream>(async () => await base.GetStreamAsync(requestUri));
            }
            else
            {
                return await base.GetStreamAsync(requestUri);
            }
        }

        public new async Task<Stream> GetStreamAsync(Uri requestUri)
        {
            IAsyncPolicy policy = this.CombinePolicies();
            var context = new Context(requestUri.ToString(), new Dictionary<string, object>() { { "HttpClient", this } });

            if (policy != null)
            {
                return await policy.ExecuteAsync<Stream>(async () => await base.GetStreamAsync(requestUri));
            }
            else
            {
                return await base.GetStreamAsync(requestUri);
            }
        }

        public new async Task<string> GetStringAsync(string requestUri)
        {
            IAsyncPolicy policy = this.CombinePolicies();
            var context = new Context(requestUri.ToString(), new Dictionary<string, object>() { { "HttpClient", this } });

            if (policy != null)
            {
                return await policy.ExecuteAsync<string>(async () => await base.GetStringAsync(requestUri));
            }
            else
            {
                return await base.GetStringAsync(requestUri);
            }
        }

        public new async Task<string> GetStringAsync(Uri requestUri)
        {
            IAsyncPolicy policy = this.CombinePolicies();
            var context = new Context(requestUri.ToString(), new Dictionary<string, object>() { { "HttpClient", this } });

            if (policy != null)
            {
                return await policy.ExecuteAsync<string>(async () => await base.GetStringAsync(requestUri));
            }
            else
            {
                return await base.GetStringAsync(requestUri);
            }
        }

        public new async Task<HttpResponseMessage> PatchAsync(Uri requestUri, HttpContent content)
        {
            IAsyncPolicy policy = this.CombinePolicies();
            var context = new Context(requestUri.ToString(), new Dictionary<string, object>() { { "HttpClient", this } });

            if (policy != null)
            {
                return await policy.ExecuteAsync<HttpResponseMessage>(async () => await base.PatchAsync(requestUri, content));
            }
            else
            {
                return await base.PatchAsync(requestUri, content);
            }
        }

        public new async Task<HttpResponseMessage> PatchAsync(string requestUri, HttpContent content)
        {
            IAsyncPolicy policy = this.CombinePolicies();
            var context = new Context(requestUri.ToString(), new Dictionary<string, object>() { { "HttpClient", this } });

            if (policy != null)
            {
                return await policy.ExecuteAsync<HttpResponseMessage>(async () => await base.PatchAsync(requestUri, content));
            }
            else
            {
                return await base.PatchAsync(requestUri, content);
            }
        }

        public new async Task<HttpResponseMessage> PatchAsync(string requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            IAsyncPolicy policy = this.CombinePolicies();
            var context = new Context(requestUri.ToString(), new Dictionary<string, object>() { { "HttpClient", this } });

            if (policy != null)
            {
                return await policy.ExecuteAsync<HttpResponseMessage>(async () => await base.PatchAsync(requestUri, content, cancellationToken));
            }
            else
            {
                return await base.PatchAsync(requestUri, content, cancellationToken);
            }
        }

        public new async Task<HttpResponseMessage> PatchAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            IAsyncPolicy policy = this.CombinePolicies();
            var context = new Context(requestUri.ToString(), new Dictionary<string, object>() { { "HttpClient", this } });

            if (policy != null)
            {
                return await policy.ExecuteAsync<HttpResponseMessage>(async () => await base.PatchAsync(requestUri, content, cancellationToken));
            }
            else
            {
                return await base.PatchAsync(requestUri, content, cancellationToken);
            }
        }

        public new async Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content)
        {
            IAsyncPolicy policy = this.CombinePolicies();
            var context = new Context(requestUri.ToString(), new Dictionary<string, object>() { { "HttpClient", this } });

            if (policy != null)
            {
                return await policy.ExecuteAsync<HttpResponseMessage>(async () => await base.PostAsync(requestUri, content));
            }
            else
            {
                return await base.PostAsync(requestUri, content);
            }
        }

        public new async Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            IAsyncPolicy policy = this.CombinePolicies();
            var context = new Context(requestUri.ToString(), new Dictionary<string, object>() { { "HttpClient", this } });

            if (policy != null)
            {
                return await policy.ExecuteAsync<HttpResponseMessage>(async () => await base.PostAsync(requestUri, content, cancellationToken));
            }
            else
            {
                return await base.PostAsync(requestUri, content, cancellationToken);
            }
        }

        public new async Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content)
        {
            IAsyncPolicy policy = this.CombinePolicies();
            var context = new Context(requestUri.ToString(), new Dictionary<string, object>() { { "HttpClient", this } });

            if (policy != null)
            {
                return await policy.ExecuteAsync<HttpResponseMessage>(async () => await base.PostAsync(requestUri, content));
            }
            else
            {
                return await base.PostAsync(requestUri, content);
            }
        }

        public new async Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            IAsyncPolicy policy = this.CombinePolicies();
            var context = new Context(requestUri.ToString(), new Dictionary<string, object>() { { "HttpClient", this } });

            if (policy != null)
            {
                return await policy.ExecuteAsync<HttpResponseMessage>(async () => await base.PostAsync(requestUri, content, cancellationToken));
            }
            else
            {
                return await base.PostAsync(requestUri, content, cancellationToken);
            }
        }

        public new async Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content)
        {
            IAsyncPolicy policy = this.CombinePolicies();
            var context = new Context(requestUri.ToString(), new Dictionary<string, object>() { { "HttpClient", this } });

            if (policy != null)
            {
                return await policy.ExecuteAsync<HttpResponseMessage>(async () => await base.PutAsync(requestUri, content));
            }
            else
            {
                return await base.PutAsync(requestUri, content);
            }
        }

        public new async Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            IAsyncPolicy policy = this.CombinePolicies();
            var context = new Context(requestUri.ToString(), new Dictionary<string, object>() { { "HttpClient", this } });

            if (policy != null)
            {
                return await policy.ExecuteAsync<HttpResponseMessage>(async () => await base.PutAsync(requestUri, content, cancellationToken));
            }
            else
            {
                return await base.PutAsync(requestUri, content, cancellationToken);
            }
        }

        public new async Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            IAsyncPolicy policy = this.CombinePolicies();
            var context = new Context(requestUri.ToString(), new Dictionary<string, object>() { { "HttpClient", this } });

            if (policy != null)
            {
                return await policy.ExecuteAsync<HttpResponseMessage>(async () => await base.PutAsync(requestUri, content, cancellationToken));
            }
            else
            {
                return await base.PutAsync(requestUri, content, cancellationToken);
            }
        }

        public new async Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content)
        {
            IAsyncPolicy policy = this.CombinePolicies();
            var context = new Context(requestUri.ToString(), new Dictionary<string, object>() { { "HttpClient", this } });

            if (policy != null)
            {
                return await policy.ExecuteAsync<HttpResponseMessage>(async () => await base.PutAsync(requestUri, content));
            }
            else
            {
                return await base.PostAsync(requestUri, content);
            }
        }

        public new async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            IAsyncPolicy policy = this.CombinePolicies();
            var context = new Context(request.RequestUri.ToString(), new Dictionary<string, object>() { { "HttpClient", this } });

            if (policy != null)
            {
                return await policy.ExecuteAsync<HttpResponseMessage>(async () => await base.SendAsync(request));
            }
            else
            {
                return await base.SendAsync(request);
            }
        }

        public new async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, HttpCompletionOption completionOption)
        {
            IAsyncPolicy policy = this.CombinePolicies();
            var context = new Context(request.RequestUri.ToString(), new Dictionary<string, object>() { { "HttpClient", this } });

            if (policy != null)
            {
                return await policy.ExecuteAsync<HttpResponseMessage>(async () => await base.SendAsync(request, completionOption));
            }
            else
            {
                return await base.SendAsync(request, completionOption);
            }
        }

        public new async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, HttpCompletionOption completionOption, CancellationToken cancellationToken)
        {
            IAsyncPolicy policy = this.CombinePolicies();
            var context = new Context(request.RequestUri.ToString(), new Dictionary<string, object>() { { "HttpClient", this } });

            if (policy != null)
            {
                return await policy.ExecuteAsync<HttpResponseMessage>(async () => await base.SendAsync(request, completionOption, cancellationToken));
            }
            else
            {
                return await base.SendAsync(request, completionOption, cancellationToken);
            }
        }

        public new async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            IAsyncPolicy policy = this.CombinePolicies();
            var context = new Context(request.RequestUri.ToString(), new Dictionary<string, object>() { { "HttpClient", this } });

            if (policy != null)
            {
                return await policy.ExecuteAsync<HttpResponseMessage>(async () => await base.SendAsync(request, cancellationToken));
            }
            else
            {
                return await base.SendAsync(request, cancellationToken);
            }
        }


        private IAsyncPolicy CombinePolicies()
        {
            IAsyncPolicy result = null;

            if (this.Policies != null && this.Policies.Count > 0)
            {
                if (this.Policies.Count > 1)
                {
                    result = Policy.WrapAsync(this.Policies.ToArray());
                }
                else
                {
                    result = this.Policies[0];
                }
            }

            return result;
        }
    }
}
