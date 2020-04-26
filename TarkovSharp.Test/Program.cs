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
            using TarkovMarketWrapper market = new TarkovMarketWrapper("your_api_key", Language.En);

            //Gets information about bTC
            var item = await market.FindItemByName("btc");
            Console.WriteLine(item[0].Name);

            //Gets all items
            var allItems = await market.GetAllItems();
            foreach (Item t in allItems)
            {
                Console.WriteLine(t.Name + ": " +  t.BsgId);
            }
        }
    }
}