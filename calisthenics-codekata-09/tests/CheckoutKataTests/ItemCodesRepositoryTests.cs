using CheckoutKata;
using Xunit;

namespace CheckoutKataTests
{
    public class ItemCodesRepositoryTests
    {
        /// <summary>
        /// Tests that <see cref="ItemCodesRepository"/> can't find missing items.
        /// </summary>
        /// <remarks>
        /// Feature: Item codes repository
        /// Scenario: Unknown items can't be found in the repository
        /// Given A repository with known items
        /// And an item missing in the repository
        /// When searching for the item
        /// Then null is returned
        /// </remarks>
        [Fact]
        public void Searching_For_An_Unknown_ItemCode_Returns_Null()
        {
            ItemCodesRepository itemCodes = new ItemCodesRepository();
            ItemCode unknownItemCode = ItemCodeTestHelper.CreateUnknown();
            ItemCode foundItemCode = itemCodes.Find(unknownItemCode);
            Assert.Null(foundItemCode);
        }

        /// <summary>
        /// Tests that <see cref="ItemCodesRepository"/> can find present items.
        /// </summary>
        /// <remarks>
        /// Feature: Item codes repository
        /// Scenario: Known items can be found in the repository
        /// Given A repository with known items
        /// And an item present in the repository
        /// When searching for the item
        /// Then item is returned
        /// </remarks>
        [Fact]
        public void Searching_For_A_Known_ItemCode_Returns_The_First_Found()
        {
            ItemCodesRepository itemCodes = new ItemCodesRepository();
            ItemCode knownItemCode = ItemCodeFactory.CreateItemA();
            ItemCode foundItemCode = itemCodes.Find(knownItemCode);
            Assert.NotNull(foundItemCode);
            Assert.Equal(knownItemCode, foundItemCode);
        }
    }
}
