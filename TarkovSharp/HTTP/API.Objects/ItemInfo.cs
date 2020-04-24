using System;
using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TarkovSharp.Http
{
    public partial class ItemInfo
    {
        public Item[] item { get; set; }
        
        public class Item
        {
            [JsonProperty("uid")]
            public Guid Uid { get; set; }

            [JsonProperty("bsgId")]
            public string BsgId { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("shortName")]
            public string ShortName { get; set; }

            [JsonProperty("price")]
            public long Price { get; set; }

            [JsonProperty("avg24hPrice")]
            public long Avg24HPrice { get; set; }

            [JsonProperty("avg7daysPrice")]
            public long Avg7DaysPrice { get; set; }

            [JsonProperty("traderName")]
            public string TraderName { get; set; }

            [JsonProperty("traderPrice")]
            public long TraderPrice { get; set; }

            [JsonProperty("traderPriceCur")]
            public string TraderPriceCur { get; set; }

            [JsonProperty("updated")]
            public DateTimeOffset Updated { get; set; }

            [JsonProperty("slots")]
            public long Slots { get; set; }

            [JsonProperty("diff24h")]
            public double Diff24H { get; set; }

            [JsonProperty("diff7days")]
            public double Diff7Days { get; set; }

            [JsonProperty("icon")]
            public Uri Icon { get; set; }

            [JsonProperty("link")]
            public Uri Link { get; set; }

            [JsonProperty("wikiLink")]
            public Uri WikiLink { get; set; }

            [JsonProperty("img")]
            public Uri Img { get; set; }

            [JsonProperty("imgBig")]
            public Uri ImgBig { get; set; }

            [JsonProperty("reference")]
            public Uri Reference { get; set; }
        }

    }
}