using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Store.Application.Orders.CreateOrder
{
    public sealed class CreateOrderNotificationHandler : INotificationHandler<CreateOrderNotification>
    {
        public async Task Handle(CreateOrderNotification notification, CancellationToken cancellationToken)
        {
            await Task.Run(() => Console.WriteLine(notification.DomainEvent));
        }
    }
}
