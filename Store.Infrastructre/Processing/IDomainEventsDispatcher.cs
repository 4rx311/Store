using System.Threading.Tasks;

namespace Store.Infrastructre.Processing
{
    public interface IDomainEventsDispatcher
    {
        Task DispatchEventsAsync();
    }
}
