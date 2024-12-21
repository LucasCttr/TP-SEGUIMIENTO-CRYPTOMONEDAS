using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.UntOfWork;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Controllers
{
    public class UsuarioController
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Obtiene las criptomonedas favoritas del usuario.
        public List<FavoritasDTO> ObtenerCryptosFavoritas()
        {
            return _unitOfWork.Usuarios.ObtenerCryptosFavoritasDB();
        }
    }
}

