using MediatR;

namespace Store.Application
{
    public interface IQuery : IRequest
    {

    }

    public interface IQuery<out TResult> : IRequest<TResult>
    {

    }
}
