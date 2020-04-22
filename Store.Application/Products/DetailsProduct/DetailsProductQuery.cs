namespace Store.Application.Products.DetailsProduct
{
    public sealed class DetailsProductQuery : IQuery<ProductDto>
    {
        public DetailsProductQuery(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
