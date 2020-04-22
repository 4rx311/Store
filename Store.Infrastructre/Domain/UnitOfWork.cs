using System.Threading;
using System.Threading.Tasks;
using Store.Domain.SeedWork;
using Store.Infrastructre.Database;
using Store.Infrastructre.Processing;

namespace Store.Infrastructre.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(OrdersContext ordersContext, IDomainEventsDispatcher domainEventsDispatcher)
        {
            _ordersContext = ordersContext;
            _domainEventsDispatcher = domainEventsDispatcher;
        }

        private readonly OrdersContext _ordersContext;
        private readonly IDomainEventsDispatcher _domainEventsDispatcher;

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await _domainEventsDispatcher.DispatchEventsAsync();
            await _ordersContext.SaveChangesAsync();
        }
    }
}
