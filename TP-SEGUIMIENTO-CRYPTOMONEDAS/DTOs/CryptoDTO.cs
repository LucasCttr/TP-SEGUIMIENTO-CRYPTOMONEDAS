using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs
{
    /// <summary>
    /// Representa los datos principales de una criptomoneda obtenida de la API.
    /// Este DTO contiene información básica como precios, volumen y ranking.
    /// </summary>
    public class CryptoDTO
    {
        // Identificador único de la criptomoneda (proporcionado por la API).
        public string id { get; set; }

        // Nombre completo de la criptomoneda.
        public string name { get; set; }

        // Precio actual en USD.
        public decimal priceUsd { get; set; }

        // Capitalización de mercado en USD.
        public decimal marketCapUsd { get; set; }

        // Volumen de transacciones en las últimas 24 horas en USD.
        public decimal volumeUsd24Hr { get; set; }

        // Cambio porcentual en las últimas 24 horas.
        public decimal changePercent24Hr { get; set; }

        // Símbolo o ticker de la criptomoneda (por ejemplo, BTC para Bitcoin).
        public string symbol { get; set; }

        // Suministro actual de la criptomoneda en circulación.
        public decimal supply { get; set; }

        // Suministro máximo de la criptomoneda (puede ser nulo si no está definido).
        public decimal? maxSupply { get; set; }

        // Precio promedio ponderado de las últimas 24 horas.
        public decimal? vwap24Hr { get; set; }

        // Posición de la criptomoneda en el ranking de capitalización de mercado.
        public int rank { get; set; }
    }
}

