using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using MediatR;
using Store.Application.Configuration.DomainEvents;
using Store.Domain.SeedWork;
using Store.Infrastructre.Database;

namespace Store.Infrastructre.Processing
{
    public sealed class DomainEventsDispatcher : IDomainEventsDispatcher
    {
        public DomainEventsDispatcher(IMediator mediator, ILifetimeScope scope, OrdersContext ordersContext)
        {
            _mediator = mediator;
            _scope = scope;
            _ordersContext = ordersContext;
        }

        private readonly IMediator _mediator;
        private readonly ILifetimeScope _scope;
        private readonly OrdersContext _ordersContext;

        public async Task DispatchEventsAsync()
        {
            var domainEntities = _ordersContext.ChangeTrackerGetEntities().ToList();
            var domainEvents = domainEntities.SelectMany(de => de.DomainEvents).ToList();

            var domainEventNotifications = new List<IDomainEventNotification<IDomainEvent>>();
            foreach (var domainEvent in domainEvents)
            {
                Type domainEvenNotificationType = typeof(IDomainEventNotification<>);
                var domainNotificationWithGenericType =
                    domainEvenNotificationType.MakeGenericType(domainEvent.GetType());
                var domainNotification = _scope.ResolveOptional(domainNotificationWithGenericType, new List<Parameter>
                {
                    new NamedParameter("domainEvent", domainEvent)
                });

                if (domainNotification != null)
                {
                    domainEventNotifications.Add(domainNotification as IDomainEventNotification<IDomainEvent>);
                }
            }

            domainEntities.ForEach(domainEvent => domainEvent.ClearDomainEvents());

            var tasks = domainEvents.Select(async (domainEvent) => { await _mediator.Publish(domainEvent); });
            await Task.WhenAll(tasks);

            // не входит в обзор: тут мы кладём в таблицу для outbox сериализованные объекты domainEventNotifications
            // которые публикуются при обработке outbox таблицы.
        }
    }
}
