using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TarkovSharp.Http
{
    public partial class AllItems
    {
        public Item[] item { get; set; }

        public class Item
        {
            [JsonProperty("uid")]
            public Guid Uid { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }
    }
}