using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TarkovSharp.Utils;

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

        public async Task<List<Item>> RequestAsync(string requestUri)
        {
            var response = await GetAsync(requestUri).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<List<Item>>(result, Converter.Settings);
        }
    }
}