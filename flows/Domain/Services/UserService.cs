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
using System.Web.Helpers;

namespace flows.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IMapper _mapper;
        public UserService(IGenericRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDTO>> GetUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(u => _mapper.Map<UserDTO>(u)).ToList();
        }
        public async Task<UserDTO> GetUserAsync(int id)
        {
            var user = await _userRepository.FindByIdAsync(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> GetUserAsync(string email)
        {
            var res = await _userRepository.GetAsync(x => x.Email.Equals(email));
            if (res.Count() == 0)
                throw new ArgumentOutOfRangeException("can't find user");
            return _mapper.Map<UserDTO>(res.FirstOrDefault());
        }

        public async Task RegisterUserAsync(RegistrationDTO dto)
        {
            User user = _mapper.Map<User>(dto);
            await _userRepository.CreateAsync(user);
        }

        public async Task<IReadOnlyCollection<Claim>> GetUserIdentityAsync(CredentialsDTO dto)
        {
            List<Claim> claims = null;
            var res = await _userRepository.GetAsync(x => x.Email.Equals(dto.Email));
            User user = res.FirstOrDefault();
            if (user != null && Crypto.VerifyHashedPassword(user.Password, dto.Password))
            {
                claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                };
            }
            return claims;
        }
    }
}
