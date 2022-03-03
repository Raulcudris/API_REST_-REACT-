using Prueba.Crud.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Crud.Core.Interfaces
{
    public interface IUserRepository
    {   
        //Obtener todos los Usuarios
        Task<IEnumerable<User>> GetUsers();
        //Obtener un Usuario por Id
        Task<User> GetUser(int id);
        //Insertar un Usuario
        Task InsertUser(User user);
        //Actualizar un Usuario
        Task<bool> UpdateUser(User user);
        //Eliminar un Usuario
        Task<bool> DeleteUser(int id);

    }
}
