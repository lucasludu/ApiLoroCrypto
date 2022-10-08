using ApiLoroCrypto.Core.Dto;
using ApiLoroCrypto.Core.Services;
using ApiLoroCrypto.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLoroCrypto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterDto dto)
        {
            var user = await _service.Register(dto); 
            if (user == null)
            {
                return BadRequest();
            }

            return Ok(user);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            var user = await _service.Login(userLoginDto);
            if (user == null)
            {
                return Unauthorized();
            }
           
            var token = _service.Gettoken(user);
            return Ok(new
            {
                user = user,
                token = token
            });
        }
    }
}
