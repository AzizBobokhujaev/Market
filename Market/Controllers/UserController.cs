using System.Threading.Tasks;
using Contracts.Services;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public  UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<User> GetUsers()
        {
            return await _service.GetUsers();
        }
        
    }
}