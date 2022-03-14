using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Users;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Contracts.Services
{
    public interface IUserService
    {
        public Task<Response> CreateUser(CreateUserDto model);

        public Task<Response> UpdateUser(UpdateUserDto model, int id);
        public Task<GenericResponse<IEnumerable<UserDto>>> GetAllUsers();

        public Task<Response> DeleteUserById(int id);

        Task<GenericResponse<AuthenticationResponse>> Login(LoginDto model);
        Task<GenericResponse<User>> GetUserById(int id);

        Task<IdentityRole<int>> GetRoleByUserId(int userId);

    }
}