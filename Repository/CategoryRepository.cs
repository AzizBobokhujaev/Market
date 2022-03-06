using System.Collections.Generic;
using System.Linq;
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

        public async Task<Category> GetCategoryById(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task SaveAsync() =>
            await _context.SaveChangesAsync();

        public async Task<IEnumerable<Category>> GetAllWithSubs()
        {
            var  topCategory =await _context.Categories.Select(c => new Category
            {
                Id = c.Id,
                Name = c.Name,
                ParentId = c.ParentId,
                SubCategory =  _context.Categories.Select(category => new Category
                {
                    Id = category.Id,
                    Name = category.Name,
                    ParentId = category.ParentId,
                    SubCategory = _context.Categories.Select(subcategory=>new Category
                    {
                        Id = subcategory.Id,
                        Name = subcategory.Name,
                        ParentId = subcategory.ParentId,
                        SubCategory = _context.Categories.Select(subcateg=>new Category
                        {
                            Id = subcateg.Id,
                            Name = subcateg.Name,
                            ParentId = subcateg.ParentId,
                        }).Where(cat=>cat.ParentId==subcategory.Id).ToList()
                    }).Where(cat=>cat.ParentId==category.Id).ToList()
                }).Where(cat=>cat.ParentId == c.Id).ToList()
            }).Where(cat => cat.ParentId == 0).ToListAsync();
            return topCategory;
        }
    }
}