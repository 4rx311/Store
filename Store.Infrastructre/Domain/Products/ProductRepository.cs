using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Domain.Products;
using Store.Infrastructre.Database;

namespace Store.Infrastructre.Domain.Products
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository(OrdersContext ordersContext)
        {
            _ordersContext = ordersContext;
        }

        private readonly OrdersContext _ordersContext;

        public Product Get(string name)
        {
            return _ordersContext.Products.FirstOrDefault(p => p.Name == name);
        }

        public async Task<Product> GetAsync(string name)
        {
            return await Task.Run(() => _ordersContext.Products.FirstOrDefault(p => p.Name == name));
        }

        public async Task<ICollection<Product>> GetByIdsAsync(List<ProductId> productIds)
        {
            return await Task.Run(() =>
                _ordersContext.Products.Where(p =>
                    productIds.Contains(p.ProductId)).ToArray());
        }

        public async Task<ICollection<Product>> GetAllAsync()
        {
            //возвращаем якобы из БД
            return await Task.Run<ICollection<Product>>(() => _ordersContext.Products.ToArray());
        }

        public async Task AddAsync(Product product)
        {
            //сохраняем якобы в БД
            await Task.Run(() => _ordersContext.Products.Add(product));
        }
    }
}
