using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
using Entities.Models;

namespace Contracts.Services
{
    public interface IProductService
    {
        public Task<GenericResponse<Product>> GetProductById(int id);
    }
}