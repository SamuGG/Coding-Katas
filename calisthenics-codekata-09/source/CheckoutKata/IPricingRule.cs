namespace CheckoutKata
{
    public interface IPricingRule
    {
        Money GetUnitPrice(int itemQuantity);
    }
}