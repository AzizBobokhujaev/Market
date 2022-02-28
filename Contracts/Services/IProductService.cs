using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Products;
using Entities.Models;

namespace Contracts.Services
{
    public interface IProductService
    {
        public Task<GenericResponse<Product>> GetProductById(int id);
        Task<IEnumerable<Product>> GetAllProducts();
        Task<int> CreateAsync(CreateProductRequest model, int categoryId);
        Task<Response> Update(UpdateProductRequest model, int productId);
        Task<Response> Delete(int productId);
    }
}