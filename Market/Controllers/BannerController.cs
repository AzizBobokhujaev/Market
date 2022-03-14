using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Services;
using Entities.DataTransferObjects.Banner;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly IBannerService _bannerService;

        public BannerController(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        [HttpGet("GetAllBanners")]
        public async Task<IActionResult> GetAllBanners()
        {
            return Ok(await _bannerService.GetBanners());
        }

        [HttpPost("AddBanner")]
        public async Task<IActionResult> AddBanner([FromForm] BannerDto model)
        {
            return Ok(await _bannerService.CreateBanner(model));
        }

        [HttpPut("UpdateBanner")]
        public async Task<IActionResult> UpdateBanner(int bannerId, BannerDto model)
        {
            var banner = await _bannerService.UpdateBanner(bannerId, model);
            return banner.Status == 404 ? NotFound(banner) : Ok(banner);
        }

        [HttpDelete("DeleteBanner")]
        public async Task<IActionResult> DeleteBanner(int bannerId)
        {
            var banner = await _bannerService.DeleteBanner(bannerId);
            return banner.Status == 404 ? NotFound(banner) : Ok(banner);
        }

    }
}