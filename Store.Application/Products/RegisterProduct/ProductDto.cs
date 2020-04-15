using System;

namespace Store.Application.Products.RegisterProduct
{
    public sealed class ProductDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
    }
}
