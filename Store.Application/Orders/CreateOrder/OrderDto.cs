using System;

namespace Store.Application.Orders.CreateOrder
{
    public class OrderDto
    {
        public OrderDto(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
