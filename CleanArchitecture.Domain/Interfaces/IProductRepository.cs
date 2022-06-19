using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetCategories();

        Task<Category> GetProductCategoryById(int? id);

        Task<Category> Create(Product product);

        Task<Category> Update(Product product);

        Task<Category> Remove(Product product);

    }
}
