using System;
using System.Collections.Generic;

using System.Globalization;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TarkovSharp.Http
{
    public class Item
    {
        [JsonProperty("uid")]
        public Guid Uid { get; set; }

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
        public TraderName TraderName { get; set; }

        [JsonProperty("traderPrice")]
        public long TraderPrice { get; set; }

        [JsonProperty("traderPriceCur")]
        public TraderPriceCur TraderPriceCur { get; set; }

        [JsonProperty("updated")]
        public DateTimeOffset Updated { get; set; }

        [JsonProperty("slots")]
        [JsonConverter(typeof(DecodingChoiceConverter))]
        public long Slots { get; set; }

        [JsonProperty("diff24h")]
        public double Diff24H { get; set; }

        [JsonProperty("diff7days")]
        public double Diff7Days { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("link")]
        public Uri Link { get; set; }

        [JsonProperty("wikiLink")]
        public string WikiLink { get; set; }

        [JsonProperty("img")]
        public string Img { get; set; }

        [JsonProperty("imgBig")]
        public Uri ImgBig { get; set; }

        [JsonProperty("bsgId")]
        public string BsgId { get; set; }

        [JsonProperty("reference")]
        public Uri Reference { get; set; }
    }

    public enum TraderName { Empty, Mechanic, Peacekeeper, Skier, Therapist };

    public enum TraderPriceCur { Empty, Dollar, Ruble, Euro };

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                TraderNameConverter.Singleton,
                TraderPriceCurConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class DecodingChoiceConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            switch (reader.TokenType)
            {
                case JsonToken.Integer:
                    var integerValue = serializer.Deserialize<long>(reader);
                    return integerValue;
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    long l;
                    if (Int64.TryParse(stringValue, out l))
                    {
                        return l;
                    }
                    break;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value);
            return;
        }

        public static readonly DecodingChoiceConverter Singleton = new DecodingChoiceConverter();
    }

    internal class TraderNameConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TraderName) || t == typeof(TraderName?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "":
                    return TraderName.Empty;
                case "Mechanic":
                    return TraderName.Mechanic;
                case "Peacekeeper":
                    return TraderName.Peacekeeper;
                case "Skier":
                    return TraderName.Skier;
                case "Therapist":
                    return TraderName.Therapist;
            }
            throw new Exception("Cannot unmarshal type TraderName");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TraderName)untypedValue;
            switch (value)
            {
                case TraderName.Empty:
                    serializer.Serialize(writer, "");
                    return;
                case TraderName.Mechanic:
                    serializer.Serialize(writer, "Mechanic");
                    return;
                case TraderName.Peacekeeper:
                    serializer.Serialize(writer, "Peacekeeper");
                    return;
                case TraderName.Skier:
                    serializer.Serialize(writer, "Skier");
                    return;
                case TraderName.Therapist:
                    serializer.Serialize(writer, "Therapist");
                    return;
            }
            throw new Exception("Cannot marshal type TraderName");
        }

        public static readonly TraderNameConverter Singleton = new TraderNameConverter();
    }

    internal class TraderPriceCurConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TraderPriceCur) || t == typeof(TraderPriceCur?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "":
                    return TraderPriceCur.Empty;
                case "$":
                    return TraderPriceCur.Dollar;
                case "₽":
                    return TraderPriceCur.Ruble;
                case "€":
                    return TraderPriceCur.Euro;
            }
            throw new Exception("Cannot unmarshal type TraderPriceCur");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TraderPriceCur)untypedValue;
            switch (value)
            {
                case TraderPriceCur.Empty:
                    serializer.Serialize(writer, "");
                    return;
                case TraderPriceCur.Dollar:
                    serializer.Serialize(writer, "$");
                    return;
                case TraderPriceCur.Ruble:
                    serializer.Serialize(writer, "₽");
                    return;
                case TraderPriceCur.Euro:
                    serializer.Serialize(writer, "€");
                    return;
            }
            throw new Exception("Cannot marshal type TraderPriceCur");
        }

        public static readonly TraderPriceCurConverter Singleton = new TraderPriceCurConverter();
    }
}