using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Dominio
{
    public class Favoritas
    {
        public int FavoritoID { get; set; }
        public int UsuarioID { get; set; }
        public string CryptomonedaID { get; set; }
        public string CryptomonedaNombre { get; set; }
    }
}
