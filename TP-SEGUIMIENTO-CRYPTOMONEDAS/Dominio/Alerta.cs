using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Dominio
{
    public class Alerta
    {
        public int AlertaID { get; set; } // Clave primaria de la alerta.
        public int UsuarioID { get; set; } // Referencia al usuario asociado con la alerta.
        public decimal CambioPorcentual { get; set; } // Cambio porcentual configurado para la alerta.
        public DateTime? FechaActivasion { get; set; } // Fecha en la que la alerta se activará (puede ser nula).
        public string TipoCambio { get; set; } // Tipo de cambio asociado a incremento o decremento
        public string CryptomonedaID { get; set; } // Identificador de la criptomoneda asociada.

    }
}
