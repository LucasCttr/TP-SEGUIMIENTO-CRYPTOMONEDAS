using System;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.Data;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.SessionManagerService
{
    public class UserRepository
    {
        private static UserRepository _instance;
        private static readonly object _lock = new object();

        private readonly AppDbContext _context;

        // Constructor privado para evitar instancias externas
        private UserRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "El contexto de la base de datos no puede ser nulo.");
        }

        // Método para obtener la única instancia de la clase, si no existe se crea
        public static UserRepository GetInstance(AppDbContext context)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new UserRepository(context);
                }
                return _instance;
            }
        }

        // Método para obtener un usuario por su ID
        public UserDTO GetUserById(int userId)
        {
            if (userId <= 0) throw new ArgumentOutOfRangeException(nameof(userId), "El ID de usuario debe ser mayor a cero.");

            var user = _context.Usuarios.FirstOrDefault(u => u.UsuarioID == userId);
            if (user != null)
            {
                return new UserDTO
                {
                    Nombre = user.Nombre,
                    Correo = user.Correo,
                    Contraseña = user.Contraseña
                };
            }
            return null;
        }
    }
}