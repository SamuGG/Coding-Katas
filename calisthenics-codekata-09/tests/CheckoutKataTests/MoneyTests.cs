using CheckoutKata;
using Xunit;

namespace CheckoutKataTests
{
    public class MoneyTests
    {
        /// <summary>
        /// Tests <see cref="Money"/> inequality.
        /// </summary>
        /// <remarks>
        /// Feature: Money identification
        /// Scenario: Moneys with different amounts should be different
        /// Given Money1 with amount x
        /// And Money2 with amount y
        /// When comparing them
        /// Then they aren't equal
        /// </remarks>
        [Fact]
        public void Money1_IsNot_Equal_To_Money2()
        {
            Assert.NotEqual(new Money(1), new Money(2));
        }

        /// <summary>
        /// Tests <see cref="Money"/> equality.
        /// </summary>
        /// <remarks>
        /// Feature: Money identification
        /// Scenario: Moneys with same amounts should be equal
        /// Given Money1 with amount x
        /// And Money2 with amount x
        /// When comparing them
        /// Then they are equal
        /// </remarks>
        [Fact]
        public void Money1_Is_Equal_To_Money1()
        {
            Assert.Equal(new Money(1), new Money(1));
        }

        /// <summary>
        /// Tests that <see cref="Money"/> can add another instance to its amount.
        /// </summary>
        /// <remarks>
        /// Feature: Operating with money
        /// Scenario: Adding money to money
        /// Given Money1 with amount x
        /// And Money2 with amount y
        /// When adding Money2 to Money1
        /// Then the amount of Money1 is x+y
        /// </remarks>
        [Fact]
        public void When_Adding_Money2_To_Money1_Then_Money1_Increments_By_The_Amount_Of_Money2()
        {
            Money money1 = new Money(1);
            Money money2 = new Money(2);
            Money expectedMoney = new Money(3);
            money1.Add(money2);
            Assert.Equal(expectedMoney, money1);
            Assert.NotEqual(expectedMoney, money2);
        }
    }
}
