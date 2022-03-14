using Microsoft.AspNetCore.Http;

namespace Entities.DataTransferObjects.Banner
{
    public class BannerDto
    {
        public IFormFile Image { get; set; }
    }
}