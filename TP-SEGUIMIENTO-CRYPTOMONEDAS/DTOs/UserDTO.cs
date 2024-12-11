using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs
{
    
    /// <summary>
    /// Representa los datos básicos de un usuario dentro del sistema.
    /// Este DTO se utiliza para transferir la información del usuario entre capas de la aplicación.
    /// </summary>
    public class UserDTO
    {
        /// Identificador único del usuario.
        public int UsuarioID { get; set; }

        /// Nombre del usuario.
        public string Nombre { get; set; }

        /// Contraseña del usuario, almacenada como un hash para seguridad.
        public string Contraseña { get; set; }

        /// Dirección de correo electrónico del usuario.
        public string Correo { get; set; }
    }
}
