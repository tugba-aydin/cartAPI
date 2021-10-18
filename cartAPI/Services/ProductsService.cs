using cartAPI.Data;
using cartAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cartAPI.Services
{
    public class ProductsService : IProductsService
    {
        private readonly MyDBContext myDBContext;

        public ProductsService(MyDBContext _myDBContext)
        {
            myDBContext = _myDBContext;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            myDBContext.Products.Add(product);
            await myDBContext.SaveChangesAsync();
            return product;
        }

        public async Task<int> DeleteProduct(Product product)
        {
            myDBContext.Products.Remove(product);
            return await myDBContext.SaveChangesAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await myDBContext.Products.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<IEnumerable<Product>> GetProductsList()
        {
            return await myDBContext.Products.ToListAsync();
        }

        public async Task<int> UpdateProduct(Product product)
        {
            myDBContext.Products.Update(product);
            return await myDBContext.SaveChangesAsync();
        }
    }
}
