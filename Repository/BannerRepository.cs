using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Repositories;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class BannerRepository:RepositoryBase<Banner>,IBannerRepository
    {
        public BannerRepository(DataContext context) : base(context)
        {
        }

        public async Task SaveAsync() =>
            await Context.SaveChangesAsync();

        public async Task<List<Banner>> GetBanners()
        {
            return await Context.Banners.ToListAsync();
        }

        public async Task<Banner> GetBannerById(int bannerId)
        {
            return await Context.Banners.FirstOrDefaultAsync(b => b.Id == bannerId);
        }
    }
}