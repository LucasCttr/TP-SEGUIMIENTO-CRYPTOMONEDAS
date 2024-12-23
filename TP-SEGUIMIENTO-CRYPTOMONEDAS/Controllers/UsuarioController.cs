using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.Dominio;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.UntOfWork;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Controllers
{
    public class UsuarioController
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Obtiene las criptomonedas favoritas del usuario.
        public List<FavoritasDTO> ObtenerCryptosFavoritas()
        {
            return _unitOfWork.Usuarios.ObtenerCryptosFavoritasDB();
        }

        public void ModificarDatosUsuario(string nombreUsuario, string correo, string contrasena)
        {
            _unitOfWork.Usuarios.CambiarDatosUsuario(nombreUsuario, correo,contrasena);
        }

        public bool ValidarContraseña(string correo, string contrasena)
        {
            return _unitOfWork.Usuarios.ValidarContraseña(correo, contrasena);
        }

        public UserDTO ObtenerUsuario(string correo)
        {
            return _unitOfWork.Usuarios.ObtenerUsuario(correo);
        }

        public void DarDeAltaUsuario(string nombnre, string correo, string contrasena)
        {
            _unitOfWork.Usuarios.DarDeAltaUsuario(nombnre, correo, contrasena);     
        }
    }
}

