using Store.Application.Configuration.DomainEvents;
using Store.Domain.Orders;

namespace Store.Application.Orders.CreateOrder
{
    public class CreateOrderNotification : DomainEventNotification<CreateOrderEvent>
    {
        public CreateOrderNotification(CreateOrderEvent domainEvent) : base(domainEvent)
        {
        }
    }
}
