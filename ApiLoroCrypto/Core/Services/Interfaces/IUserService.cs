using ApiLoroCrypto.Core.Dto;
using ApiLoroCrypto.Core.DTO;
using ApiLoroCrypto.Core.Models;

namespace ApiLoroCrypto.Core.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> Delete(int id);
        Task<UserDto> GetById(int id);
        Task<User> Update(int id, UserUpdateDto dto);
    }
}
