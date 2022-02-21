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
        //public Task<Response> CreateAsync(CreateProductsRequest request);
    }
}