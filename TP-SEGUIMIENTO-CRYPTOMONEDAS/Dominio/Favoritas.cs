using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Dominio
{
    public class Favoritas
    {
        public int FavoritoID { get; set; } // Clave primaria de la tabla Favoritas.
        public int UsuarioID { get; set; } // Identificador del usuario relacionado con la criptomoneda favorita.
        public string CryptomonedaID { get; set; } // Identificador único de la criptomoneda.
        public string CryptomonedaNombre { get; set; } // Nombre de la criptomoneda.
    }
}
