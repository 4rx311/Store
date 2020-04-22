using System.Threading.Tasks;

namespace Store.Domain.Orders
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order);
    }
}
