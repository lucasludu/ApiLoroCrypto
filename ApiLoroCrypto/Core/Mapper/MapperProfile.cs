using ApiLoroCrypto.Core.Dto;
using ApiLoroCrypto.Core.Models;
using AutoMapper;

namespace ApiLoroCrypto.Core.Mapper
{
    public class MapperProfile: Profile 
    {
        public MapperProfile()
        {
            CreateMap<User,UserRegisterDto>().ReverseMap();
            CreateMap<User,UserLoginDto>().ReverseMap();
        }
    }
}
