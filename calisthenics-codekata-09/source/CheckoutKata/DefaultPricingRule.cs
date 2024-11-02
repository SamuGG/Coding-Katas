namespace CheckoutKata
{
    public class DefaultPricingRule : IPricingRule
    {
        private readonly Money m_PredefinedUnitPrice;

        public DefaultPricingRule(Money predefinedUnitPrice) => m_PredefinedUnitPrice = predefinedUnitPrice;

        public Money GetUnitPrice(int _) => m_PredefinedUnitPrice;
    }
}
