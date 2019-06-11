using Polly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Refit
{
    public class CustomHttpClient: HttpClient
    {
        public Policy Policy { get; protected set; }

        public new async Task<HttpResponseMessage> DeleteAsync(Uri requestUri, CancellationToken cancellationToken)
        {
            if (this.Policy != null)
            {
                return await this.Policy.Execute<Task<HttpResponseMessage>>(() => base.DeleteAsync(requestUri, cancellationToken));
            }
            else
            {
                return await base.DeleteAsync(requestUri, cancellationToken);
            }
        }

        public new async Task<HttpResponseMessage> DeleteAsync(string requestUri, CancellationToken cancellationToken)
        {
            if (this.Policy != null)
            {
                return await this.Policy.Execute<Task<HttpResponseMessage>>(() => base.DeleteAsync(requestUri, cancellationToken));
            }
            else
            {
                return await base.DeleteAsync(requestUri, cancellationToken);
            }
        }

        public new async Task<HttpResponseMessage> DeleteAsync(string requestUri)
        {
            if (this.Policy != null)
            {
                return await this.Policy.Execute<Task<HttpResponseMessage>>(() => base.DeleteAsync(requestUri));
            }
            else
            {
                return await base.DeleteAsync(requestUri);
            }
        }

        public new async Task<HttpResponseMessage> DeleteAsync(Uri requestUri)
        {
            if (this.Policy != null)
            {
                return await this.Policy.Execute<Task<HttpResponseMessage>>(() => base.DeleteAsync(requestUri));
            }
            else
            {
                return await base.DeleteAsync(requestUri);
            }
        }

        public new async Task<HttpResponseMessage> GetAsync(string requestUri, CancellationToken cancellationToken)
        {
            if (this.Policy != null)
            {
                return await this.Policy.Execute<Task<HttpResponseMessage>>(() => base.GetAsync(requestUri, cancellationToken));
            }
            else
            {
                return await base.GetAsync(requestUri, cancellationToken);
            }
        }

        public new async Task<HttpResponseMessage> GetAsync(Uri requestUri)
        {
            if (this.Policy != null)
            {
                return await this.Policy.Execute<Task<HttpResponseMessage>>(() => base.GetAsync(requestUri));
            }
            else
            {
                return await base.GetAsync(requestUri);
            }
        }

        public new async Task<HttpResponseMessage> GetAsync(Uri requestUri, HttpCompletionOption completionOption)
        {
            if (this.Policy != null)
            {
                return await this.Policy.Execute(() => base.GetAsync(requestUri, completionOption));
            }
            else
            {
                return await base.GetAsync(requestUri, completionOption);
            }
        }

        public new async Task<HttpResponseMessage> GetAsync(string requestUri, HttpCompletionOption completionOption)
        {
            if (this.Policy != null)
            {
                return await this.Policy.Execute<Task<HttpResponseMessage>>(async () => await base.GetAsync(requestUri, completionOption));
            }
            else
            {
                return await base.GetAsync(requestUri, completionOption);
            }
        }

        public new async Task<HttpResponseMessage> GetAsync(Uri requestUri, CancellationToken cancellationToken)
        {
            if (this.Policy != null)
            {
                return await this.Policy.Execute<Task<HttpResponseMessage>>(async () => await base.DeleteAsync(requestUri, cancellationToken));
            }
            else
            {
                return await base.DeleteAsync(requestUri, cancellationToken);
            }
        }

        public new async Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            if (this.Policy != null)
            {
                return await this.Policy.Execute<Task<HttpResponseMessage>>(async () => await base.DeleteAsync(requestUri));
            }
            else
            {
                return await base.DeleteAsync(requestUri);
            }
        }

        public new async Task<HttpResponseMessage> GetAsync(string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken)
        {
            if (this.Policy != null)
            {
                return await this.Policy.Execute<Task<HttpResponseMessage>>(async () => await base.GetAsync(requestUri, completionOption, cancellationToken));
            }
            else
            {
                return await base.GetAsync(requestUri, completionOption, cancellationToken);
            }
        }

        public new async Task<HttpResponseMessage> GetAsync(Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken)
        {
            if (this.Policy != null)
            {
                return await this.Policy.Execute<Task<HttpResponseMessage>>(async () => await base.DeleteAsync(requestUri, cancellationToken));
            }
            else
            {
                return await base.DeleteAsync(requestUri, cancellationToken);
            }
        }

        public new async Task<byte[]> GetByteArrayAsync(string requestUri)
        {
            if (this.Policy != null)
            {
                return await this.Policy.Execute<Task<byte[]>>(async () => await base.GetByteArrayAsync(requestUri));
            }
            else
            {
                return await base.GetByteArrayAsync(requestUri);
            }
        }

        public new async Task<byte[]> GetByteArrayAsync(Uri requestUri)
        {
            if (this.Policy != null)
            {
                return await this.Policy.Execute<Task<byte[]>>(async () => await base.GetByteArrayAsync(requestUri));
            }
            else
            {
                return await base.GetByteArrayAsync(requestUri);
            }
        }

        public new async Task<Stream> GetStreamAsync(string requestUri)
        {
            if (this.Policy != null)
            {
                return await this.Policy.Execute<Task<Stream>>(async () => await base.GetStreamAsync(requestUri));
            }
            else
            {
                return await base.GetStreamAsync(requestUri);
            }
        }

        public new async Task<Stream> GetStreamAsync(Uri requestUri)
        {
            if (this.Policy != null)
            {
                return await this.Policy.Execute<Task<Stream>>(async () => await base.GetStreamAsync(requestUri));
            }
            else
            {
                return await base.GetStreamAsync(requestUri);
            }
        }

        public new async Task<string> GetStringAsync(string requestUri)
        {
            if (this.Policy != null)
            {
                return await this.Policy.Execute<Task<string>>(async () => await base.GetStringAsync(requestUri));
            }
            else
            {
                return await base.GetStringAsync(requestUri);
            }
        }

        public new async Task<string> GetStringAsync(Uri requestUri)
        {
            if (this.Policy != null)
            {
                return await this.Policy.Execute<Task<string>>(async () => await base.GetStringAsync(requestUri));
            }
            else
            {
                return await base.GetStringAsync(requestUri);
            }
        }

        public new async Task<HttpResponseMessage> PatchAsync(Uri requestUri, HttpContent content)
        {
            if (this.Policy != null)
            {
                return await this.Policy.Execute<Task<HttpResponseMessage>>(async () => await base.PatchAsync(requestUri, content));
            }
            else
            {
                return await base.PatchAsync(requestUri, content);
            }
        }

        public new async Task<HttpResponseMessage> PatchAsync(string requestUri, HttpContent content)
        {
            if (this.Policy != null)
            {
                return await this.Policy.Execute<Task<HttpResponseMessage>>(async () => await base.PatchAsync(requestUri, content));
            }
            else
            {
                return await base.PatchAsync(requestUri, content);
            }
        }

        public new async Task<HttpResponseMessage> PatchAsync(string requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            if (this.Policy != null)
            {
                return await this.Policy.Execute<Task<HttpResponseMessage>>(async () => await base.PatchAsync(requestUri, content, cancellationToken));
            }
            else
            {
                return await base.PatchAsync(requestUri, content, cancellationToken);
            }
        }

        public new async Task<HttpResponseMessage> PatchAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            if (this.Policy != null)
            {
                return await this.Policy.Execute<Task<HttpResponseMessage>>(async () => await base.PatchAsync(requestUri, content, cancellationToken));
            }
            else
            {
                return await base.PatchAsync(requestUri, content, cancellationToken);
            }
        }

        public new async Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content)
        {
            if (this.Policy != null)
            {
                return await this.Policy.Execute<Task<HttpResponseMessage>>(async () => await base.PostAsync(requestUri, content));
            }
            else
            {
                return await base.PostAsync(requestUri, content);
            }
        }

        public new async Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            if (this.Policy != null)
            {
                return await this.Policy.Execute<Task<HttpResponseMessage>>(async () => await base.PostAsync(requestUri, content, cancellationToken));
            }
            else
            {
                return await base.PostAsync(requestUri, content, cancellationToken);
            }
        }

        public new async Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content)
        {
            if (this.Policy != null)
            {
                return await this.Policy.Execute<Task<HttpResponseMessage>>(async () => await base.PostAsync(requestUri, content));
            }
            else
            {
                return await base.PostAsync(requestUri, content);
            }
        }

        public new async Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            if (this.Policy != null)
            {
                return await this.Policy.Execute<Task<HttpResponseMessage>>(async () => await base.PostAsync(requestUri, content, cancellationToken));
            }
            else
            {
                return await base.PostAsync(requestUri, content, cancellationToken);
            }
        }

        public new async Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content)
        {
            if (this.Policy != null)
            {
                return await this.Policy.Execute<Task<HttpResponseMessage>>(async () => await base.PutAsync(requestUri, content));
            }
            else
            {
                return await base.PutAsync(requestUri, content);
            }
        }

        public new async Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            if (this.Policy != null)
            {
                return await this.Policy.Execute<Task<HttpResponseMessage>>(async () => await base.PutAsync(requestUri, content, cancellationToken));
            }
            else
            {
                return await base.PutAsync(requestUri, content, cancellationToken);
            }
        }

        public new async Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            if (this.Policy != null)
            {
                return await this.Policy.Execute<Task<HttpResponseMessage>>(async () => await base.PutAsync(requestUri, content, cancellationToken));
            }
            else
            {
                return await base.PutAsync(requestUri, content, cancellationToken);
            }
        }

        public new async Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content)
        {
            if (this.Policy != null)
            {
                return await this.Policy.Execute<Task<HttpResponseMessage>>(async () => await base.PutAsync(requestUri, content));
            }
            else
            {
                return await base.PostAsync(requestUri, content);
            }
        }

        public new async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            if (this.Policy != null)
            {
                return await this.Policy.Execute<Task<HttpResponseMessage>>(async () => await base.SendAsync(request));
            }
            else
            {
                return await base.SendAsync(request);
            }
        }

        public new async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, HttpCompletionOption completionOption)
        {
            if (this.Policy != null)
            {
                return await this.Policy.Execute<Task<HttpResponseMessage>>(async () => await base.SendAsync(request, completionOption));
            }
            else
            {
                return await base.SendAsync(request, completionOption);
            }
        }

        public new async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, HttpCompletionOption completionOption, CancellationToken cancellationToken)
        {
            if (this.Policy != null)
            {
                return await this.Policy.Execute<Task<HttpResponseMessage>>(async () => await base.SendAsync(request, completionOption, cancellationToken));
            }
            else
            {
                return await base.SendAsync(request, completionOption, cancellationToken);
            }
        }

        public new async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (this.Policy != null)
            {
                return await this.Policy.Execute<Task<HttpResponseMessage>>(async () => await base.SendAsync(request, cancellationToken));
            }
            else
            {
                return await base.SendAsync(request, cancellationToken);
            }
        }
    }
}
