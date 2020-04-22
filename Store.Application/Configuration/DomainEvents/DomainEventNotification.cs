using MediatR;

namespace Store.Application.Configuration.DomainEvents
{
    public abstract class DomainEventNotification<T> : IDomainEventNotification<T>, INotification
    {
        protected DomainEventNotification(T domainEvent)
        {
            DomainEvent = domainEvent;
        }

        public T DomainEvent { get; }
    }
}
