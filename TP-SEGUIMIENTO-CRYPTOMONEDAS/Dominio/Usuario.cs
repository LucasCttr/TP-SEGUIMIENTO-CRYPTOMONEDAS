using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.Data;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Dominio
{
    public class UserRepository
    {
        private static UserRepository _instance;
        private static readonly object _lock = new object();

        private readonly AppDbContext _context;

        // Constructor privado
        private UserRepository(AppDbContext context)
        {
            _context = context;
        }

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

        public UserDTO GetUserById(int userId)
        {
            var user = _context.Usuarios.FirstOrDefault(u => u.UsuarioId == userId);
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
