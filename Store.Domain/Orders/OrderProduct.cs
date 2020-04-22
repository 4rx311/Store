using Store.Domain.Products;
using Store.Domain.SharedKernel;

namespace Store.Domain.Orders
{
    public sealed class OrderProduct
    {
        private OrderProduct(Product product, int quantity, string currency)
        {
            Quantity = quantity;
            ProductId = product.ProductId;
            Value = Calculate(product, quantity, currency);
        }

        public int Quantity { get; }
        public ProductId ProductId { get; }

        public MoneyValue Value { get; }

        private MoneyValue Calculate(Product product, int quantity, string currency)
        {
            var totalPrice = product.GetPrice(currency).Value * quantity;
            return new MoneyValue(totalPrice, currency);
        }


        public static OrderProduct Create(Product product, int quantity, string currency)
        {
            return new OrderProduct(product, quantity, currency);
        }
    }
}
