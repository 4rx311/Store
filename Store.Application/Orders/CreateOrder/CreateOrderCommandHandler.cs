using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Store.Domain.Orders;
using Store.Domain.Products;
using Store.Domain.SeedWork;

namespace Store.Application.Orders.CreateOrder
{
    public sealed class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, OrderDto>
    {
        public CreateOrderCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork,
            IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _orderRepository = orderRepository;
        }

        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public async Task<OrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var productIds = request.ProductsDto.Select(p => new ProductId(p.Id)).ToList();
            var products = await _productRepository.GetByIdsAsync(productIds);
            var productDatas = request.ProductsDto.Select(p =>
                new OrderProductData(new ProductId(p.Id), p.Quantity)).ToList();

            var order = Order.Create(request.CustomerName, request.CustomerEmail, products.ToList(),
                productDatas, request.Currency);

            await _orderRepository.AddAsync(order);
            await _unitOfWork.CommitAsync();

            return new OrderDto(order.OrderId.Value);
        }
    }
}
