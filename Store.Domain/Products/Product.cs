using System;
using System.Collections.Generic;
using System.Linq;
using Store.Domain.SeedWork;
using Store.Domain.SharedKernel;

namespace Store.Domain.Products
{
    public class Product : Entity
    {
        private Product(string name, List<ProductPrice> prices)
        {
            ProductId = new ProductId(Guid.NewGuid());
            Name = name;
            _prices = prices;
        }

        public ProductId ProductId { get; }
        public string Name { get; }

        public readonly List<ProductPrice> _prices;

        public MoneyValue GetPrice(string currency)
        {
            return _prices.Single(p => p.Value.Currency == currency).Value;
        }

        public static Product Create(string name, List<ProductPrice> prices)
        {
            var result = new Product(name, prices);
            return result;
        }
    }
}
