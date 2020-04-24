using System.Threading.Tasks;
using TarkovSharp.Http;

namespace TarkovSharp.Interfaces
{
    public interface ITarkovMarket
    {
        Task<ItemInfo> FindItemByName(string itemName, Language language = Language.None);
        Task<ItemInfo> FindItemByUid(string uid, Language language = Language.None);
        Task<AllItems> GetAllItems(Language language = Language.None);
    }
}