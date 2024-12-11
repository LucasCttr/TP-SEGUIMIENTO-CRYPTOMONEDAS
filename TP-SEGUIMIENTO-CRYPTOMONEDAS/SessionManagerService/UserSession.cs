using System;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.SessionManagerService
{
    public class UserSession
    {
        private static UserSession _instance;
        private static readonly object _lock = new object();

        // Propriedad que contiene el usuario actual en sesión
        public UserDTO CurrentUser { get; private set; }

        // Constructor privado para evitar instanciar la clase desde fuera
        private UserSession() { }

        // Propiedad de acceso estático para obtener la instancia única
        public static UserSession Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new UserSession();
                    }
                    return _instance;
                }
            }
        }

        // Método para establecer el usuario actual en sesión
        public void SetCurrentUser(UserDTO user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user), "El usuario no puede ser nulo.");

            CurrentUser = user;
        }

        // Método para limpiar la sesión
        public void ClearSession()
        {
            CurrentUser = null;
        }
    }
}
