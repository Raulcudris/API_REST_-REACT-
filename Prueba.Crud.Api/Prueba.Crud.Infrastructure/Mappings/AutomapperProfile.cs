using AutoMapper;
using Prueba.Crud.Core.DTOs;
using Prueba.Crud.Core.Entities;
using System;

namespace Prueba.Crud.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            //Pasar de User a UserDto 
            CreateMap<User, UserDto>();

            //Pasar de UserDto a User
            CreateMap<UserDto, User>();
        }

      
    }
}
