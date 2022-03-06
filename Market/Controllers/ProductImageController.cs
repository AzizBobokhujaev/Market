using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Services;
using Entities.DataTransferObjects.ProductImage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageService _service;

        public ProductImageController(IProductImageService service)
        {
            _service = service;
        }

        [HttpPost("AddImageForProduct")]
        public async Task<IActionResult> AddProductImage([FromForm] ProductImageDto model)
        {
            return Ok(await _service.AddImageForProduct(model));
        }

        [HttpGet("GetProductImagesByProductId")]
        public async Task<IActionResult> GetProductImagesByProductId(int productId)
        {
            return Ok(await _service.GetProductImageByProductId(productId));
        }
    }
}