using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Store.Domain.SeedWork
{
    public abstract class Entity
    {
        private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
        public ReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents?.AsReadOnly();

        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}
