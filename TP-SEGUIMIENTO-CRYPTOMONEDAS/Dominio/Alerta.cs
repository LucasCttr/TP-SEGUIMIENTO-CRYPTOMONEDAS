using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Dominio
{
    internal class Alerta
    {
        public int AlertaID { get; set; }
        public int UsuarioID { get; set; }
        public decimal CambioPorcentual { get; set; }
        public DateTime? FechaActivasion { get; set; }
        public string TipoCambio { get; set; }
        public string CryptomonedaID { get; set; }
    }
}
