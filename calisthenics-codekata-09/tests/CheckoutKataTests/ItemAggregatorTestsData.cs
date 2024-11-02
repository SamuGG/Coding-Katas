using CheckoutKata;
using System.Collections.Generic;

namespace CheckoutKataTests
{
    internal class ItemAggregatorTestsData
    {
        public static IEnumerable<object[]> GetMoneysForOneAggregation()
        {
            yield return new object[] { new Money(0), new Money(0), new Money(0) };
            yield return new object[] { new Money(0), new Money(1), new Money(1) };
            yield return new object[] { new Money(75), new Money(81), new Money(156) };
        }
    }
}
