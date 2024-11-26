using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Dominio
{
    public static class SessionManager
    {
        public static int CurrentUserId { get; set; }
        public static string CurrentMail { get; set; }
        public static string CurrentName { get; set;}

    }
}
