using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba.Crud.Core.DTOs;
using Prueba.Crud.Core.Entities;
using Prueba.Crud.Core.Interfaces;
using Prueba.Crud.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;


namespace Prueba.Crud.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {   
        //aqui utilizamos inyeccion de dependencia
        private readonly PruebaApiContext _context;

        public UserRepository(PruebaApiContext context)
        {
            _context = context;
        }

        //Obtenemos todos los usuarios
        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            await Task.Delay(10);
            return users;
        }

        //Obtenemos un usuario
        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id_User == id);
            return user;
        }

        //Insertamos un usuario 
        public async Task InsertUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        //Actualizamos un usuario 
        public async Task<bool> UpdateUser(User user)
        {
            var currentUser = await GetUser(user.Id_User);

            currentUser.Name = user.Name;
            currentUser.LastName = user.LastName;            
            currentUser.Document_Type = user.Document_Type;
            currentUser.Birth_date = user.Birth_date;
            currentUser.Value_to_win = user.Value_to_win;
            currentUser.Civil_Status = user.Civil_Status;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        //Eliminamos un usuario 
        public async Task<bool> DeleteUser(int id)
        {
            var currentUser = await GetUser(id);
            _context.Users.Remove(currentUser);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;

        }

    } 
}
