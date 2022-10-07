using ApiLoroCrypto.Core.Dto;
using ApiLoroCrypto.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLoroCrypto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _service;

        public AuthController(AuthService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDto dto)
        {
            var user = await _service.Register(dto); 
            if (user == null)
            {
                return BadRequest();
            }

            return Ok(user);
        }


    }
}
