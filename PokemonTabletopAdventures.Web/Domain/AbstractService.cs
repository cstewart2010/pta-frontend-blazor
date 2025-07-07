using PokemonTabletopAdventures.Web.Constants;
using System.Net;

namespace PokemonTabletopAdventures.Web.Domain
{
    public abstract class AbstractService
    {
        private HttpClient? _httpClient;

        internal bool IsReadyInternal { get; }

        public AbstractService(IConfiguration configuration, string route)
        {
            var rootUrl = configuration.GetValue<string>(Routes.ApiRootUrl);
            if (rootUrl != null)
            {
                var rootUri = new Uri(rootUrl);
                var uri = new Uri(rootUri, route);
                _httpClient = new HttpClient
                {
                    BaseAddress = uri,
                };

                IsReadyInternal = true;
            }
        }

        public async Task<Response> SendAsync(
            string endpoint,
            HttpMethod method,
            string? accessToken = null,
            string? sessionAuth = null)
        {
            var builder = new HttpRequestMessageBuilder(method, _httpClient!.BaseAddress!, endpoint);
            if (accessToken != null)
            {
                builder.WithHeader(PtaHeaderNames.AccessToken, accessToken);
            }
            if (sessionAuth != null)
            {
                builder.WithHeader(PtaHeaderNames.SessionAuth, sessionAuth);
            }
            return await Send(builder);
        }

        public async Task<Response> SendAsync<TRequest>(
            string endpoint, HttpMethod method,
            TRequest payload,
            string contentType,
            string? accessToken = null,
            string? sessionAuth = null)
        {
            var builder = new HttpRequestMessageBuilder(method, _httpClient!.BaseAddress!, endpoint);
            builder.WithPayload(contentType, payload);
            if (accessToken != null)
            {
                builder.WithHeader(PtaHeaderNames.AccessToken, accessToken);
            }
            if (sessionAuth != null)
            {
                builder.WithHeader(PtaHeaderNames.SessionAuth, sessionAuth);
            }
            return await Send(builder);
        }

        public async Task<Response<TResponse>> SendAsync<TResponse>(
            string endpoint,
            HttpMethod method,
            string? accessToken = null,
            string? sessionAuth = null)
        {
            var builder = new HttpRequestMessageBuilder(method, _httpClient!.BaseAddress!, endpoint);
            if (accessToken != null)
            {
                builder.WithHeader(PtaHeaderNames.AccessToken, accessToken);
            }
            if (sessionAuth != null)
            {
                builder.WithHeader(PtaHeaderNames.SessionAuth, sessionAuth);
            }
            var message = builder.Build();
            return await Send<TResponse>(builder);
        }

        public async Task<Response<TResponse>> SendAsync<TRequest, TResponse>(
            string endpoint,
            HttpMethod method,
            TRequest payload,
            string contentType,
            string? accessToken = null,
            string? sessionAuth = null)
        {
            var builder = new HttpRequestMessageBuilder(method, _httpClient!.BaseAddress!, endpoint);
            builder.WithPayload(contentType, payload);
            if (accessToken != null)
            {
                builder.WithHeader(PtaHeaderNames.AccessToken, accessToken);
            }
            if (sessionAuth != null)
            {
                builder.WithHeader(PtaHeaderNames.SessionAuth, sessionAuth);
            }
            var message = builder.Build();
            var response = await _httpClient.SendAsync(message);
            return await Send<TResponse>(builder);
        }

        private async Task<Response> Send(HttpRequestMessageBuilder builder)
        {
            var message = builder.Build();
            var responseMessage = await _httpClient!.SendAsync(message);
            var content = await responseMessage.Content.ReadAsStringAsync();
            return new Response(responseMessage, content);
        }

        private async Task<Response<T>> Send<T>(HttpRequestMessageBuilder builder)
        {
            var message = builder.Build();
            var responseMessage = await _httpClient!.SendAsync(message);
            var content = await responseMessage.Content.ReadAsStringAsync();
            return new Response<T>(responseMessage, content);
        }
    }
}
