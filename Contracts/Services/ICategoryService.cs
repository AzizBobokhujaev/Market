using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Categories;
using Entities.Models;

namespace Contracts.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllCategories();

        Task<GenericResponse<Category>> GetCategoryById(int id);

        Task<Response> CreateAsync(CreateCategoryRequest request);


        Task<Response> UpdateAsync(int id, UpdateCategoryRequest request);
        Task<Response> DeleteAsync(int id);
    }
}