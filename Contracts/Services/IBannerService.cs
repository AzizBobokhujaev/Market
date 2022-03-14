using System.Collections.Generic;
using System.Runtime;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Banner;
using Entities.Models;
using Microsoft.AspNetCore.Http;

namespace Contracts.Services
{
    public interface IBannerService
    {
        Task<string> AddImage(IFormFile image);

        Task<Response> CreateBanner(BannerDto model);

        Task<List<Banner>> GetBanners();

        Task<Response> UpdateBanner(int bannerId,BannerDto model);
        Task<Response> DeleteBanner(int bannerId);
        
    }
}