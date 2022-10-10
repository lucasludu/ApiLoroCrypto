using ApiLoroCrypto.Core.Dto;
using ApiLoroCrypto.Core.DTO;
using ApiLoroCrypto.Core.Models;
using ApiLoroCrypto.Core.Services.Interfaces;
using ApiLoroCrypto.Repository.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;

namespace ApiLoroCrypto.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitofWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitofWork unitofWork, IMapper mapper)
        {
            _unitOfWork = unitofWork;
            _mapper = mapper;   
        }

        public async Task<bool> Delete(int id)
        {
            var user = await _unitOfWork.UserRepository.GetById(id);
            if(user != null)
            {
                await _unitOfWork.UserRepository.Delete(user);
                await _unitOfWork.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<UserDto> GetById(int id)
        {
            var existing = await _unitOfWork.UserRepository.GetById(id);
            if(existing != null)
            {
                return _mapper.Map<UserDto>(existing);
            }
            return null;
        }

        public async Task<User> Update(int id, UserUpdateDto dto)
        {
            var existingUser = await _unitOfWork.UserRepository.GetById(id);
            if (existingUser == null)
            {
                return null;
            }
            else
            {
                _mapper.Map(dto, existingUser);
                _unitOfWork.UserRepository.Update(existingUser);
                await _unitOfWork.SaveChangesAsync();

                return existingUser;
            }
        }
    }
}
