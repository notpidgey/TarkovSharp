using System;
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

        public async Task<ItemInfo> RequestAsyncIN(Uri baseAddress)
        {
            ItemInfo result;
            
            using (var response = await _client.GetAsync(baseAddress).ConfigureAwait(false))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new TarkovSharpException("Could not retrieve data.");
                }
                var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                result = JsonConvert.DeserializeObject<ItemInfo>(responseData);
            }
            return result;
        }
        
        public async Task<AllItems> RequestAsyncAI(Language language)
        {
            AllItems result;
            Uri baseAddress = new Uri("https://tarkov-market.com/api/v1/items/all");

            using (var response = await _client.GetAsync(baseAddress).ConfigureAwait(false))
            {
                if (!response.IsSuccessStatusCode)
                {
                    throw new TarkovSharpException("Could not retrieve data.");
                }
                var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                result = JsonConvert.DeserializeObject<AllItems>(responseData);
            }
            return result;
        }

        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}