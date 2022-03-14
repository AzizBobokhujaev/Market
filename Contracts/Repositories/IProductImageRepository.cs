using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts.Repositories
{
    public interface IProductImageRepository:IRepositoryBase<ProductImage>
    {
        Task CreateFile(List<ProductImage> files);
        Task<IEnumerable<ProductImage>> GetProdImgByProdId(int productId);

        Task SaveAsync();
        Task<ProductImage> GetProductImageById(int id);
    }
}