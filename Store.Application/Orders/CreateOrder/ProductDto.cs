using System;

namespace Store.Application.Orders.CreateOrder
{
    public class ProductDto
    {
        public ProductDto(Guid id, int quantity)
        {
            Id = id;
            Quantity = quantity;
        }

        public Guid Id { get; }
        public int Quantity { get; }
    }
}
