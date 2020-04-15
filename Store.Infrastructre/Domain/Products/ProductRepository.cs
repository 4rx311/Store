using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Domain.Products;

namespace Store.Infrastructre.Domain.Products
{
    public class ProductRepository : IProductRepository
    {
        //имитация БД
        private static ConcurrentBag<Product> _database = new ConcurrentBag<Product>()
        {
        };

        public Product Get(string name)
        {
            return _database.FirstOrDefault(p => p.Name == name);
        }

        public async Task<Product> GetAsync(string name)
        {
            return await Task.Run(() => _database.FirstOrDefault(p => p.Name == name));
        }

        public async Task<Product> GetAsync(Guid id)
        {
            return await Task.Run(() => _database.FirstOrDefault(p => p.ID == id));
        }

        public async Task<ICollection<Product>> GetAllAsync()
        {
            //возвращаем якобы из БД
            return await Task.Run<ICollection<Product>>(() => _database.ToArray());
        }

        public async Task AddAsync(Product product)
        {
            //сохраняем якобы в БД
            await Task.Run(() => _database.Add(product));
        }
    }
}
