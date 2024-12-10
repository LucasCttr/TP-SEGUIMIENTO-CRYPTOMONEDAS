using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;
using System.Collections.Generic;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.Dominio;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Repository
{
    public interface ICryptomonedasRepository
    {
        Task<List<CryptoDTO>> ObtenerMercado(); // Definición del método asíncrono
        CryptoDTO BuscarCryptoEnMercado(string IdCrypto);
        List<PuntoHistorial> ObtenerHistorialDeUnaCrypto(string idCrypto, string intervalo);
        void EliminarCryptoDeFavorito(string nombreCrypto);
        void AgregarCryptoAFavorito(string nombreCrypto, string idCrypto);
        bool VerificarSiEsFavorito(string idCrypto);   
    }
}
