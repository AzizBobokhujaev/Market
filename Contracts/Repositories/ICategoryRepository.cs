using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts.Repositories
{
    public interface ICategoryRepository:IRepositoryBase<Category>
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();

        Task<Category> GetCategoriesById(int id);

        Task SaveAsync();
    }
}