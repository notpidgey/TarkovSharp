using System.Runtime.Serialization;

namespace TarkovSharp.Http
{
    public enum TarkovLanguage
    {
        None,
        [DataMember(Name = "en")] 
        EN,
        [DataMember(Name = "ru")] 
        RU,
        [DataMember(Name = "de")] 
        DE,
        [DataMember(Name = "fr")] 
        FR,
        [DataMember(Name = "es")] 
        ES,
        [DataMember(Name = "cn")] 
        CN
    }
}