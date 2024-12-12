using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.Data;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.SessionManagerService;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.Dominio;
using Microsoft.EntityFrameworkCore;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        // Valida las credenciales del usuario en la base de datos
        public UserDTO ValidarUsuario(string mail, string contrasena)
        {
            // Consulta directa a la base de datos para validar las credenciales del usuario.
            var usuarioDTO = _context.Usuarios
                .Where(u => u.Correo == mail && u.Contraseña == contrasena) // Comparación de las credenciales
                .Select(u => new UserDTO
                {
                    UsuarioID = u.UsuarioID,
                    Nombre = u.Nombre,
                    Correo = u.Correo
                })
                .FirstOrDefault(); // Obtiene el primer usuario encontrado o null si no hay coincidencias

            return usuarioDTO; // Devuelve el DTO de usuario o null
        }

        // Obtiene las criptomonedas favoritas del usuario desde la base de datos
        public List<FavoritasDTO> ObtenerCryptosFavoritas()
        {
            // Recupera el ID del usuario desde la sesión
            int userId = SessionManager.CurrentUserId; 

            // Consulta las criptomonedas favoritas del usuario
            var favoriteCryptos = _context.UsuariosCryptos
                .Where(fc => fc.UsuarioID == userId) // Usa el ID de usuario de la sesión
                .Select(fc => new FavoritasDTO // Mapea la información a FavoritasDTO
                {
                    UsuarioID = fc.UsuarioID,
                    CryptomonedaID = fc.CryptomonedaID
                })
                .ToList(); // Se convierte en una lista

            return favoriteCryptos; // Devuelve la lista de criptomonedas favoritas
        }

        // Valida si la contraseña ingresada corresponde con la de la sesión
        public bool ValidarContraseña(string contraseña)
        {
            return contraseña == SessionManager.CurrentPassword; // Devuelve true si coinciden, false si no
        }

        // Cambia los datos del usuario en la base de datos
        public void CambiarDatosUsuario(string nombre, string correo, string contraseña)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Correo == correo);

            if (usuario != null)
            {
                // Actualiza los datos del usuario en la base de datos
                usuario.Nombre = nombre;
                usuario.Correo = correo;
                usuario.Contraseña = contraseña;

                // Guarda los cambios
                _context.SaveChanges();

                // Actualiza los datos en la sesión
                SessionManager.CurrentName = nombre;
                SessionManager.CurrentMail = correo;
                SessionManager.CurrentPassword = contraseña;
            }
        }

        // Verifica si un usuario ya existe en la base de datos
        public bool VerificarExistenciaUsuario(string correo)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Correo == correo);

            return usuario != null; // Devuelve true si el usuario existe, false si no
        }

        // Da de alta un nuevo usuario en la base de datos
        public void DarDeAltaUsuario(string nombre, string correo, string contraseña)
        {
            var usuario = new Usuario
            {
                Nombre = nombre,
                Correo = correo,
                Contraseña = contraseña
            };

            _context.Usuarios.Add(usuario);
            _context.SaveChanges(true); // Guarda los cambios
        }
    }
}