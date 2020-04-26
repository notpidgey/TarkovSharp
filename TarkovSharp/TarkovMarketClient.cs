using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TarkovSharp.API.Enums;
using TarkovSharp.API.Models;
using TarkovSharp.Http;
using TarkovSharp.Utils;

namespace TarkovSharp
{
    public class TarkovMarketClient : IDisposable
    {
        private readonly HttpClientService _httpClientService;

        private readonly TarkovLanguage _lang;

        public TarkovMarketClient(string apiKey, TarkovLanguage lang = TarkovLanguage.EN)
        {
            _lang = lang;
            _lang.EnsureValidLanguage();

            _httpClientService = HttpClientService.CreateService(apiKey);
        }

        public async Task<TarkovItem> GetTarkovItemByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("No item name specified.", nameof(name));
            }

            var result = await _httpClientService.RequestAsync<IReadOnlyCollection<TarkovItem>>($"item?q={HttpUtility.UrlEncode(name)}");

            return result.FirstOrDefault();
        }

        public void Dispose() => _httpClientService.Dispose();
    }
}