using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Contracts.Services;
using Entities.DataTransferObjects.ProductImage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

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

        [HttpGet("GetProductImagesByProductId")]
        public async Task<IActionResult> GetProductImagesByProductId(int productId)
        {
            return Ok(await _service.GetProductImageByProductId(productId));
        }
        
        [HttpPost("AddImageForProduct")]
        public async Task<IActionResult> AddProductImage([FromForm] ProductImageDto model)
        {
            return Ok(await _service.AddImageForProduct(model));
        }

        [HttpPut("UpdateProductImageByProductId")]
        public async Task<IActionResult> UpdateProductImageByProductId([FromForm] ProductImageDto model)
        {
            var productImg =await _service.UpdateProductImageByProductId(model);
            return productImg.Status == 200 ? Ok(productImg) : NotFound(productImg);
        }
        [HttpDelete("DeleteImagesByProductId")]
        public async Task<IActionResult> DeleteImagesByProductId(int productId)
        {
            var productImg =await _service.DeleteImageByProductId(productId);
            return productImg.Status == 200 ? Ok(productImg) : NotFound(productImg);
        }

        [HttpDelete("DeleteProductImageById")]
        public async Task<IActionResult> DeleteProductImageById(int id)
        {
            var productImg =await _service.DeleteImageById(id);
            return productImg.Status == 200 ? Ok(productImg) : NotFound(productImg);
        }
    }
}