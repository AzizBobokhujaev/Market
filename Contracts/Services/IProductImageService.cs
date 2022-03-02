using System.Threading.Tasks;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.ProductImage;

namespace Contracts.Services
{
    public interface IProductImageService
    {
        Task<Response> AddImageForProduct(ProductImageDto model);
    }
}