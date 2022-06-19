using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infra.Data.Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly ApplicationDbContext _productContext;

        public ProductRepository(ApplicationDbContext productContext)
        {
            _productContext = productContext;
        }

        public async Task<Product> Create(Product product)
        {
            _productContext.Products.Add(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetCategories()
        {
           return await _productContext.Products.ToListAsync();
            
        }

        public async Task<Product> GetProductCategoryById(int? id)
        {
            return await _productContext.Products.Include(x => x.Category).SingleOrDefaultAsync(p => p.Id == id);

        }

        public async Task<Product> Remove(Product product)
        {
            _productContext.Products.Remove(product);
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> Update(Product product)
        {
            _productContext.Products.Update(product);
            await _productContext.SaveChangesAsync();
            return product;
        }
    }
}
