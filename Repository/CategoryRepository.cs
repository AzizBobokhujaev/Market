using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Repositories;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CategoryRepository:RepositoryBase<Category>,ICategoryRepository
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context) : base(context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoriesById(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task SaveAsync() =>
            await _context.SaveChangesAsync();

    }
}