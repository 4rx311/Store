using System;

namespace Store.Domain.SeedWork
{
    public abstract class DomainEvent : IDomainEvent
    {
        public DomainEvent()
        {
            OccuredOn = DateTime.Now;
        }

        public DateTime OccuredOn { get; }
    }
}
