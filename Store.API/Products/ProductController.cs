using System.Threading.Tasks;
using MediatR;
using Store.Application.Products.RegisterProduct;

namespace Store.API.Products
{
    public class ProductController
    {
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private readonly IMediator _mediator;

        public async Task<ProductDto> Register(RegisterProductRequest request)
        {
            var command = new RegisterProductCommand(request.Name, request.Cost, request.Currency);
            var result = await _mediator.Send(command);

            return result;
        }
    }
}
