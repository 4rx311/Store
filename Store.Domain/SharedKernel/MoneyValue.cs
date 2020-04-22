namespace Store.Domain.SharedKernel
{
    public sealed class MoneyValue
    {
        public MoneyValue(decimal value, string currency)
        {
            Value = value;
            Currency = currency;
        }

        public decimal Value { get; }
        public string Currency { get; }
    }
}
