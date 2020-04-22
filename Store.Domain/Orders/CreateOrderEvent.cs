using Store.Domain.SeedWork;

namespace Store.Domain.Orders
{
    public class CreateOrderEvent : DomainEvent
    {
        public CreateOrderEvent(OrderId orderId) : base()
        {
            OrderId = orderId;
        }

        public OrderId OrderId { get; }
    }
}
