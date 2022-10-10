using ApiLoroCrypto.Core.DTO;
using ApiLoroCrypto.Core.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiLoroCrypto.Controllers
{
    [Authorize]
    [ApiExplorerSettings(GroupName = "ApiUser")]
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

        /// <summary>
        /// Get User By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Update User By ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Delete User By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
