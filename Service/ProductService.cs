using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Contracts.Repositories;
using Contracts.Services;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Products;
using Entities.Enums;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class ProductService:IProductService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
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
                    Message = $"Product by id = {id}"
                };
            }

            return new()
            {
                Payload = null,
                Status = (int) HttpStatusCode.NotFound,
                Message = $"Product by id = {id} not found"
            };
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllProducts();
        }

        public async Task<int> CreateAsync(CreateProductRequest model, int categoryId)
        {
            var category = await _categoryRepository.GetCategoryById(categoryId);
            if (category==null)
                return 0; 

            var product = new Product
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                Size = model.Size,
                Seasons = model.Seasons,
                Material = model.Material,
                Width = model.Width,
                Length = model.Length,
                IsNew = true,
                IsSale = false,
                UserId = 1,
                CategoryId = categoryId,
                CreatedAt = DateTime.Now
                
            };
            
            await _productRepository.CreateAsync(product);
            await _productRepository.SaveAsync();
            return product.Id;
        }

        public async Task<Response> Update(UpdateProductRequest model, int productId)
        {
            var product = await _productRepository.GetProductById(productId);
            if (product == null)
                return new Response
                    {Status = (int) HttpStatusCode.NotFound, Message = $"Product by id: {productId} not found"};
            product.Name = model.Name;
            product.Price = model.Price;
            product.Description = model.Description;
            product.Size = model.Size;
            product.Seasons = model.Seasons;
            product.Material = model.Material;
            product.Width = model.Width;
            product.Length = model.Length;
            product.IsNew = false;
            product.IsSale = model.IsSale;
            product.UpdatedAt = DateTime.Now;

            _productRepository.Update(product);
            await _productRepository.SaveAsync();   
            return new Response
                {Status = (int) HttpStatusCode.OK, Message = $"Product by id : {productId} successfully updated"};
        }

        public async Task<Response> Delete(int productId)
        {
            var product = await _productRepository.GetProductById(productId);
            if (product == null)
                return new Response
                    {Status = (int) HttpStatusCode.NotFound, Message = $"Product by id : {productId} not found"};
            _productRepository.Delete(product);
            await _productRepository.SaveAsync();
            return new Response
                {Status = (int) HttpStatusCode.OK, Message = $"Product by id : {productId} successfully deleted"};
        }
    }
}