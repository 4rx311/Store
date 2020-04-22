using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Store.Infrastructre.Processing
{
    public sealed class DomainEventsNotificationHandlerDecorator<T> : INotificationHandler<T>
        where T : INotification
    {
        public DomainEventsNotificationHandlerDecorator(INotificationHandler<T> decorated,
            IDomainEventsDispatcher domainEventsDispatcher)
        {
            _decorated = decorated;
            _domainEventsDispatcher = domainEventsDispatcher;
        }

        private readonly INotificationHandler<T> _decorated;
        private readonly IDomainEventsDispatcher _domainEventsDispatcher;

        public async Task Handle(T notification, CancellationToken cancellationToken)
        {
            await _decorated.Handle(notification, cancellationToken);
            await _domainEventsDispatcher.DispatchEventsAsync();
        }
    }
}
