using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Contracts.Repositories
{
    public interface IUserRepository :IRepositoryBase<User>
    {
        public Task<User> GetByEmailAsync(string email);
        Task<IEnumerable<User>> GetListAsync();

        public Task<int> AddToRole(User user, string role);
    }
}