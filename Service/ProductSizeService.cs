using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Repositories;
using Contracts.Services;
using Entities.Models;

namespace Service
{
    public class ProductSizeService:IProductSizeService
    {
        private readonly IProductSizeRepository _productSizeRepository;

        public ProductSizeService(IProductSizeRepository productSizeRepository)
        {
            _productSizeRepository = productSizeRepository;
        }


        public async Task CreateProductSize(int[] sizes,int productId)
        {
            foreach (var size in sizes)
            {
                var productSize = new ProductSize()
                {
                    ProductId = productId,
                    Size = size
                };
                await _productSizeRepository.CreateAsync(productSize);
                await _productSizeRepository.SaveAsync();
            }
        }
    }
}