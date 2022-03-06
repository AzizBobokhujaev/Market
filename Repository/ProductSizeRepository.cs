using System.Threading.Tasks;
using Contracts.Repositories;
using Entities;
using Entities.Models;

namespace Repository
{
    public class ProductSizeRepository:RepositoryBase<ProductSize>,IProductSizeRepository
    {
        public ProductSizeRepository(DataContext context) : base(context)
        {
        }

        public Task SaveAsync() =>
            Context.SaveChangesAsync();
    }
}