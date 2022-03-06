using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts.Services
{
    public interface IProductSizeService
    {
        Task CreateProductSize(int[] sizes,int productId);
    }
}