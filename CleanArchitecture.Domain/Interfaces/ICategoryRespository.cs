using CleanArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Interfaces
{
    public interface ICategoryRespository
    {

        Task<IEnumerable<Category>> GetCategories();

        Task<Category> GetById(int? id);

        Task<Category> Create(Category cactegory);

        Task<Category> Update(Category cactegory);

        Task<Category> Remove(Category cactegory);
    }
}
