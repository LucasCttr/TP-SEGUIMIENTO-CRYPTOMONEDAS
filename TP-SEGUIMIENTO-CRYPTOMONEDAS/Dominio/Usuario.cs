using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Dominio
{
    public class Usuario
    {
        // Propiedades públicas: necesarias para interactuar con Entity Framework y otras partes de la aplicación.
        public int UsuarioID { get; set; } // Clave primaria del usuario.
        public string Nombre { get; set; } // Nombre del usuario.
        public string Correo { get; set; } // Correo electrónico del usuario.
        public string Contraseña { get; set; } //Contraseña del usuario.
    }
}
