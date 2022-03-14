using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.DataTransferObjects.Banner;
using Entities.Models;

namespace Contracts.Repositories
{
    public interface IBannerRepository:IRepositoryBase<Banner>
    {
        Task SaveAsync();
        Task<List<Banner>> GetBanners();

        Task<Banner> GetBannerById(int bannerId);
        
    }
}