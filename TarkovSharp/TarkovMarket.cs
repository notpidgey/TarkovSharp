﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TarkovSharp.Http;

namespace TarkovSharp
{
    public class TarkovMarketWrapper : IDisposable
    {
        private readonly Language _lang;
        private readonly HttpRequester _httpRequester;

        public TarkovMarketWrapper(string apiKey, Language lang)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentException("API key cannot be empty.");
            }
            _lang = lang;

            _httpRequester = new HttpRequester(apiKey);
        }
        
        public async Task<List<Item>> FindItemByName(string itemName, Language language = Language.None)
        {
            if (language == Language.None)
                language = _lang;
            
            var baseAddress = new Uri("https://tarkov-market.com/api/v1/item?q=" + itemName.Replace(" ", "_") + "&lang=" + language.ToString().ToLower());
            
            return await _httpRequester.RequestAsyncIN(baseAddress);
        }
        
        public async Task<List<Item>> FindItemByUid(string uid, Language language = Language.None)
        {
            if (language == Language.None)
                language = _lang;
            
            var baseAddress = new Uri("https://tarkov-market.com/api/v1/item?uid=" + uid + "&lang=" + language.ToString().ToLower());
            
            return await _httpRequester.RequestAsyncIN(baseAddress);
        }
        
        public async Task<List<Item>> GetAllItems(Language language = Language.None)
        {
            if (language == Language.None)
                language = _lang;
            
            return await _httpRequester.RequestAsyncAI(language);
        }

        public void Dispose()
        {
            _httpRequester.Dispose();
        }
    }
}