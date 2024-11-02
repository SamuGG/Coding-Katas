using CheckoutKata;
using Xunit;

namespace CheckoutKataTests
{
    public class PackDiscountPricingRuleTests
    {
        /// <summary>
        /// Tests that <see cref="PackDiscountPricingRule"/> with a <seealso cref="PackDiscountEvaluator"/> configured to apply full unit price.
        /// </summary>
        /// <remarks>
        /// Feature: Apply a discount unit price to a pack of items
        /// Scenario: Pricing rule determines full unit price of an item when discount is not applicable
        /// Given a configured pricing rule
        /// And a number of items insufficient to apply discount price
        /// When unit price is requested
        /// Then the full unit price is returned
        /// </remarks>
        [Trait("Pricing Rules", "Pack discount")]
        [Fact]
        public void When_Discount_IsNot_Applicable_Then_UnitPrice_Is_Full_Price()
        {
            Money fullPrice = new Money(100);
            Money discountPrice = new Money(50);
            PackDiscountEvaluator discountEvaluator = new PackDiscountEvaluator(2, discountPrice);
            IPricingRule pricingRule = new PackDiscountPricingRule(fullPrice, discountEvaluator);
            Money actualUnitPrice = pricingRule.GetUnitPrice(1);
            Assert.Equal(fullPrice, actualUnitPrice);
        }

        /// <summary>
        /// Tests that <see cref="PackDiscountPricingRule"/> with a <seealso cref="PackDiscountEvaluator"/> configured to apply discount unit price.
        /// </summary>
        /// <remarks>
        /// Feature: Apply a discount unit price to a pack of items
        /// Scenario: Pricing rule determines discount unit price of an item when discount is applicable
        /// Given a configured pricing rule
        /// And a number of items sufficient to apply discount price
        /// When unit price is requested
        /// Then the discount unit price is returned
        /// </remarks>
        [Trait("Pricing Rules", "Pack discount")]
        [Theory]
        [MemberData(nameof(PackDiscountEvaluatorTestsData.GetPackQuantityAndPackMultiples), MemberType = typeof(PackDiscountEvaluatorTestsData))]
        public void When_Discount_Is_Applicable_Then_UnitPrice_Is_Discount_Price(
            int numberOfItemsPerPack,
            int currentItemQuantity)
        {
            Money fullPrice = new Money(100);
            Money discountPrice = new Money(50);
            PackDiscountEvaluator discountEvaluator = new PackDiscountEvaluator(numberOfItemsPerPack, discountPrice);
            IPricingRule pricingRule = new PackDiscountPricingRule(fullPrice, discountEvaluator);
            Money actualUnitPrice = pricingRule.GetUnitPrice(currentItemQuantity);
            Assert.Equal(discountPrice, actualUnitPrice);
        }
    }
}
