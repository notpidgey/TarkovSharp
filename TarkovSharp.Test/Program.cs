using System;
using System.Threading.Tasks;
using TarkovSharp;
using TarkovSharp.API.Enums;
using TarkovSharp.Http;

namespace TarkovSharp.Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var tarkovApiKey = Environment.GetEnvironmentVariable("TARKOV_API_KEY");
            var tarkovClient = new TarkovMarketClient(tarkovApiKey);

            var x = await tarkovClient.GetTarkovItemByNameAsync("btc");

            Console.WriteLine(x.Uid);
        }
    }
}