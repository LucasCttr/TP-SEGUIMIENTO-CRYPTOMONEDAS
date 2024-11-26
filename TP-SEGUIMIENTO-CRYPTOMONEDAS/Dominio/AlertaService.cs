using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.UntOfWork;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Dominio
{
    public class AlertaService
    {
            public event Action<string> AlertaEliminada;

            private readonly IUnitOfWork _unitOfWork;
            private readonly AlertaObserverManager _observerManager;

            public AlertaService(IUnitOfWork unitOfWork, AlertaObserverManager observerManager)
            {
                _unitOfWork = unitOfWork;
                _observerManager = observerManager;
            }

           // public void CargarAlertasActivas()
           // {
           //      // Usa el repositorio desde el Unit of Work
           //     // var alertasActivas = _unitOfWork.Alerta.ObtenerAlertasActivas();

           // // Carga los observadores en memoria
           // _observerManager.CargarObservadores(alertasActivas,
           //(mensaje) => MessageBox.Show(mensaje), // Acción para mostrar el mensaje
           //(nombreCrypto) => EliminarAlerta(nombreCrypto),// Acción para eliminar el observador
           //(nombreCrypto, valor, tipo) => CrearNuevoHistoricoAlerta(nombreCrypto, valor, "Incremento"),
           //(nombreCrypto, valor, tipo) => CrearNuevoHistoricoAlerta(nombreCrypto, valor, "Decremento"));
           // }

           // public void NotificarCambio(string nombreCrypto, decimal cambio24Hs)
           // {
           //     _observerManager.NotificarObservadores(nombreCrypto, cambio24Hs);
           // }

            //public void ActualizarOCrearAlerta(string nombreCrypto, decimal valorPositivo, decimal valorNegativo)
            //{
            //// Actualiza la alerta en la base de datos
            //_unitOfWork.Alerta.GuardarValoresAlerta(nombreCrypto, valorPositivo, valorNegativo);

            //    // Modifica el observador en memoria si existe, si no lo crea   (Es necesario crearlo aca para poder asociarle la accion de EliminarAlerta )
            //    if (_observerManager.ModificarObservador(nombreCrypto, valorPositivo, valorNegativo) == false)
            //{
            //        var nuevoObservador = new AlertaPorcentaje(
            //            (mensaje) => MessageBox.Show(mensaje), // Acción para mostrar el mensaje
            //            (nombreCrypto) => EliminarAlerta(nombreCrypto), // Acción para eliminar el observador
            //            (nombreCrypto, valor, tipo) => CrearNuevoHistoricoAlerta(nombreCrypto, valor, "Incremento"),
            //            (nombreCrypto, valor, tipo) => CrearNuevoHistoricoAlerta(nombreCrypto, valor, "Decremento")
            //        );

            //        // Configurar la nueva alerta
            //        nuevoObservador.ConfigurarAlerta(nombreCrypto, valorPositivo, valorNegativo);

            //        // Agregar el nuevo observador a la lista
            //        _observerManager.AgregarObservador(nuevoObservador);
            //}

            //// Confirma los cambios
            //_unitOfWork.Save();
            //}

            //public void EliminarAlerta(string nombreCrypto)
            //{
            //    // Elimina la alerta de la base de datos
            //    _unitOfWork.Alerta.EliminarAlerta(nombreCrypto);

            //    // Elimina el observador correspondiente
            //    _observerManager.EliminarObservador(nombreCrypto);

            //     // Notificar a los suscriptores
            //    AlertaEliminada?.Invoke(nombreCrypto);

            //    // Confirma los cambios
            //    _unitOfWork.Save();
            //}

            //private void CrearNuevoHistoricoAlerta(string nombreCrpyto, decimal umbralSuperado, string tipo)
            //{
            //    _unitOfWork.Alerta.CrearHistoriaAlerta(nombreCrpyto, umbralSuperado, tipo);

            //    // Confirma los cambios
            //    _unitOfWork.Save();
            //}
    }
}
