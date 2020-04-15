using Store.Domain.Products;

namespace Store.Application.Products.DomainServices
{
    public sealed class ProductUniquenessChecker : IProductUniquenessChecker
    {
        public ProductUniquenessChecker(IProductRepository repository)
        {
            _repository = repository;
        }

        private readonly IProductRepository _repository;

        public bool IsUniqueName(string name)
        {
            var product = _repository.Get(name);
            return product is null;
        }
    }
}
