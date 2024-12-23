using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Vistas.OpcionesCrypto
{
    // Patron estado para el cambio de logica en caso de que una crpyto sea favorita o no
    public interface ICryptoState
    {
        void Handle(OpcionesCryptoForm opcionesCrypto);
    }

    public class AgregarState : ICryptoState
    {
        public void Handle(OpcionesCryptoForm opcionesCrypto)
        {
            opcionesCrypto._cryptosFavoritasController.AgregarCryptoAFavorito(opcionesCrypto.cryptoNombre, opcionesCrypto.cryptoId);
            opcionesCrypto.InicioForm.ActualizarListaFavoritasAsync();
            opcionesCrypto.CambiarEstado(new EliminarState());
            opcionesCrypto.ActualizarBotones("Eliminar", true);
        }
    }

    public class EliminarState : ICryptoState
    {
        public void Handle(OpcionesCryptoForm opcionesCrypto)
        {
            opcionesCrypto._cryptosFavoritasController.EliminarCryptoFavorito(opcionesCrypto.cryptoId);
            opcionesCrypto.InicioForm.ActualizarListaFavoritasAsync();
            opcionesCrypto.CambiarEstado(new AgregarState());
            opcionesCrypto.ActualizarBotones("Agregar", false);
        }
    }
}
