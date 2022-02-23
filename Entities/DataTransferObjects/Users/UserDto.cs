using System.Collections.Generic;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PropertyExtensions = Microsoft.EntityFrameworkCore.PropertyExtensions;

namespace Entities.DataTransferObjects.Users
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string> RoleName { get; set; }
        public string Token { get; set; }

        public UserDto(User user,List<string>roleName, string token)
        {
            Id = user.Id;
            UserName = user.UserName;
            Email = user.Email;
            RoleName = roleName;
            Token = token;
        }
    }
}