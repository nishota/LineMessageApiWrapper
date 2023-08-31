using System.Collections.Specialized;
using System.Text.Json;
using Aimnext.MessageApiWrapper.App.Models.Http;

namespace Aimnext.MessageApiWrapper.App.Services;

public class RequestExecutor<T>
{
    private readonly IHttpClientFactory _httpClientFactory;
    public RequestExecutor(
        IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<Response<T>> PostAsync(
        string factoryName,
        string url,
        HttpContent content)
    {
        using (var client = _httpClientFactory.CreateClient(factoryName))
        {
            var uriBuilder = new UriBuilder(client.BaseAddress ?? throw new ArgumentNullException())
            {
                Path = url,
            };
            var req = new HttpRequestMessage()
            {
                RequestUri = uriBuilder.Uri,
                Method = HttpMethod.Post,
                Content = content
            };

            var result = await client.SendAsync(req);
            var statusCode = result.StatusCode;
            var contentsFromApi = await result.Content.ReadAsStringAsync();

            if (!result.IsSuccessStatusCode)
            {
                return new Response<T>
                {
                    StatusCode = statusCode,
                    Content = default(T),
                    Message = contentsFromApi
                };
            }

            return new Response<T>
            {
                StatusCode = statusCode,
                Content = JsonSerializer.Deserialize<T>(contentsFromApi)
            };
        }
    }

    public async Task<Response<T>> GetAsync(
        string factoryName,
        string url,
        NameValueCollection content)
    {
        using (var client = _httpClientFactory.CreateClient(factoryName))
        {
            var uriBuilder = new UriBuilder(client.BaseAddress ?? throw new ArgumentNullException())
            {
                Path = url,
                Query = content.ToString()
            };
            var req = new HttpRequestMessage()
            {
                RequestUri = uriBuilder.Uri,
                Method = HttpMethod.Get,
            };

            var result = await client.SendAsync(req);
            var statusCode = result.StatusCode;
            var contentsFromApi = await result.Content.ReadAsStringAsync();

            if (!result.IsSuccessStatusCode)
            {
                return new Response<T>
                {
                    StatusCode = statusCode,
                    Content = default(T),
                    Message = contentsFromApi
                };
            }

            return new Response<T>
            {
                StatusCode = statusCode,
                Content = JsonSerializer.Deserialize<T>(contentsFromApi)
            };
        }
    }
}