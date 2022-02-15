using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Contracts.Repositories;
using Contracts.Services;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Users;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;

        public UserService(IUserRepository userRepository, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }


        public async Task<Response> CreateUser(CreateUserDto model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                return new Response {Status = (int)HttpStatusCode.BadRequest, Message = "Пароли не совпадают!"};
            }

            var user = new User()
            {
                Email = model.Email,
                SecurityStamp = new Guid().ToString(),
                UserName = model.Name
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                //await _userManager.AddToRoleAsync(user, "Контентщик");// Don't work
                await _userRepository.AddToRole(user, "Контентщик");
                return new Response {Status = (int)HttpStatusCode.OK, Message = "Пользователь успешно добавлена!"};
            }

            var errorMessage = result.Errors.FirstOrDefault();
            return new Response {Status = (int)HttpStatusCode.BadRequest, Message = errorMessage?.Description};
        }

        public async Task<GenericResponse<IEnumerable<User>>> GetUserList()
        {
            return new()
            {
                Payload = await _userRepository.GetListAsync(),
                Message = "Ok",
                Status = (int) HttpStatusCode.OK
            };
        }
    }
}