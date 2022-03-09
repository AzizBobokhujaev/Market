using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.ProductImage;
using Entities.Models;

namespace Contracts.Services
{
    public interface IProductImageService
    {
        Task<Response> AddImageForProduct(ProductImageDto model);
        Task<GenericResponse<IEnumerable<ProductImage>>> GetProductImageByProductId(int productId);

        Task<Response> DeleteImageByProductId(int productId);
        Task<Response> DeleteImageById(int id);
    }
}