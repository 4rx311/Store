using System.Threading;
using System.Threading.Tasks;

namespace Store.Domain.SeedWork
{
    public interface IUnitOfWork
    {
        Task CommitAsync(CancellationToken cancellationToken = default);
    }
}
