namespace Store.Application.Configuration.DomainEvents
{
    public interface IDomainEventNotification<out TDomainEvent>
    {
        TDomainEvent DomainEvent { get; }
    }
}
