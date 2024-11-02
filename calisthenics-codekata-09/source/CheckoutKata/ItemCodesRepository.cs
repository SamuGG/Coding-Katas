using System.Linq;

namespace CheckoutKata
{
    public class ItemCodesRepository
    {
        private static readonly ItemCode[] m_ItemCodes =
        {
            ItemCodeFactory.CreateItemA(),
            ItemCodeFactory.CreateItemB(),
            ItemCodeFactory.CreateItemC(),
            ItemCodeFactory.CreateItemD()
        };

        public ItemCode Find(ItemCode itemCode) => m_ItemCodes.FirstOrDefault(x => x.Equals(itemCode));
    }
}
