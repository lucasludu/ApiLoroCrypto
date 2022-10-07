using ApiLoroCrypto.Core.Dto;
using ApiLoroCrypto.Core.Helper;
using ApiLoroCrypto.Core.Models;
using ApiLoroCrypto.Core.Services.Interfaces;
using ApiLoroCrypto.Repository.Interfaces;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiLoroCrypto.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IUnitofWork _unitOfWork;
        private readonly IMapper _mapper;
       

        public AuthService(IConfiguration configuration, IUnitofWork unitOfWork, IMapper mapper)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            
        }
        public string Gettoken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
            };


            var authSigningKey = new SymmetricSecurityKey(key);

            var token = new JwtSecurityToken
            (
                expires: DateTime.Now.AddHours(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );
            return tokenHandler.WriteToken(token);
        }

        public Task<User> Login(UserLoginDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Register(UserRegisterDto dto)
        {
            var user = _mapper.Map<User>(dto);
            var userExist = await _unitOfWork.UserRepository.GetByEmail(user.Email);

            if (userExist == null)
            {
                user.Password = ApiHelper.GetSHA256(user.Password);

                await _unitOfWork.UserRepository.Insert(user);
                await _unitOfWork.SaveChangesAsync();

                

                return this.Gettoken(user);
            }
            return null;
        }
    }
}
