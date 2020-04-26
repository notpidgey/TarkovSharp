using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TarkovSharp.Http
{
    public class HttpRequester : IDisposable
    {
        private readonly HttpClient _client;
        
        public HttpRequester(string apiKey)
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.TryAddWithoutValidation("x-api-key", apiKey);
            _client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
        }

        public async Task<List<Item>> RequestAsyncIN(Uri baseAddress)
        {
            List<Item> result;
            
            using (var response = await _client.GetAsync(baseAddress).ConfigureAwait(false))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new TarkovSharpException("Could not retrieve data.");
                }
                var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                result = JsonConvert.DeserializeObject<List<Item>>(responseData, Converter.Settings);
            }
            return result;
        }
        
        public async Task<List<Item>> RequestAsyncAI(Language language)
        {
            List<Item> result;
            Uri baseAddress = new Uri("https://tarkov-market.com/api/v1/items/all");

            using (var response = await _client.GetAsync(baseAddress).ConfigureAwait(false))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new TarkovSharpException("Could not retrieve data.");
                }
                var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                result = JsonConvert.DeserializeObject<List<Item>>(responseData, Converter.Settings);
            }
            return result;
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}