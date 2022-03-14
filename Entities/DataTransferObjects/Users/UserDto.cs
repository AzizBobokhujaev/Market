using System.Collections.Generic;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace Entities.DataTransferObjects.Users
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
    }
}