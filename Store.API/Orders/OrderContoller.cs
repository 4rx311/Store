using System.Threading.Tasks;
using MediatR;
using Store.Application.Orders.CreateOrder;

namespace Store.API.Orders
{
    public class OrderContoller
    {
        public OrderContoller(IMediator mediator)
        {
            _mediator = mediator;
        }

        private readonly IMediator _mediator;

        public async Task<OrderDto> Create(CreateOrderRequest request)
        {
            var command = new CreateOrderCommand(request.Currency, request.ProductsDto,
                request.CustomerName, request.CustomerEmail);
            var result = await _mediator.Send(command);

            return result;
        }
    }
}
