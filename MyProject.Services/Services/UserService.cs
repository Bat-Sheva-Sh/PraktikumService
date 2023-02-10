using AutoMapper;
using MyProject.Common.DTOs;
using MyProject.Repositories.Interfaces;
using MyProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        //ctor
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> AddAsync(string name, string userId, DateTime dateOfBirth, string familyName, string kind, string hmo)
        {
            return _mapper.Map<UserDTO>(await _userRepository.AddAsync(name, userId, dateOfBirth, familyName, kind, hmo));
        }

        public async Task<UserDTO> UpdateAsync(int id, string name, string userId, DateTime dateOfBirth, string familyName, string kind, string hmo)
        {
            return _mapper.Map<UserDTO>(await _userRepository.UpdateAsync(id, name, userId, dateOfBirth, familyName, kind, hmo));
        }
        //לוגיקה עסקית חסרה
        public async Task DeleteAsync(string userId)
        {
            await _userRepository.DeleteAsync(userId);
        }

        public async Task<UserDTO> GetByTzAsync(string userId)
        {
            //לוגיקה עסקית
            var user = await _userRepository.GetByTzAsync(userId);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<List<UserDTO>> GetListAsync()
        {
            return _mapper.Map<List<UserDTO>>(await _userRepository.GetAllAsync());
        }
    }

}
