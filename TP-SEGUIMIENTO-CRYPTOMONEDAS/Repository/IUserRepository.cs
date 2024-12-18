using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Repository
{
    public interface IUserRepository
    {
        UserDTO ObtenerUsuario(string mail, string contraseña);
        List<FavoritasDTO> ObtenerCryptosFavoritasDB();
        void CambiarDatosUsuario(string nombre, string correo, string contraseña);
        bool ValidarContraseña(string mail, string contraseña);
        void DarDeAltaUsuario(string nombre, string mail, string contraseña);
        bool VerificarExistenciaUsuario(string mail);
    }
}
