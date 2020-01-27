using AutoMapper;
using flows.Domain.DTO;
using flows.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flows.Domain.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateUsersMap();
        }

        private void CreateUsersMap()
        {
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
        }
    }
}
