using CheckoutKata;
using System.Collections.Generic;

namespace CheckoutKataTests
{
    internal class CheckoutTestsData
    {
        public static IEnumerable<object[]> GetKnownItemCodesWithUnitPrice()
        {
            yield return new object[] { ItemCodeFactory.CreateItemA(), new Money(50) };
            yield return new object[] { ItemCodeFactory.CreateItemB(), new Money(30) };
            yield return new object[] { ItemCodeFactory.CreateItemC(), new Money(20) };
            yield return new object[] { ItemCodeFactory.CreateItemD(), new Money(15) };
        }

        public static IEnumerable<object[]> GetKnownItemCodesWithPackTotalPrice()
        {
            yield return new object[] { ItemCodeFactory.CreateItemA(), 2, new Money(130) };
            yield return new object[] { ItemCodeFactory.CreateItemB(), 1, new Money(45) };
        }
    }
}
