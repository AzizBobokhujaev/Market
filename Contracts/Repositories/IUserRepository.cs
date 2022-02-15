using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
using Entities.Models;

namespace Contracts.Repositories
{
    public interface IUserRepository :IRepositoryBase<User>
    {
        public Task<User> GetByEmailAsync(string email);
        Task<IEnumerable<User>> GetListAsync();
    }
}