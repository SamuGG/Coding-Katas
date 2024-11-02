using System;

namespace CheckoutKata
{
    public class PackDiscountEvaluator
    {
        private readonly int m_NumberOfItemsPerPack;
        private readonly Money m_DiscountPrice;

        public PackDiscountEvaluator(int numberOfItemsPerPack, Money discountPrice)
        {
            if (numberOfItemsPerPack <= 0) throw new ArgumentException($"The number of items per pack must be > 0.", nameof(numberOfItemsPerPack));
            m_NumberOfItemsPerPack = numberOfItemsPerPack;
            m_DiscountPrice = discountPrice;
        }

        private bool IsDiscountApplicable(int itemQuantity) => itemQuantity % m_NumberOfItemsPerPack == 0;

        public Money GetPrice(int itemQuantity, Money noDiscountPrice) => 
            IsDiscountApplicable(itemQuantity) ? m_DiscountPrice : noDiscountPrice;
    }
}
