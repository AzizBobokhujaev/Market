using System.Net;
using System.Threading.Tasks;
using Contracts.Repositories;
using Contracts.Services;
using Entities.DataTransferObjects;
using Entities.Models;

namespace Service
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        

        public async Task<GenericResponse<Product>> GetProductById(int id)
        {
            var prod = await _repository.GetProductById(id);
            if (prod !=null)
            {
                return new()
                {
                    Payload = prod,
                    Status = (int) HttpStatusCode.OK,
                    Message = $"User by id = {id}"
                };
            }

            return new()
            {
                Payload = null,
                Status = (int) HttpStatusCode.NotFound,
                Message = $"User by id = {id} not found"
            };
        }
    }
}