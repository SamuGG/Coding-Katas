using CheckoutKata;
using System;
using Xunit;

namespace CheckoutKataTests
{
    public class PackDiscountEvaluatorTests
    {
        /// <summary>
        /// Tests that <see cref="PackDiscountEvaluator"/> doesn't allow to specify zero items per pack.
        /// </summary>
        /// <remarks>
        /// Feature: Apply a discount unit price to a pack of items
        /// Scenario: Generating the pricing rule for an item
        /// Given a pricing rule evaluator builder
        /// And zero number of items per pack
        /// And any discount unit price of the item
        /// When building the pricing rule evaluator
        /// Then an error is raised
        /// </remarks>
        [Trait("Pricing Rules", "Pack discount")]
        [Fact]
        public void Zero_Quantity_To_Make_A_Pack_Is_Not_Allowed()
        {
            Assert.Throws<ArgumentException>(() => new PackDiscountEvaluator(0, new Money(0)));
        }

        /// <summary>
        /// Tests that <see cref="PackDiscountEvaluator"/> doesn't allow to specify a negative number of items per pack.
        /// </summary>
        /// <remarks>
        /// Feature: Apply a discount unit price to a pack of items
        /// Scenario: Generating the pricing rule for an item
        /// Given a pricing rule evaluator builder
        /// And negative number of items per pack
        /// And any discount unit price of the item
        /// When building the pricing rule evaluator
        /// Then an error is raised
        /// </remarks>
        [Trait("Pricing Rules", "Pack discount")]
        [Fact]
        public void Negative_Quantity_To_Make_A_Pack_Is_Not_Allowed()
        {
            Assert.Throws<ArgumentException>(() => new PackDiscountEvaluator(-1, new Money(0)));
        }

        /// <summary>
        /// Tests that <see cref="PackDiscountEvaluator"/> evaluates when a discount is not applicable.
        /// </summary>
        /// <remarks>
        /// Feature: Apply a discount unit price to a pack of items
        /// Scenario: Evaluator retunrs full price when discount is not applicable
        /// Given a configured pack discount evaluator
        /// And a number of items insufficient to apply discount price
        /// When price is requested
        /// Then the full price is returned
        /// </remarks>
        [Trait("Pricing Rules", "Pack discount")]
        [Fact]
        public void When_Discount_IsNot_Applicable_Then_Evaluator_Retunrs_Full_Price()
        {
            Money fullPrice = new Money(100);
            Money discountPrice = new Money(50);
            PackDiscountEvaluator discountEvaluator = new PackDiscountEvaluator(2, discountPrice);
            Money actualPrice = discountEvaluator.GetPrice(1, fullPrice);
            Assert.Equal(fullPrice, actualPrice);
        }

        /// <summary>
        /// Tests that <see cref="PackDiscountEvaluator"/> evaluates when a discount is applicable.
        /// </summary>
        /// <remarks>
        /// Feature: Apply a discount unit price to a pack of items
        /// Scenario: Evaluator returns discount price when discount is applicable
        /// Given a configured discount evaluator
        /// And a number of items sufficient to apply discount price
        /// When price is requested
        /// Then the discount price is returned
        /// </remarks>
        [Trait("Pricing Rules", "Pack discount")]
        [Theory]
        [MemberData(nameof(PackDiscountEvaluatorTestsData.GetPackQuantityAndPackMultiples), MemberType = typeof(PackDiscountEvaluatorTestsData))]
        public void When_Discount_Is_Applicable_Then_Evaluator_Returns_Discount_Price(
            int numberOfItemsPerPack,
            int currentItemQuantity)
        {
            Money fullPrice = new Money(100);
            Money discountPrice = new Money(50);
            PackDiscountEvaluator discountEvaluator = new PackDiscountEvaluator(numberOfItemsPerPack, discountPrice);
            Money actualPrice = discountEvaluator.GetPrice(currentItemQuantity, fullPrice);
            Assert.Equal(discountPrice, actualPrice);
        }
    }
}
