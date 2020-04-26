using System;
using System.Runtime.Serialization;

namespace TarkovSharp.API.Models
{
    public class TarkovItem
    {
        [DataMember(Name = "uid")]
        public string Uid { get; private set; }

        [DataMember(Name = "bsgId")]
        public string BsgId { get; private set; }

        [DataMember(Name = "name")]
        public string Name { get; private set; }

        [DataMember(Name = "shortName")]
        public string ShortName { get; private set; }

        [DataMember(Name = "price")]
        public decimal Price { get; private set; }

        [DataMember(Name = "avg24hPrice")]
        public decimal Average24hPrice { get; private set; }

        [DataMember(Name = "avg7daysPrice")]
        public decimal Average7dPrice { get; private set; }

        [DataMember(Name = "traderName")]
        public string TraderName { get; private set; }

        [DataMember(Name = "traderPrice")]
        public decimal TraderPrice { get; private set; }

        [DataMember(Name = "traderPriceCur")]
        public string TraderPriceCurrency { get; private set; }

        [DataMember(Name = "updated")]
        public DateTime LastUpdated { get; private set; }

        [DataMember(Name = "slots")]
        public int Slots { get; private set; }

        [DataMember(Name = "diff24h")]
        public double Difference24h { get; private set; }

        [DataMember(Name = "diff7d")]
        public double Difference7d { get; private set; }

        [DataMember(Name = "icon")]
        public string IconUrl { get; private set; }

        [DataMember(Name = "link")]
        public string LinkUrl { get; private set; }

        [DataMember(Name = "wikiLink")]
        public string WikiLinkUrl { get; private set; }

        [DataMember(Name = "img")]
        public string ImageUrl { get; private set; }

        [DataMember(Name = "imgBig")]
        public string BigImageUrl { get; private set; }

        [DataMember(Name = "reference")]
        public string ReferenceUrl { get; private set; }
    }
}
