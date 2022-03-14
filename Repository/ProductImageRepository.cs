using System.Collections.Generic;
using System.Linq;
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
        public async Task CreateFile(List<ProductImage> files)
        {
            await Context.AddRangeAsync(files);
            await Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductImage>> GetProdImgByProdId(int productId)
        {
            return await Context.ProductImage.Where(pi => pi.ProductId == productId).ToListAsync();
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }

        public async Task<ProductImage> GetProductImageById(int id)
        {
            return await Context.ProductImage.FirstOrDefaultAsync(pi => pi.Id == id);
        }
    }
}