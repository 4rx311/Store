using Store.Domain.Products;

namespace Store.Domain.Orders
{
    public sealed class OrderProductData
    {
        public OrderProductData(ProductId productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public ProductId ProductId { get; }
        public int Quantity { get; }
    }
}
