using ApiLoroCrypto.Core.Dto;
using ApiLoroCrypto.Core.Models;

namespace ApiLoroCrypto.Core.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> Register(UserRegisterDto dto);

        string Gettoken(User user);

        Task<User> Login(UserLoginDto dto);

    }
}
