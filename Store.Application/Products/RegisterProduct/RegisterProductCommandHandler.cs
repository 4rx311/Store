using System.Threading;
using System.Threading.Tasks;
using Store.Domain.Products;

namespace Store.Application.Products.RegisterProduct
{
    public sealed class RegisterProductCommandHandler : ICommandHandler<RegisterProductCommand, ProductDto>
    {
        public RegisterProductCommandHandler(IProductRepository repository, IProductUniquenessChecker uniquenessChecker)
        {
            _repository = repository;
            _uniquenessChecker = uniquenessChecker;
        }

        private readonly IProductRepository _repository;
        private readonly IProductUniquenessChecker _uniquenessChecker;


        public async Task<ProductDto> Handle(RegisterProductCommand request, CancellationToken cancellationToken)
        {
            var product = Product.Create(request.Name, request.Cost, _uniquenessChecker);
            await _repository.AddAsync(product);

            return new ProductDto() {ID = product.ID, Cost = product.Cost, Name = product.Name};
        }
    }
}
