using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Users;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Contracts.Repositories
{
    public interface IUserRepository :IRepositoryBase<User>
    {
        public Task<User> GetByEmailAsync(string email);
        Task<List<UserDto>> GetAllUsers();

        Task<IdentityRole<int>> GetRoleByUserId(int userId);

        public Task<int> AddToRole(User user, int roleId);
        public Task<int> UpdateRole(int userId, int roleId);
        Task<int> DeleteRole(User user);

        public Task<User> GetUserById(int userId);

        Task SaveAsync();


    }
}