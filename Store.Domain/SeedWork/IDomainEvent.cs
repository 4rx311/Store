using System;
using MediatR;

namespace Store.Domain.SeedWork
{
    public interface IDomainEvent : INotification
    {
        DateTime OccuredOn { get; }
    }
}
