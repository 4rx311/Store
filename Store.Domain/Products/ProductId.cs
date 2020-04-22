using System;
using Store.Domain.SeedWork;

namespace Store.Domain.Products
{
    public sealed class ProductId : TypedIdValue
    {
        public ProductId(Guid value) : base(value)
        {
        }
    }
}
