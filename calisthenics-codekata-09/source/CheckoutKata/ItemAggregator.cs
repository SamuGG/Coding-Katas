using System.Diagnostics;

namespace CheckoutKata
{
    [DebuggerDisplay("Quantity = {m_CurrentQuantity}")]
    public class ItemAggregator
    {
        private int m_CurrentQuantity = 0;
        private readonly IPricingRule m_PricingRule;

        public ItemAggregator(IPricingRule pricingRule) => m_PricingRule = pricingRule;

        public void Aggregate(Money totalMoney)
        {
            Money unitPrice = m_PricingRule.GetUnitPrice(++m_CurrentQuantity);
            totalMoney.Add(unitPrice);
        }
    }
}
