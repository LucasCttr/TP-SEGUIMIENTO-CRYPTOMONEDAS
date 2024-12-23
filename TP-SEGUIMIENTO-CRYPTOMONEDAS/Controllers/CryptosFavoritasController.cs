using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.UntOfWork;
using static TP_SEGUIMIENTO_CRYPTOMONEDAS.Repository.CryptomonedasRepository;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Controllers
{
    public class CryptosFavoritasController
    {
        private readonly IUnitOfWork _unitOfWork;

        public CryptosFavoritasController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Busca los datos actuales de una criptomoneda específica en el mercado.
        public CryptoDTO ObtenerDatosActualesDeUnaCrypto(string crypto)
        {
            return _unitOfWork.CryptosFavoritas.BuscarCryptoEnMercado(crypto);
        }

        public async Task<List<CryptoDTO>> ObtenerMercadoAPI()
        {
            return await _unitOfWork.CryptosFavoritas.ObtenerMercado();
        }

        public bool VerificarCryptoEsFavorito(string idCrypto)
        {
            return _unitOfWork.CryptosFavoritas.VerificarSiEsFavorito(idCrypto);
        }

        public List<PuntoHistorial> ObtenerHistorialDeUnaCrypto(string cryptoID, string intervalo)
        {
            return _unitOfWork.CryptosFavoritas.ObtenerHistorialDeUnaCrypto(cryptoID, intervalo);
        }

        public CryptoDTO BuscarCryptoEnMercado(string cryptoID)
        {
            return _unitOfWork.CryptosFavoritas.BuscarCryptoEnMercado(cryptoID);
        }

        public void AgregarCryptoAFavorito(string cryptoNombre, string cryptoID)
        {
            _unitOfWork.CryptosFavoritas.AgregarCryptoAFavorito(cryptoNombre, cryptoID);
        }

        public void EliminarCryptoFavorito(string cryptoID)
        {
            _unitOfWork.CryptosFavoritas.EliminarCryptoDeFavorito(cryptoID);
        }
    }
}
