using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts.Repositories
{
    public interface ICategoryRepository:IRepositoryBase<Category>
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();

        Task<Category> GetCategoryById(int id);

        Task SaveAsync();
        Task<IEnumerable<Category>> GetAllWithSubs();
    }
}