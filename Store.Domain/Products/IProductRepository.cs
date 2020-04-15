using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Domain.Products
{
    public interface IProductRepository
    {
        Product Get(string name);
        Task<Product> GetAsync(string name);
        Task<Product> GetAsync(Guid id);
        Task<ICollection<Product>> GetAllAsync();
        Task AddAsync(Product product);
    }
}
