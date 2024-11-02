using System.Collections.Generic;

namespace CheckoutKataTests
{
    internal class PackDiscountEvaluatorTestsData
    {
        public static IEnumerable<object[]> GetPackQuantityAndPackMultiples()
        {
            yield return new object[] { 1, 1 };
            yield return new object[] { 1, 2 };
            yield return new object[] { 1, 3 };
            yield return new object[] { 2, 2 };
            yield return new object[] { 2, 4 };
            yield return new object[] { 2, 6 };
            yield return new object[] { 3, 3 };
            yield return new object[] { 3, 6 };
            yield return new object[] { 3, 9 };
        }
    }
}
