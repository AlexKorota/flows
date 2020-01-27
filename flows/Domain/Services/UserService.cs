using AutoMapper;
using flows.Domain.DTO;
using flows.Domain.Entities;
using flows.Domain.Repositories.Interfaces;
using flows.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        public async Task RegisterUserAsync(RegistrationDTO dto)
        {
            try
            {
                User user = _mapper.Map<User>(dto);
                await _userRepository.Create(user);
            } catch(Exception e) // переделать на разные эксепшены, а не только на 1 общий
            {
                Console.WriteLine(e);
            }
        }

        public async Task<IReadOnlyCollection<Claim>> GetUserIdentity(CredentialsDTO dto)
        {
            List<Claim> claims = null;
            var user = await _userRepository.GetByEmailAndPassword(dto.Email, BCrypt.Net.BCrypt.HashPassword(dto.Password, BCrypt.Net.BCrypt.GenerateSalt())); //TODO: вытащить соль из конфига
            if (user != null)
            {
                claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email)
                };
            }
            return claims;
        }
    }
}
