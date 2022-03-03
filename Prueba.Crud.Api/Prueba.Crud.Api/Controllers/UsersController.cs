using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba.Crud.Core.DTOs;
using Prueba.Crud.Core.Entities;
using Prueba.Crud.Core.Interfaces;
using Prueba.Crud.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba.Crud.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //Controlador de User
    public class UsersController : ControllerBase
    {
        //Inyeccion de Dependencia
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        //Inyeccion de Dependencia
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        //Buscar todos los usuarios Creados base de Datos
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepository.GetUsers();
            var usersDtos = _mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(usersDtos);
        }

        //Buscar un Usuario por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userRepository.GetUser(id);
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }

        //Insertar Un Usuario a la base de Datos
        [HttpPost]
        public async Task<IActionResult> InsertUser(int id, UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _userRepository.InsertUser(user);
            return Ok(user);
        }

        //Atualizar Un Usuario Registrado..
        [HttpPut]
        public async Task<IActionResult> UpdateUser (int id, UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            user.Id_User = id;

            await _userRepository.UpdateUser(user);
            return Ok(user);
        }

        //Elimnar Un usuario Registrado 
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userRepository.DeleteUser(id);
            return Ok(result);
        } 



    }
}
