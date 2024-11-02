using System.Diagnostics;

namespace CheckoutKata
{
    [DebuggerDisplay("Code = {m_ItemCode}")]
    public class ItemCode
    {
        private readonly string m_ItemCode;
        private readonly ItemAggregator m_Aggregator;

        public ItemCode(string itemCode, IPricingRule pricingRules)
        {
            m_ItemCode = itemCode;
            m_Aggregator = new ItemAggregator(pricingRules);
        }

        public override bool Equals(object itemCodeObject) => itemCodeObject is ItemCode itemCode && itemCode.m_ItemCode == m_ItemCode;

        public void Scan(Money totalMoney) => m_Aggregator.Aggregate(totalMoney);
    }
}
