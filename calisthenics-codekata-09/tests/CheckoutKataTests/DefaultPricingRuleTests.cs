using CheckoutKata;
using Xunit;

namespace CheckoutKataTests
{
    public class DefaultPricingRuleTests
    {
        /// <summary>
        /// Tests that <see cref="DefaultPricingRule"/> always returns the predefined unit price.
        /// </summary>
        /// <param name="predefinedUnitPrice">A <seealso cref="Money"/> value to use as predefined unit price.</param>
        /// <param name="itemQuantity">The number of items to check against the pricing rule.</param>
        /// <remarks>
        /// Feature: Apply a predefined unit price for an item
        /// Scenario: Applying an invariable unit price to an item
        /// Given a pricing rule with a predefined unit price
        /// When unit price is requested for any positive number of items
        /// Then predefined unit price is returned
        /// </remarks>
        [Trait("Pricing Rules", "Default")]
        [Theory]
        [MemberData(nameof(DefaultPricingRuleTestsData.GetPredefinedUnitPricesAndItemQuantities), MemberType = typeof(DefaultPricingRuleTestsData))]
        public void UnitPrice_Is_The_Predefined_Price_Provided(Money predefinedUnitPrice, int itemQuantity)
        {
            IPricingRule pricingRule = new DefaultPricingRule(predefinedUnitPrice);
            Money actualUnitPrice = pricingRule.GetUnitPrice(itemQuantity);
            Assert.Equal(predefinedUnitPrice, actualUnitPrice);
        }
    }
}
