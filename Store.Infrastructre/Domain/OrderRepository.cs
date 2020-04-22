using System.Threading.Tasks;
using Store.Domain.Orders;
using Store.Infrastructre.Database;

namespace Store.Infrastructre.Domain
{
    public class OrderRepository : IOrderRepository
    {
        public OrderRepository(OrdersContext ordersContext)
        {
            _ordersContext = ordersContext;
        }

        private readonly OrdersContext _ordersContext;

        public async Task AddAsync(Order order)
        {
            await Task.Run(() => _ordersContext.Orders.Add(order));
        }
    }
}
