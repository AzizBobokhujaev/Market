using System.Threading.Tasks;
using Entities.Models;

namespace Contracts.Repositories
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetUsers();
    }
}