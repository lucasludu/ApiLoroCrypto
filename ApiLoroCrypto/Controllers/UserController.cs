using ApiLoroCrypto.Core.Dto;
using ApiLoroCrypto.Core.DTO;
using ApiLoroCrypto.Core.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLoroCrypto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _service.GetById(id);
            if(user != null)
            {
                return Ok(user);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateDto dto)
        {
            var user = await _service.Update(id, dto);
            if(user != null)
            {
                return Ok(_mapper.Map<UserDto>(user));
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            bool user = await _service.Delete(id);
            if(user)
            {
                return Ok("User deleted " + user);
            }
            return NotFound();
        }
    }
}
