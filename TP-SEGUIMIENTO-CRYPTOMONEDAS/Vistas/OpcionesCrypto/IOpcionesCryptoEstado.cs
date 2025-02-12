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
            opcionesCrypto._APIController.AgregarCryptoAFavorito(opcionesCrypto.cryptoNombre, opcionesCrypto.cryptoId);  // Se agrega la crypto a favorito
            opcionesCrypto.InicioForm.ActualizarListaFavoritasAsync();  //Se actualiza la lista de favoritos del Inicio
            opcionesCrypto.CambiarEstado(new EliminarState());  //Se cambia al otro estado
            opcionesCrypto.ActualizarBotones("Eliminar", true);   //Se cambia el boton al del otro estado
        }
    }

    public class EliminarState : ICryptoState
    {
        public void Handle(OpcionesCryptoForm opcionesCrypto)
        {
            opcionesCrypto._APIController.EliminarCryptoFavorito(opcionesCrypto.cryptoId);
            opcionesCrypto.InicioForm.ActualizarListaFavoritasAsync();
            opcionesCrypto.CambiarEstado(new AgregarState());
            opcionesCrypto.ActualizarBotones("Agregar", false);
        }
    }
}
