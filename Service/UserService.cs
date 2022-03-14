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
using NLog.LayoutRenderers.Wrappers;
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
                await _userRepository.AddToRole(user, model.RoleId);
                return new Response {Status = (int)HttpStatusCode.OK, Message = "Пользователь успешно добавлена!"};
            }
            return new Response {Status = (int)HttpStatusCode.BadRequest, Message = "Ошибка при создании пользователья"};
        }

        public async Task<Response> UpdateUser(UpdateUserDto model, int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user==null)
                return new Response {Status = (int) HttpStatusCode.NotFound, Message = $"User by id {id} not found"};
            if (model.RoleId > 2)
                return new Response {Status = (int) HttpStatusCode.NotFound, Message = "No such role exists"};
            user.UserName = model.UserName;
            user.NormalizedUserName = model.UserName.ToUpper();
            await _userRepository.DeleteRole(user);
            await _userRepository.AddToRole(user, model.RoleId);
            _userRepository.Update(user);
            await _userRepository.SaveAsync();
            return new Response {Status = (int) HttpStatusCode.OK, Message = $"User by id {id} successfully updated"};
        }

        public async Task<GenericResponse<IEnumerable<UserDto>>> GetAllUsers()
        {
            return new()
            {
                
                Payload = await _userRepository.GetAllUsers(),
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

        public async Task<GenericResponse<AuthenticationResponse>> Login(LoginDto model)
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

            if (!await _userManager.CheckPasswordAsync(user,model.Password)) return new GenericResponse<AuthenticationResponse> {Status = (int) HttpStatusCode.Unauthorized, Message = "Неправильный пароль "};

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
                Payload = new AuthenticationResponse(user,userRoles.ToList(),new JwtSecurityTokenHandler().WriteToken(token)),
                Status = (int) HttpStatusCode.OK,
                Message = "Успешный вход!"
            };
        }

        public async Task<GenericResponse<User>> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user != null)
            {
                return new() {Payload = user, Status = (int) HttpStatusCode.OK, Message = $"User by id : {id}"};
            }

            return new()
                {Payload = null, Status = (int) HttpStatusCode.NotFound, Message = $"User by id : {id} not found"};
        }

        public async Task<IdentityRole<int>> GetRoleByUserId(int userId)
        {
            var user = await _userRepository.GetUserById(userId);
            if (user == null)
                return null;
            return await _userRepository.GetRoleByUserId(userId);
        }
    }
}
























