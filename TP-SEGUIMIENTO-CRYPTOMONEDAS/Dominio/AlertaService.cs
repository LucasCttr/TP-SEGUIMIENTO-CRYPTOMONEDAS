using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.UntOfWork;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Dominio
{
    public class AlertaService
    {
        public event Action<string> alertaActivada;
        private readonly IUnitOfWork _unitOfWork;
        private readonly AlertaObserverManager _observerManager;

        public AlertaService(IUnitOfWork unitOfWork, AlertaObserverManager observerManager)
        {
            _unitOfWork = unitOfWork;
            _observerManager = observerManager;
        }

        public void NotificarCambio(string nombreCrypto, decimal cambio24Hs)
        {
            _observerManager.NotificarObservadores(nombreCrypto, cambio24Hs);
        }

        public void ActualizarAlerta(string nombreCrypto, decimal valorAlerta, string tipoAlerta, int idAlerta)
        {
            // Actualiza la alerta en la base de datos
            _unitOfWork.Alerta.GuardarValoresAlerta(idAlerta, valorAlerta, tipoAlerta);

            // Modifica el observador en memoria si existe, si no lo crea   (Es necesario crearlo aca para poder asociarle la accion de EliminarAlerta )
            _observerManager.ModificarObservador(nombreCrypto, valorAlerta, tipoAlerta, idAlerta);

            // Confirma los cambios
            _unitOfWork.Save();
        }

        public void CrearAlerta(string nombreCrypto, decimal valorAlerta, string tipoAlerta)
        {
            //Crear la Alerta en la base de datos
            int idAlerta = _unitOfWork.Alerta.CrearAlerta(nombreCrypto, valorAlerta, tipoAlerta);

            //Crear observador 
            var nuevoObservador = new AlertaPorcentaje(
                    (mensaje, alertaID) => AlertaActivada(mensaje, alertaID), // Acción para mostrar el mensaje
                    (alertaID) => EliminarAlerta(alertaID) // Acción para eliminar el observador
                );

            // Configurar el observador
            nuevoObservador.ConfigurarAlerta(nombreCrypto, valorAlerta, tipoAlerta, idAlerta);

            _observerManager.AgregarObservador(nuevoObservador);

            // Confirma los cambios
            _unitOfWork.Save();
        }

        public void AlertaActivada(string mensaje, int idAlerta)
        {
            MessageBox.Show(mensaje);

            //Elimino observador
            _observerManager.EliminarObservador(idAlerta);

            //Modifico la alerta en la base da datos para agregarle la fecha
            _unitOfWork.Alerta.MarcarActivacionAlerta(idAlerta);

            // Notificar a los suscriptores
            alertaActivada?.Invoke("");

            // Confirma los cambios
            _unitOfWork.Save();
        }


        public void EliminarAlerta(int idAlerta)
        {
            // Elimina la alerta de la base de datos
            _unitOfWork.Alerta.EliminarAlerta(idAlerta);

            // Elimina el observador correspondiente
            _observerManager.EliminarObservador(idAlerta);

            // Confirma los cambios
            _unitOfWork.Save();
        }


        public void CargarObservadores()
        {
            // Usa el repositorio desde el Unit of Work
            var alertasActivas = _unitOfWork.Alerta.ObtenerAlertasActivas();

            foreach (var alerta in alertasActivas)
            {
                //Crear observador 
                var nuevoObservador = new AlertaPorcentaje(
                        (mensaje, alertaID) => AlertaActivada(mensaje, alertaID), // Acción para mostrar el mensaje
                        (alertaID) => EliminarAlerta(alertaID) // Acción para eliminar el observador
                    );

                // Configurar el observador
                nuevoObservador.ConfigurarAlerta(alerta.CryptomonedaID, alerta.CambioPorcentual, alerta.TipoCambio, alerta.AlertaID);

                _observerManager.AgregarObservador(nuevoObservador);
            }
        }

        public List<IAlertaObserver> ObtenerObservadores()
        {
             return _observerManager.ObtenerLista();
        }
    }
}
