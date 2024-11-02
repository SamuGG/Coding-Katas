using System.Diagnostics;

namespace CheckoutKata
{
    [DebuggerDisplay("Amount = {m_Amount}")]
    public class Money
    {
        private int m_Amount;

        public Money(int amount) => m_Amount = amount;

        public void Add(Money itemPrice) => m_Amount += itemPrice.m_Amount;

        public override bool Equals(object moneyObject) =>  moneyObject is Money money && money.m_Amount == m_Amount;
    }
}
