using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Contracts.Repositories;
using Contracts.Services;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Users;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, UserManager<User> userManager, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _configuration = configuration;
        }


        public async Task<Response> CreateUser(CreateUserDto model)
        {
            var resultUser = await _userRepository.GetByEmailAsync(model.Email);
            if (resultUser != null)
                return new Response
                    {Status = (int) HttpStatusCode.BadRequest, Message = "Пользователь с таким логином уже существует"};
            
            
            if (model.Password != model.ConfirmPassword)
                return new Response {Status = (int)HttpStatusCode.BadRequest, Message = "Пароли не совпадают!"};
            

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
            return new Response {Status = (int)HttpStatusCode.BadRequest, Message = "Ошибка при создании пользователья"};
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
        

        public async Task<Response> DeleteUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user==null)
            {
                return new Response{Status = (int)HttpStatusCode.NotFound,Message = "Пользователь не найден"};
            }
            _userRepository.Delete(user);
            await _userRepository.SaveAsync();
            return new Response {Status = (int) HttpStatusCode.OK, Message = "Пользователь успешно удален"};
        }

        public async Task<GenericResponse<UserDto>> Login(LoginDto model)
        {
            var user = await _userRepository.GetByEmailAsync(model.Email);
            if (user==null)
            {
                return new ()
                {
                    Status = (int) HttpStatusCode.NotFound,
                    Message = "Пользователь с таким электронным адресом не найден"
                };
            }

            if (!await _userManager.CheckPasswordAsync(user,model.Password)) return new GenericResponse<UserDto> {Status = (int) HttpStatusCode.Unauthorized, Message = "Неправильный пароль "};

            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, model.Email),
                new Claim("UserId", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role,userRole));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(7),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new ()
            {
                Payload = new UserDto(new JwtSecurityTokenHandler().WriteToken(token)),
                Status = (int) HttpStatusCode.OK,
                Message = "Успешный вход!"
            };
        }
    }
}
























