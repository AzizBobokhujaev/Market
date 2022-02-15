using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Users;
using Entities.Models;

namespace Contracts.Services
{
    public interface IUserService
    {
        public Task<Response> CreateUser(CreateUserDto model);
        Task<GenericResponse<IEnumerable<User>>> GetUserList();
    }
}