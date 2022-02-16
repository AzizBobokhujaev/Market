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

        public Task<Response> DeleteUserById(int id);
        public Task<Response> DeleteUserByEmail(string email);


        Task<GenericResponse<UserDto>> Login(LoginDto model);
    }
}