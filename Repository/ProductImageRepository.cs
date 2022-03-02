using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Repositories;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ProductImageRepository:RepositoryBase<ProductImage>, IProductImageRepository
    {
        public ProductImageRepository(DataContext context) : base(context)
        {
        }

        public async Task<List<ProductImage>> GetAll()
        {
            return await Context.ProductImage.ToListAsync();
        }

        public async Task CreateFile(List<ProductImage> files)
        {
            await Context.AddRangeAsync(files);
            await Context.SaveChangesAsync();
        }
    }
}