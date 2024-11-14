using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs
{
    public class UsuarioCryptoDTO
    {

        public int FavoritoID { get; set; }
        public int UsuarioID { get; set; }
        public string CryptoID { get; set; }
        public decimal ValorPositivo { get; set; }  
        public decimal ValorNegativo { get; set; }

        public string CryptoNombre { get; set; }
    }
}
