using ApiLoroCrypto.Core.Dto;
using ApiLoroCrypto.Core.DTO;
using ApiLoroCrypto.Core.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiLoroCrypto.Controllers
{
    [ApiExplorerSettings(GroupName = "ApiAuth")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;
        private readonly IMapper _mapper;

        public AuthController(IAuthService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Register new User
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Login User
        /// </summary>
        /// <param name="userLoginDto"></param>
        /// <returns></returns>
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
                user = _mapper.Map<UserDto>(user),
                token = token
            });
        }
    }
}
