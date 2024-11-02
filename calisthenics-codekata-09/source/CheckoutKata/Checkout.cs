namespace CheckoutKata
{
    public class Checkout
    {
        private readonly Money m_TotalMoney = new Money(0);
        private static readonly ItemCodesRepository m_KnownItemCodesRepository = new ItemCodesRepository();

        public Money Total() => m_TotalMoney;

        public void Scan(ItemCode itemCode)
        {
            ItemCode existingItemCode = m_KnownItemCodesRepository.Find(itemCode);
            if (existingItemCode != null)
            {
                existingItemCode.Scan(m_TotalMoney);
            }
        }
    }
}
