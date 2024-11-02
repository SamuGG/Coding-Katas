using CheckoutKata;
using Xunit;

namespace CheckoutKataTests
{
    public class CheckoutTests
    {
        /// <summary>
        /// Tests that <see cref="Checkout"/> starts with initial total.
        /// </summary>
        /// <remarks>
        /// Feature: Item scanning
        /// Scenario: Requesting the total money from a new checkout
        /// Given a new scheckout
        /// When requesting the total
        /// Then total is zero
        /// </remarks>
        [Trait("Scanning", "Item code")]
        [Fact]
        public void When_No_Item_Is_Scanned_Total_Is_Zero()
        {
            Money actualTotal = new Checkout().Total();
            Money expectedTotal = new Money(0);
            Assert.Equal(expectedTotal, actualTotal);
        }

        /// <summary>
        /// Tests that <see cref="Checkout"/> can scan unknown item codes.
        /// </summary>
        /// <remarks>
        /// Feature: Item scanning
        /// Scenario: Scanning an unknown item code
        /// Given a checkout
        /// And an unknown item code
        /// When item code is scanned once
        /// Then total is zero
        /// </remarks>
        [Fact]
        public void When_Unknown_ItemCode_Is_Scanned_Then_Total_Is_Not_Updated()
        {
            ItemCode itemCode = ItemCodeTestHelper.CreateUnknown();
            Checkout checkout = new Checkout();
            checkout.Scan(itemCode);
            Money totalMoney = checkout.Total();
            Money expectedTotalMoney = new Money(0);
            Assert.Equal(expectedTotalMoney, totalMoney);
        }

        /// <summary>
        /// Tests that <see cref="Checkout"/> scans known item codes as per the <seealso cref="DefaultPricingRule"/> pricing rule.
        /// </summary>
        /// <remarks>
        /// Feature: Item scanning
        /// Scenario: Scanning a known item code with default pricing rule
        /// Given a checkout
        /// And a known item code configured with a default pricing rule
        /// When item code is scanned once
        /// Then total money is the unit price of the item
        /// </remarks>
        [Trait("Scanning", "Item code")]
        [Trait("Pricing Rules", "Default")]
        [Theory]
        [MemberData(nameof(CheckoutTestsData.GetKnownItemCodesWithUnitPrice), MemberType = typeof(CheckoutTestsData))]
        public void When_A_Known_ItemCode_Is_Scanned_Then_Total_Increments_By_The_Unit_Price(
            ItemCode itemCode, 
            Money expectedTotalMoney)
        {
            Checkout checkout = new Checkout();
            checkout.Scan(itemCode);
            Money totalMoney = checkout.Total();
            Assert.Equal(expectedTotalMoney, totalMoney);
        }

        /// <summary>
        /// Tests that <see cref="Checkout"/> scans known item codes as per the <seealso cref="PackDiscountPricingRule"/> pricing rule.
        /// </summary>
        /// <remarks>
        /// Feature: Item scanning
        /// Scenario: Scanning a known item code with pack discount pricing rule
        /// Given a checkout
        /// And a known item code configured with a pack discount pricing rule
        /// And the item code was previsouly scanned one time less than the number of items required per pack
        /// When item code is scanned once
        /// Then total money is the price of the whole item pack
        /// </remarks>
        [Trait("Scanning", "Item code")]
        [Trait("Pricing Rules", "Pack discount")]
        [Theory]
        [MemberData(nameof(CheckoutTestsData.GetKnownItemCodesWithPackTotalPrice), MemberType = typeof(CheckoutTestsData))]
        public void When_A_Pack_Of_Known_ItemCodes_Is_Scanned_Then_Total_Increments_By_The_Pack_Price(
            ItemCode itemCode, 
            int timesPreviouslyScanned,
            Money expectedTotalMoney)
        {
            Checkout checkout = new Checkout();
            for (int i = 0; i < timesPreviouslyScanned; i++)
            {
                checkout.Scan(itemCode);
            }
            checkout.Scan(itemCode);
            Money totalMoney = checkout.Total();
            Assert.Equal(expectedTotalMoney, totalMoney);
        }
    }
}
