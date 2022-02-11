using System.Threading.Tasks;
using Entities.Models;

namespace Contracts.Services
{
    public interface IUserService
    {
        Task<User> GetUsers();
    }
}