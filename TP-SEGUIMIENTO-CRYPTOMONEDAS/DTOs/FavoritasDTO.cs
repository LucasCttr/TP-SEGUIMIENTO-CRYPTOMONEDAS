using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs
{
    /// <summary>
    /// Representa los datos relacionados con una criptomoneda que un usuario ha marcado como favorita.
    /// Este DTO se utiliza para transferir la relación entre un usuario y una criptomoneda.
    /// </summary>
    public class FavoritasDTO
    {
        // Identificador único de la entrada favorita.
        public int FavoritoID { get; set; }

        // Identificador del usuario que ha marcado la criptomoneda como favorita.
        public int UsuarioID { get; set; }

        // Identificador de la criptomoneda.
        public string CryptomonedaID { get; set; }

        // Nombre de la criptomoneda.
        public string CryptomonedaNombre { get; set; }
    }
}