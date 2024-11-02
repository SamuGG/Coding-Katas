using CheckoutKata;
using System.Collections.Generic;

namespace CheckoutKataTests
{
    internal class DefaultPricingRuleTestsData
    {
        public static IEnumerable<object[]> GetPredefinedUnitPricesAndItemQuantities()
        {
            yield return new object[] { new Money(0), 1 };
            yield return new object[] { new Money(100), 2 };
            yield return new object[] { new Money(100), 3 };
            yield return new object[] { new Money(100), 100 };
        }
    }
}
