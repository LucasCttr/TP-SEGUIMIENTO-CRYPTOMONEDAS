using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.SessionManagerService
{
    public class UserSession
    {
        private static UserSession _instance;
        private static readonly object _lock = new object();

        public UserDTO CurrentUser { get; private set; }

        // Constructor privado
        private UserSession() { }

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

        public void SetCurrentUser(UserDTO user)
        {
            CurrentUser = user;
        }

        public void ClearSession()
        {
            CurrentUser = null;
        }
    }
}
