using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Entities.DataTransferObjects.Users
{
    public class UserDto
    {
        public string Token { get; set; }

        public UserDto( string token)
        {
            Token = token;
        }
    }
}