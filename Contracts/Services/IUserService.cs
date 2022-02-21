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
        public Task<GenericResponse<IEnumerable<User>>> GetUserList();

        public Task<Response> DeleteUserById(int id);

        Task<GenericResponse<UserDto>> Login(LoginDto model);
        Task<GenericResponse<User>> GetUserById(int id);
        
    }
}