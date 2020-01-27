using AutoMapper;
using flows.Domain.DTO;
using flows.Domain.Entities;
using flows.Domain.Repositories.Interfaces;
using flows.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flows.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<List<UserDTO>> GetUsersAsync()
        {
            var users = await _userRepository.GetList();
            return users.Select(u => _mapper.Map<UserDTO>(u)).ToList();
        }
        public async Task<UserDTO> GetCurrentUser(int id)
        {
            var user = await _userRepository.GetById(id);
            return _mapper.Map<UserDTO>(user);
        }
        public async Task<User> RegisterUserAsync(UserDTO user)
        {
            //TODO: Add mapping with md5 hashPassword
            await _userRepository.Create(user);
            return user;
        }


    }
}
