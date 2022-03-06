﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Contracts.Repositories;
using Contracts.Services;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.ProductImage;
using Entities.Models;

namespace Service
{
    public class ProductImageService:IProductImageService
    {
        private readonly IProductImageRepository _imageRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductImageService(IProductImageRepository imageRepository, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _imageRepository = imageRepository;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<Response> AddImageForProduct(ProductImageDto model)
        {
            var product = await _productRepository.GetProductById(model.ProductId);
            var category = await _categoryRepository.GetCategoryById(product.CategoryId);

            var files = new List<ProductImage>();
            if (model.Images == null)
                return new Response {Status = (int) HttpStatusCode.BadRequest, Message = "Failed"};
            foreach (var file in model.Images)
            {
                var path = $"wwwroot/Images/Product/{category.Name}/{model.ProductId}/{model.Color}";
                var fullPath = Path.GetFullPath(path);
                if (!Directory.Exists(fullPath))
                {
                    Directory.CreateDirectory(fullPath);    
                }

                var fileExtension = Path.GetExtension(file.FileName);
                var fileName = $"{Guid.NewGuid().ToString()}.{fileExtension}";
                var finalFileName = Path.Combine(fullPath, fileName);
                var imagePath = Path.Combine(path, fileName);
                await using (var fileStream = System.IO.File.Create(finalFileName))
                {
                    await file.CopyToAsync(fileStream);
                }
                files.Add(new ProductImage
                {
                    Color = model.Color,
                    ImagePath = imagePath,
                    ProductId = model.ProductId,
                });
            }
            
            await _imageRepository.CreateFile(files);
            return new Response {Status = (int) HttpStatusCode.OK, Message = "Files added successfully"};

        }

        public async Task<GenericResponse<IEnumerable<ProductImage>>> GetProductImageByProductId(int productId)
        {
            var images= await _imageRepository.GetProdImgByProdId(productId);
            if (images.Count() == 0)
            {
                return new ()
                {
                    Payload = null, Status = (int) HttpStatusCode.NotFound,
                    Message = $"ProductImages by productId {productId} not found"
                };
            }

            return new()
            {
                Payload = images,
                Status = (int) HttpStatusCode.OK,
                Message = "Ok"
            };
        }
    }
}