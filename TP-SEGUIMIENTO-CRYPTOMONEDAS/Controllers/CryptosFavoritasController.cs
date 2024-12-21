using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.UntOfWork;

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
    }
}
