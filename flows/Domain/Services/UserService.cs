﻿using AutoMapper;
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
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDTO>> GetUsersAsync()
        {
            var users = await _userRepository.GetListAsync();
            return users.Select(u => _mapper.Map<UserDTO>(u)).ToList();
        }
        public async Task<UserDTO> GetUserAsync(int id)
        {
            var user = await _userRepository.GetAsync(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> GetUserAsync(string email)
        {
            var user = await _userRepository.GetAsync(email);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task RegisterUserAsync(RegistrationDTO dto)
        {
            try
            {
                User user = _mapper.Map<User>(dto);
                await _userRepository.CreateAsync(user);
            } catch(Exception e) // переделать на разные эксепшены, а не только на 1 общий
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public async Task<IReadOnlyCollection<Claim>> GetUserIdentityAsync(CredentialsDTO dto)
        {
            List<Claim> claims = null;
            var user = await _userRepository.GetAsync(dto.Email);
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
