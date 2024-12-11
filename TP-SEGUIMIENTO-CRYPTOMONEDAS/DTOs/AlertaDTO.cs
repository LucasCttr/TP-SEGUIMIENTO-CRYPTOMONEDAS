using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs
{
    public class AlertaDTO    
    {
        /// <summary>
        /// Representa una alerta configurada por un usuario para monitorear cambios en una criptomoneda.
        /// Este DTO contiene la información necesaria para manejar las alertas sobre las criptomonedas.
        /// </summary>
        public int AlertaID { get; set; } // Identificador único de la alerta.
        public int UsuarioID { get; set; } // Identificador del usuario asociado con la alerta.
        public decimal CambioPorcentual { get; set; } // Porcentaje de cambio configurado para la alerta.
        public DateTime? FechaActivasion { get; set; } // Fecha en la que se activará la alerta (puede ser nula).
        public string TipoCambio { get; set; } // Tipo de cambio (por ejemplo: "subida" o "bajada").
        public string CryptomonedaID { get; set; } // Identificador de la criptomoneda asociada.
    }
}

