using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TarkovSharp.Utils;
using Utf8Json;
using Utf8Json.Resolvers;

namespace TarkovSharp.Http
{
    public class HttpClientService : HttpClient
    {
        public static HttpClientService CreateService(string apiKey)
        {
            var httpClientInstance = new HttpClientService();

            httpClientInstance.BaseAddress = new Uri(TarkovMarketConstants.BaseUrl);

            httpClientInstance.DefaultRequestHeaders.Add("x-api-key", apiKey);
            httpClientInstance.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(TarkovMarketConstants.MediaType));

            return httpClientInstance;
        }

        public async Task<T> RequestAsync<T>(string requestUri)
        {
            var response = await GetAsync(requestUri).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var resultStream = await result.ToStreamAsync().ConfigureAwait(false);

            return await JsonSerializer.DeserializeAsync<T>(resultStream, StandardResolver.AllowPrivate).ConfigureAwait(false);
        }
    }
}
