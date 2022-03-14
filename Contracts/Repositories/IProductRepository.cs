using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.DataTransferObjects.Products;
using Entities.Models;

namespace Contracts.Repositories
{
    public interface IProductRepository:IRepositoryBase<Product>
    {
        public Task<Product> GetProductById(int id);

        Task SaveAsync();
        Task<IEnumerable<Product>> GetAllProducts();

    }
}