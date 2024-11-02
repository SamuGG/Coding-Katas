using CheckoutKata;

namespace CheckoutKataTests
{
    internal static class ItemCodeTestHelper
    {
        public static ItemCode CreateWithDefaultPricingRule(Money predefinedUnitPrice) => 
            new ItemCode("A", new DefaultPricingRule(predefinedUnitPrice));

        public static ItemCode CreateWithPackDiscountPricingRule(Money fullUnitPrice, Money discountUnitPrice, int nunmberOfItemsPerPack) =>
            new ItemCode(
                "B", 
                new PackDiscountPricingRule(
                    fullUnitPrice, 
                    new PackDiscountEvaluator(nunmberOfItemsPerPack, discountUnitPrice)));

        public static ItemCode CreateUnknown() => new ItemCode("x", new DefaultPricingRule(new Money(0)));
    }
}
