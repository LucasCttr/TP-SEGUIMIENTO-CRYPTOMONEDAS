using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.SessionManagerService
{
    public static class SessionManager
    {
        // Propiedades estáticas para almacenar los datos de la sesión
        public static int CurrentUserId { get; set; }
        public static string CurrentMail { get; set; }
        public static string CurrentName { get; set; }
        public static string CurrentPassword { get; set; }

    }
}
