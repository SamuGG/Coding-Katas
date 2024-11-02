namespace CheckoutKata
{
    public static class ItemCodeFactory
    {
        public static ItemCode CreateItemA() => new ItemCode(
            "A",
            new PackDiscountPricingRule(
                new Money(50),
                new PackDiscountEvaluator(3, new Money(30))));

        public static ItemCode CreateItemB() => new ItemCode(
            "B",
            new PackDiscountPricingRule(
                new Money(30), 
                new PackDiscountEvaluator(2, new Money(15))));

        public static ItemCode CreateItemC() => new ItemCode("C", new DefaultPricingRule(new Money(20)));
        public static ItemCode CreateItemD() => new ItemCode("D", new DefaultPricingRule(new Money(15)));
    }
}
