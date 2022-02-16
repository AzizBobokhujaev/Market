using System.IdentityModel.Tokens.Jwt;

namespace Entities.DataTransferObjects
{
    public class Response
    {
        public int Status { get; set; }
        public string Message { get; set; }
    }
}