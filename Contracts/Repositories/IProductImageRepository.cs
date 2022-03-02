using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts.Repositories
{
    public interface IProductImageRepository:IRepositoryBase<ProductImage>
    {
        Task<List<ProductImage>> GetAll();
        Task CreateFile(List<ProductImage> files);
        
    }
}