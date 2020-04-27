using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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

        public async Task<Item> GetTarkovItemByNameAsync(string name, TarkovLanguage lang = TarkovLanguage.None)
        {
            if (lang == TarkovLanguage.None)
                lang = _lang;
            
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("No item name specified.", nameof(name));
            }

            var result = await _httpClientService.RequestAsync($"item?q={HttpUtility.UrlEncode(name)}&lang={lang}");

            return result.FirstOrDefault();
        }

        public async Task<List<Item>> GetAllTarkovItem(TarkovLanguage lang = TarkovLanguage.None)
        {
            if (lang == TarkovLanguage.None)
                lang = _lang;
            
            var result = await _httpClientService.RequestAsync($"items/all?lang={lang}");

            return result;
        }

        public void Dispose() => _httpClientService.Dispose();
    }
}