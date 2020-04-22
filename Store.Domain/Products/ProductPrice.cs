using Store.Domain.SharedKernel;

namespace Store.Domain.Products
{
    public class ProductPrice
    {
        public ProductPrice(MoneyValue value)
        {
            Value = value;
        }

        public MoneyValue Value { get; }
    }
}
