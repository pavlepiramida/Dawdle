using Dawdle.Core.DTO;
using Dawdle.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Dawdle.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IService _service;

        public UsersController(IService service)
        {
            _service = service;
        }

        [ProducesResponseType(statusCode: 200, type: typeof(UserDTO))]
        [HttpGet("{userName}")]
        public async Task<ActionResult<UserDTO>> Get(string userName)
        {
            if (String.IsNullOrWhiteSpace(userName))
                return BadRequest("Invalid request.");
            var user = await _service.GetUser(userName);
            return Ok(user);
        }
    }
}