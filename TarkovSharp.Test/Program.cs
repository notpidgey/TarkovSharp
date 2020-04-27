using System;
using System.Threading.Tasks;
using TarkovSharp;
using TarkovSharp.Http;

namespace TarkovSharp.Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using TarkovMarketClient market = new TarkovMarketClient("your_api_key");
            
            //Gets all items
            var allItems = await market.GetAllTarkovItem();
            foreach (Item t in allItems)
            {
                Console.WriteLine(t.Name + ": " +  t.BsgId);
            }
        }
    }
}