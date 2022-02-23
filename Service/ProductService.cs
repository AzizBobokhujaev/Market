using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Contracts.Repositories;
using Contracts.Services;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Products;
using Entities.Enums;
using Entities.Models;

namespace Service
{
    public class ProductService:IProductService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IFileService _fileService;
        public ProductService(IProductRepository productRepository, IFileService fileService, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _fileService = fileService;
            _categoryRepository = categoryRepository;
        }

        

        public async Task<GenericResponse<Product>> GetProductById(int id)
        {
            var prod = await _productRepository.GetProductById(id);
            if (prod !=null)
            {
                return new()
                {
                    Payload = prod,
                    Status = (int) HttpStatusCode.OK,
                    Message = $"User by id = {id}"
                };
            }

            return new()
            {
                Payload = null,
                Status = (int) HttpStatusCode.NotFound,
                Message = $"User by id = {id} not found"
            };
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllProducts();
        }

        public async Task<int> CreateAsync(CreateProductRequest model, int categoryId)
        {
            var category = await _categoryRepository.GetCategoriesById(categoryId);
            if (category==null)
                return 0;

            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
                Color = model.Color,
                Description = model.Description,
                Size = model.Size,
                Seasons = model.Seasons,
                Material = model.Material,
                Width = model.Width,
                Length = model.Length,
                IsNew = true,
                IsSale = false,
                IsTop = false,
                Image = "dcdvddcdx",
                UserId = 1,
                CategoryId = categoryId,
                CreatedAt = DateTime.Now
            };
            await _productRepository.CreateAsync(product);
            await _productRepository.SaveAsync();
            return product.Id;

        }
    }
}