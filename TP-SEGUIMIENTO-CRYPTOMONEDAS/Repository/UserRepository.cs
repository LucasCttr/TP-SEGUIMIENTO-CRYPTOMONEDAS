using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.Data;

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
            // Lógica para obtener el usuario de la base de datos
            var usuario= _context.Usuarios
                .FirstOrDefault(u => u.Mail== mail && u.Contrasena == contrasena);

            if (usuario != null)
            {
                //implementar patron singleton
                return usuario;
            }
            else    return null;
        }
    }


    //REGISTRAR USUARIOS
     //   public void Add(UserDTO user)
     //   {
    //        // Lógica para agregar un nuevo usuario
    //        var entity = new User { Nombre = user.Nombre, Contrasena = user.Contrasena };
     //       _context.Users.Add(entity);
     //       _context.SaveChanges();
}
