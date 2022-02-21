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
        private readonly IProductRepository _repository;
        private readonly IFileService _fileService;
        public ProductService(IProductRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        

        public async Task<GenericResponse<Product>> GetProductById(int id)
        {
            var prod = await _repository.GetProductById(id);
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

        #region CreateAsync
        /*public async Task<Response> CreateAsync(CreateProductsRequest request)
        {
            var productImages = new List<ProductImage>()
            {
                new()
                {
                    ImagePath = await _fileService.AddFileAsync(request.MainImage, FileTypes.Image, nameof(Product)),
                    IsMain = true
                }
            };
            if (request.Images != null)
            {
                productImages.AddRange(request.Images.Select(x=>new ProductImage
                {
                    ImagePath =  _fileService.AddFileAsync(x,FileTypes.Image,nameof(Product)).Result,
                    IsMain = false
                }));
            }

            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Color = request.Color,
                CreatedAt = DateTime.Now

            };
            await _repository.CreateAsync(product);
            await _repository.SaveAsync();
            return new Response{Status = (int)HttpStatusCode.OK,Message = "Product created successfully"};
        }*/
        #endregion
    }
}