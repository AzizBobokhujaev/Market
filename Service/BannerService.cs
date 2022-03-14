using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Contracts.Repositories;
using Contracts.Services;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Banner;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class BannerService:IBannerService
    {
        private readonly IBannerRepository _bannerRepository;

        public BannerService(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        public async Task<string> AddImage(IFormFile image)
        {
            var path = $"wwwroot/Banners/";
            var fullPath = Path.GetFullPath(path);
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }

            var fileExtension = Path.GetExtension(image.FileName);
            var fileName = $"{DateTime.Now.Ticks.ToString()}{fileExtension}";
            var finalFileName = Path.Combine(fullPath, fileName);
            var imagePath = Path.Combine(path, fileName);
            await using (var fs = System.IO.File.Create(finalFileName))
            {
                await image.CopyToAsync(fs);
            }

            return imagePath;
        }

        public async Task<Response> CreateBanner(BannerDto model)
        {
            var banners = await _bannerRepository.GetBanners();
            var banner = new Banner
            {
                ImagePath = await AddImage(model.Image),
                Queue = banners.Count + 1
            };
            await _bannerRepository.CreateAsync(banner);
            await _bannerRepository.SaveAsync();
            return new Response
            {
                Status = (int) HttpStatusCode.OK,
                Message = "Created"
            };
        }

        public async Task<List<Banner>> GetBanners()
        {
            return await _bannerRepository.GetBanners();
        }

        public async Task<Response> UpdateBanner(int bannerId,BannerDto model)
        {
            var banner = await _bannerRepository.GetBannerById(bannerId);
            if (banner == null)
                return new Response {Status = (int) HttpStatusCode.NotFound, Message = "Banner not found"};

            await DeleteBanner(banner.Id);
            var addImg = await AddImage(model.Image);
            
            banner.ImagePath = addImg;
            _bannerRepository.Update(banner);
            await _bannerRepository.SaveAsync();
            return new Response {Status = (int) HttpStatusCode.OK, Message = "Updated"};

        }

        public async Task<Response> DeleteBanner(int bannerId)
        {
            var banner = await _bannerRepository.GetBannerById(bannerId);
            if (banner == null)
                return new Response {Status = (int) HttpStatusCode.NotFound, Message = "Banner not found"};
            if (System.IO.File.Exists(banner.ImagePath))
                System.IO.File.Delete(banner.ImagePath);
            _bannerRepository.Delete(banner);
            await _bannerRepository.SaveAsync();
            return new Response {Status = (int) HttpStatusCode.OK, Message = "Deleted"};
        }
    }
}