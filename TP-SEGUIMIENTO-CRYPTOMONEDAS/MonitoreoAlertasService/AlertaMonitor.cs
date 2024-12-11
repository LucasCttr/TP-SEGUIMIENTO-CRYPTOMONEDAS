using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.UntOfWork;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.MonitoreoAlertasService
{
    public class AlertaMonitor
    {
        public event Action<int> alertaActivada; // Evento que se dispara cuando una alerta es activada.
        private readonly List<IAlertaObserver> observadores = new(); // Lista de observadores para las alertas.

        public AlertaMonitor() { }

        // Notifica cambios de tendencia a todos los observadores que corresponden a la criptomoneda especificada.
        public void NotificarCambio(string nombreCrypto, decimal cambio24Hs)
        {
            var copiaObservadores = observadores.ToList();
            foreach (var observador in copiaObservadores)
            {
                if (observador is AlertaObservador alerta && alerta.nombreCrypto == nombreCrypto)
                {
                    alerta.Notificar(cambio24Hs);
                }
            }
        }

        // Actualiza la configuración de una alerta existente.
        public void ActualizarAlerta(string nombreCrypto, decimal valorAlerta, string tipoAlerta, int idAlerta)
        {
            var observadorAModificar = observadores.FirstOrDefault(o => o is AlertaObservador alerta && alerta.nombreCrypto == nombreCrypto);

            if (observadorAModificar != null && observadorAModificar is AlertaObservador alerta)
            {
                alerta.ConfigurarAlerta(nombreCrypto, valorAlerta, tipoAlerta, idAlerta);
            }
        }

        // Crea y agrega un nuevo observador para una alerta.
        public void CrearAlerta(string nombreCrypto, decimal valorAlerta, string tipoAlerta, int idAlerta)
        {
            var nuevoObservador = new AlertaObservador(
                    (mensaje, alertaID) => AlertaActivada(mensaje, alertaID)); // Acción para mostrar el mensaje

            nuevoObservador.ConfigurarAlerta(nombreCrypto, valorAlerta, tipoAlerta, idAlerta);

            observadores.Add(nuevoObservador);
        }

        // Desactiva y elimina un observador cuando una alerta es activada.
        public void AlertaActivada(string mensaje, int idAlerta)
        {
            EliminarObservador(idAlerta);

            // Comunica al InicioForm de la alerta activa para agregarle la fecha actual en la bd, mediante el unitOfWork
            alertaActivada?.Invoke(idAlerta);

            MessageBox.Show(mensaje);
        }

        // Elimina el observador correspondiente al ID de la alerta especificado.
        public void EliminarObservador(int idAlerta)
        {
            var observadorAEliminar = observadores.FirstOrDefault(o => o is AlertaObservador alerta && alerta.idAlerta == idAlerta);
            if (observadorAEliminar != null)
            {
                observadores.Remove(observadorAEliminar);
            }
        }

        // Carga todos los observadores existentes desde una lista de alertas activas.
        public void CargarObservadores(List<AlertaDTO> listaAlertasActivas)
        {
            foreach (var alerta in listaAlertasActivas)
            {
                var nuevoObservador = new AlertaObservador(
                        (mensaje, alertaID) => AlertaActivada(mensaje, alertaID)); // Acción para mostrar el mensaje

                nuevoObservador.ConfigurarAlerta(alerta.CryptomonedaID, alerta.CambioPorcentual, alerta.TipoCambio, alerta.AlertaID);

                observadores.Add(nuevoObservador);
            }
        }

        public List<IAlertaObserver> ObtenerObservadores()
        {
            return observadores;
        }
    }
}