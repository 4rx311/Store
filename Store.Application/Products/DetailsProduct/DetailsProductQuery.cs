using System;

namespace Store.Application.Products.DetailsProduct
{
    public sealed class DetailsProductQuery : IQuery<ProductDto>
    {
        public DetailsProductQuery(Guid id)
        {
            ID = id;
        }

        public Guid ID { get; }
    }
}
