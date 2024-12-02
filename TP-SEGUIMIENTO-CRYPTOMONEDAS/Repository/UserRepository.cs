using Microsoft.VisualBasic.ApplicationServices;
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

        public UserDTO ValidarUsuario(string mail, string contrasena)
        {
            // Consulta directa a la base de datos, sin traer todas las entidades.
            var usuarioDTO = _context.Usuarios
                .Where(u => u.Correo == mail && u.Contraseña == contrasena) // Compara directamente en la base de datos.
                .Select(u => new UserDTO
                {
                    UsuarioID = u.UsuarioID,
                    Nombre = u.Nombre,
                    Correo = u.Correo
                })
                .FirstOrDefault();

            return usuarioDTO; // Devuelve el DTO o null si no encuentra el usuario.
        }

        public List<FavoritasDTO> ObtenerCryptosFavoritas()
        {
            // Accede al userId desde la sesión (suponiendo que tienes una forma de acceder a la sesión)
            int userId = SessionManager.CurrentUserId; // Cambia esto según tu implementación de sesión

            // Obtiene las criptomonedas favoritas del usuario especificado de manera síncrona
            var favoriteCryptos = _context.UsuariosCryptos
                .Where(fc => fc.UsuarioID == userId) // Usa el userId de la sesión
                .Select(fc => new FavoritasDTO // Mapea a UsuarioCryptoDTO
                {
                    UsuarioID = fc.UsuarioID,
                    CryptomonedaID = fc.CryptomonedaID
                })
                .ToList(); // Usa ToList() para una operación síncrona

            return favoriteCryptos; // Retorna la lista de criptomonedas favoritas
        }

        public bool ValidarContraseña(string contraseña)
        {
            if (contraseña == SessionManager.CurrentPassword) { return true; } else { return false; }
        }

        public void CambiarDatosUsuario(string nombre, string correo, string contraseña)
        {
            {
                // Buscar al usuario por el correo (o algún identificador único)
                var usuario = _context.Usuarios.FirstOrDefault(u => u.Correo == correo);

                if (usuario != null)
                {
                    // Actualizar los campos del usuario
                    usuario.Nombre = nombre;
                    usuario.Correo = correo;
                    usuario.Contraseña = contraseña;

                    // Guardar los cambios en la base de datos
                    _context.SaveChanges();

                    SessionManager.CurrentName = nombre;
                    SessionManager.CurrentMail = correo;
                    SessionManager.CurrentPassword = contraseña;
                }
            }
        }

        public bool VerificarExistenciaUsuario(string correo)
        {
            // Buscar al usuario por el correo (o algún identificador único)
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Correo == correo);

            if (usuario != null) return true; else { return false; }
        }

        public void DarDeAltaUsuario(string nombre, string correo, string contraseña)
        {
            var usuario = new Usuario
            {
                Nombre = nombre,
                Correo = correo,
                Contraseña = contraseña

            };
            _context.Usuarios.Add(usuario);
            _context.SaveChanges(true);
        }
    }
}
