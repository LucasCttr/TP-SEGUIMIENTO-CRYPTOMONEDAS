using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }  // Guardar contraseñas como hashes por seguridad
        public string Mail { get; set; }
    }
}
