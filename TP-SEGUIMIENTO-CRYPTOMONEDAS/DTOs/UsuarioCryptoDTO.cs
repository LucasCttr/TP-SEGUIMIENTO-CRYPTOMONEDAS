using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs
{
    public class UsuarioCryptoDTO
    {
        //Transformar a clase de dominio
        public int FavoritoID { get; set; }
        public int UsuarioID { get; set; }
        public string CryptomonedaID { get; set; }
        public string CryptomonedaNombre { get; set; }
    }
}
