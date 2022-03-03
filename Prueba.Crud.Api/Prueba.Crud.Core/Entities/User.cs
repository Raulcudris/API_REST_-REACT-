using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Crud.Core.Entities
{
    public class User
    {
        //Identificacion del usuario
        public int Id_User { get; set; }
        //Nombre del usuario
        public string Name { get; set; }
        //Apellido del Usuario
        public string LastName { get; set; }
        //Tipo de Documento del Usuario
        public string Document_Type { get; set; }
        //Fecha de Nacimiento del Usuario
        public DateTime Birth_date { get; set; }
        //Valor a Ganar 
        public double Value_to_win { get; set; }
        //Estado Civil (Soltero, Casado, Divorciado, Viudo...)
        public string Civil_Status { get; set; }
    }
}
