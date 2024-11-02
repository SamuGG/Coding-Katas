namespace CheckoutKata
{
    public class PackDiscountPricingRule : IPricingRule
    {
        private readonly Money m_FullUnitPrice;
        private readonly PackDiscountEvaluator m_DiscountEvaluator;

        public PackDiscountPricingRule(Money fullUnitPrice, PackDiscountEvaluator discountEvaluator)
        {
            m_FullUnitPrice = fullUnitPrice;
            m_DiscountEvaluator = discountEvaluator;
        }

        public Money GetUnitPrice(int itemQuantity) => m_DiscountEvaluator.GetPrice(itemQuantity, m_FullUnitPrice);
    }
}
