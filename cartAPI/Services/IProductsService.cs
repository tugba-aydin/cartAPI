using cartAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cartAPI.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<Product>> GetProductsList();
        Task<Product> GetProductById(int id);
        Task<Product> CreateProduct(Product product);
        Task<int> UpdateProduct(Product product);
        Task<int> DeleteProduct(Product product);
    }
}
