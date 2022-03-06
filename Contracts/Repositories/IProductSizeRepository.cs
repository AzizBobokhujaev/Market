using System.Threading.Tasks;
using Entities.Models;

namespace Contracts.Repositories
{
    public interface IProductSizeRepository:IRepositoryBase<ProductSize>
    {
        Task SaveAsync();
    }
}