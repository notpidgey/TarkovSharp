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
            using TarkovMarketWrapper market = new TarkovMarketWrapper("YoureNotGettingMyAPIKey", Language.En);
            
            var allItems = await market.GetAllItems(Language.Cn);

            foreach (AllItems.Item item in allItems.item)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}