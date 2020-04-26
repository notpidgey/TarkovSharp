using System;
using System.IO;
using System.Threading.Tasks;
using TarkovSharp.API.Enums;

namespace TarkovSharp.Utils
{
    public static class TarkovMarketExtensions
    {
        public static async Task<Stream> ToStreamAsync(this string str)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);

            await writer.WriteAsync(str).ConfigureAwait(false);
            await writer.FlushAsync().ConfigureAwait(false);

            stream.Position = 0;

            return stream;
        }

        public static string GetLanguage(this TarkovLanguage language)
        {
            return language switch
            {
                TarkovLanguage.EN => "en",
                TarkovLanguage.RU => "ru",
                TarkovLanguage.DE => "de",
                TarkovLanguage.FR => "fr",
                TarkovLanguage.ES => "es",
                TarkovLanguage.CN => "cn",
                _ => throw new ArgumentException("Invalid language enum value", nameof(language))
            };
        }

        public static void EnsureValidLanguage(this TarkovLanguage language) =>
            _ = language.GetLanguage();
    }
}
