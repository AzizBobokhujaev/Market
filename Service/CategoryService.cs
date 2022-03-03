using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Contracts.Repositories;
using Contracts.Services;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Categories;
using Entities.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Service
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<GenericResponse<IEnumerable<Category>>> GetAllCategories()
        {
            return new()
            {
                Payload = await _repository.GetAllCategoriesAsync(),
                Status = (int) HttpStatusCode.OK,
                Message = "AllCategories"
            };
        }
        public async Task<GenericResponse<IEnumerable<Category>>> GetAllWithSubs()
        {
            return new()
            {
                Payload = await _repository.GetAllWithSubs(),
                Status = (int) HttpStatusCode.OK,
                Message = "AllCategoriesWithSubs"
            };
        }

        public async Task<GenericResponse<Category>> GetCategoryById(int id)
        {
            var category = await _repository.GetCategoryById(id);
            if (category != null)
            {
                return new()
                {
                    Payload = category,
                    Status = (int) HttpStatusCode.OK,
                    Message = $"Category by id : {id} = {category.Name}"
                };
            }

            return new()
            {
                Payload = null,
                Status = (int) HttpStatusCode.NotFound,
                Message = $"Category by id : {id} not found"
            };
        }

        public async Task<Response> CreateAsync(CreateCategoryRequest request)
        {
            var category = new Category
            {
                Name = request.Name,
                ParentId = request.ParentId
            };

            await _repository.CreateAsync(category);
            await _repository.SaveAsync();
            return new Response{Status = (int)HttpStatusCode.OK,Message = "Category created successfully"};
        }

        public async Task<Response> UpdateAsync(int id, UpdateCategoryRequest request)
        {
            var category = await _repository.GetCategoryById(id);
            if (category == null)
            {
                return new Response
                    {Status = (int) HttpStatusCode.NotFound, Message = $"Category by id : {id} not found"};
            }
            category.Name = request.Name;
            category.ParentId = request.ParentId;
             _repository.Update(category);
             await _repository.SaveAsync();
             return new() {Status = (int) HttpStatusCode.OK, Message = $"Category by id : {id} successfully updated"};
        }

        public async Task<Response> DeleteAsync(int id)
        {
            var category = await _repository.GetCategoryById(id);
            if (category == null)
                return new Response
                    {Status = (int) HttpStatusCode.NotFound, Message = $"Category by id : {id} not found"};
            
            _repository.Delete(category);
            await _repository.SaveAsync();
            return new() {Status = (int) HttpStatusCode.OK, Message = $"Category by id : {id} successfully deleted"};
        }

        
    }
}