using System.Threading.Tasks;
using Contracts.Services;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Users;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using NLog.LayoutRenderers.Wrappers;

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

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var result = await _service.Login(model);
            if (result.Status == 200)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateUserDto model)
        {
            var result = await _service.CreateUser(model);
            if (result.Status == 200)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserDto model, int id)
        {
            var result =await _service.UpdateUser(model, id);
            if (result.Status == 200)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetList()
        {
            return Ok(await _service.GetAllUsers());
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetUserById(id));
        }

        [HttpGet("GetRoleByUserId")]
        public async Task<IActionResult> GetRoleByUserId(int userId)
        {
            return Ok(await _service.GetRoleByUserId(userId));
        }

        [HttpDelete("DeleteById")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var result = await _service.DeleteUserById(id);
            if (result.Status == 200)
                return Ok(result);
            return BadRequest(result);
        }
    }
}