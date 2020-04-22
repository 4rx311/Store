using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Domain.Orders;
using Store.Domain.Products;
using Store.Domain.SeedWork;

namespace Store.Infrastructre.Database
{
    //симуляция контекста БД EF Core
    public class OrdersContext //:DbContext
    {
        public ConcurrentBag<Product> Products { get; set; } = new ConcurrentBag<Product>();
        public ConcurrentBag<Order> Orders { get; set; } = new ConcurrentBag<Order>();

        //Данный метод в EF Core сохраняет изменения через Tracker.
        public async Task SaveChangesAsync()
        {
            await Task.Run(() => { });
        }

        public IReadOnlyCollection<Entity> ChangeTrackerGetEntities()
        {
            return Products.Select(p => (Entity) p)
                .Union(Orders.Select(p => (Entity) p)).ToArray();
        }
    }
}
