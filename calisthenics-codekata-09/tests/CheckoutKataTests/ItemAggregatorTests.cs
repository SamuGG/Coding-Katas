using CheckoutKata;
using Xunit;

namespace CheckoutKataTests
{
    public class ItemAggregatorTests
    {
        /// <summary>
        /// Tests that <see cref="ItemAggregator"/> increments total money as per the <see cref="DefaultPricingRule"/> pricing rule.
        /// </summary>
        /// <param name="totalMoney">A <seealso cref="Money"/> value to use as initial total money.</param>
        /// <param name="unitPrice">A <seealso cref="Money"/> value to use as predefined unit price.</param>
        /// <param name="expectedTotalMoney">A <seealso cref="Money"/> value to expect from the test result.</param>
        /// <remarks>
        /// Feature: Item aggregation
        /// Scenario: Aggregating an item when discount is not applicable
        /// Given an item aggregator configured with default pricing rule
        /// And no items aggregated
        /// And an initial total money
        /// When aggregation is requested once
        /// Then total money is the unit price of the item
        /// </remarks>
        [Trait("Pricing Rules", "Default")]
        [Theory]
        [MemberData(nameof(ItemAggregatorTestsData.GetMoneysForOneAggregation), MemberType = typeof(ItemAggregatorTestsData))]
        public void When_Aggregating_An_Item_With_Default_Pricing_Rule_Then_Total_Increments_By_The_Unit_Price(
            Money totalMoney, 
            Money unitPrice,
            Money expectedTotalMoney)
        {
            IPricingRule pricingRule = new DefaultPricingRule(unitPrice);
            ItemAggregator aggregator = new ItemAggregator(pricingRule);
            aggregator.Aggregate(totalMoney);
            Assert.Equal(expectedTotalMoney, totalMoney);
        }

        /// <summary>
        /// Tests that <see cref="ItemAggregator"/> increments total money as per the <see cref="PackDiscountPricingRule"/> pricing rule.
        /// </summary>
        /// <remarks>
        /// Feature: Item aggregation
        /// Scenario: Aggregating an item when pack discount is applicable
        /// Given an item aggegator configured with a pack discount pricing rule
        /// And the number of items aggregated is one less than the number of items required per pack
        /// And an initial total money
        /// When aggreagtion is requested once
        /// Then total money is the price of the whole item pack
        /// </remarks>
        [Trait("Pricing Rules", "Pack discount")]
        [Fact]
        public void When_Discount_Is_Applicable_Then_Total_Increments_By_Discount_Unit_Price()
        {
            Money fullPrice = new Money(100);
            Money discountPrice = new Money(50);
            IPricingRule pricingRule = new PackDiscountPricingRule(fullPrice, new PackDiscountEvaluator(2, discountPrice));
            ItemAggregator aggregator = new ItemAggregator(pricingRule);
            Money totalMoney = new Money(0);
            aggregator.Aggregate(totalMoney);
            aggregator.Aggregate(totalMoney);
            Money expectedTotalMoney = new Money(150);
            Assert.Equal(expectedTotalMoney, totalMoney);
        }
    }
}
