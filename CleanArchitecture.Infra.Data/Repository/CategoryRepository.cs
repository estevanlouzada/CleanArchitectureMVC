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
    public class CategoryRepository : ICategoryRespository
    {
        private readonly ApplicationDbContext _categoryContext;
        public CategoryRepository(ApplicationDbContext categoryContext)
        {
            _categoryContext = categoryContext;
        }

        public async Task<Category> Create(Category cactegory)
        {
            _categoryContext.Add(cactegory);
            await _categoryContext.SaveChangesAsync();
            return cactegory;
        }

        public async Task<Category> GetById(int? id)
        {
            return await _categoryContext.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoryContext.Categories.ToListAsync();
        }

        public async Task<Category> Remove(Category cactegory)
        {
            _categoryContext.Categories.Remove(cactegory);
            await _categoryContext.SaveChangesAsync();
            return cactegory;
        }

        public async Task<Category> Update(Category cactegory)
        {
            _categoryContext.Update(cactegory);
            await _categoryContext.SaveChangesAsync();
            return cactegory;
        }
    }
}
