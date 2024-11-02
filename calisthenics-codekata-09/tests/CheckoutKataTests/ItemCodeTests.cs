using CheckoutKata;
using Xunit;

namespace CheckoutKataTests
{
    public class ItemCodeTests
    {
        /// <summary>
        /// Tests <see cref="ItemCode"/> inequality.
        /// </summary>
        /// <remarks>
        /// Feature: Item code identification
        /// Scenario: Items with different codes should be different
        /// Given ItemCode1 with code A
        /// And ItemCode2 with code B
        /// When comparing them
        /// Then they aren't equal
        /// </remarks>
        [Fact]
        public void ItemCode1_IsNot_Equal_To_ItemCode2()
        {
            ItemCode itemCode1 = ItemCodeFactory.CreateItemA();
            ItemCode itemCode2 = ItemCodeFactory.CreateItemB();
            Assert.NotEqual(itemCode1, itemCode2);
        }

        /// <summary>
        /// Tests <see cref="ItemCode"/> equality.
        /// </summary>
        /// <remarks>
        /// Feature: Item code identification
        /// Scenario: Items with same codes should be equal
        /// Given ItemCode1 with code A
        /// And ItemCode2 with code A
        /// When comparing them
        /// Then they are equal
        /// </remarks>
        [Fact]
        public void ItemCode1_Is_Equal_To_ItemCode1()
        {
            ItemCode itemCode1 = ItemCodeFactory.CreateItemA();
            ItemCode itemCode2 = ItemCodeFactory.CreateItemA();
            Assert.Equal(itemCode1, itemCode2);
        }

        /// <summary>
        /// Tests scanning a <see cref="ItemCode"/> as per the <seealso cref="DefaultPricingRule"/> pricing rule.
        /// </summary>
        /// <remarks>
        /// Feature: Item scanning
        /// Scenario: Scanning an item with default pricing rule
        /// Given an item code configured with a default pricing rule
        /// And an initial total money
        /// When item is scanned once
        /// Then total money is the unit price of the item
        /// </remarks>
        [Trait("Scanning", "Item code")]
        [Trait("Pricing Rules", "Default")]
        [Fact]
        public void When_Scanning_An_Item_With_Default_Pricing_Rule_Then_Total_Increments_By_The_Unit_Price()
        {
            Money unitPrice = new Money(100);
            ItemCode itemCode = ItemCodeTestHelper.CreateWithDefaultPricingRule(unitPrice);
            Money totalMoney = new Money(0);
            itemCode.Scan(totalMoney);
            Assert.Equal(unitPrice, totalMoney);
        }

        /// <summary>
        /// Tests scanning a <see cref="ItemCode"/> as per the <see cref="PackDiscountPricingRule"/> pricing rule.
        /// </summary>
        /// <remarks>
        /// Feature: Item scanning
        /// Scenario: Scanning an item with pack discount pricing rule
        /// Given an item code configured with a pack discount pricing rule
        /// And the item code has been aggregated a number of times less than the required number of items per pack
        /// And an initial total money
        /// When item is scanned once
        /// Then total money is the price of the whole item pack
        /// </remarks>
        [Trait("Scanning", "Item code")]
        [Trait("Pricing Rules", "Pack discount")]
        [Fact]
        public void When_Discount_Is_Applicable_Then_Total_Increments_By_Discount_Unit_Price()
        {
            Money fullUnitPrice = new Money(100);
            Money discountUnitPrice = new Money(50);
            ItemCode itemCode = ItemCodeTestHelper.CreateWithPackDiscountPricingRule(fullUnitPrice, discountUnitPrice, 2);
            Money totalMoney = new Money(0);
            
            itemCode.Scan(totalMoney);
            itemCode.Scan(totalMoney);

            Money expectedTotalMoney = new Money(150);
            Assert.Equal(expectedTotalMoney, totalMoney);
        }
    }
}
