using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.UntOfWork;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Dominio
{
    public class AlertaMonitor
    {
        public event Action<int> alertaActivada;
        private readonly List<IAlertaObserver> observadores = new();

        public AlertaMonitor()
        {
        }

        public void NotificarCambio(string nombreCrypto, decimal cambio24Hs)
        {
            //Notifico cambios de tendencia
            var copiaObservadores = observadores.ToList();
            foreach (var observador in copiaObservadores)
            {
                if (observador is AlertaPorcentaje alerta && alerta.nombreCrypto == nombreCrypto)
                {
                    alerta.Notificar(cambio24Hs);
                }
            }
        }

        public void ActualizarAlerta(string nombreCrypto, decimal valorAlerta, string tipoAlerta, int idAlerta)
        {
            // Buscar si ya existe un observador asociado a la criptomoneda
            var observadorAModificar = observadores.FirstOrDefault(o => o is AlertaPorcentaje alerta && alerta.nombreCrypto == nombreCrypto);

            if (observadorAModificar != null)
            {
                // Si existe, modificar su configuración
                if (observadorAModificar is AlertaPorcentaje alerta)
                {
                    alerta.ConfigurarAlerta(nombreCrypto, valorAlerta, tipoAlerta, idAlerta);
                }
            }
        }

        public void CrearAlerta(string nombreCrypto, decimal valorAlerta, string tipoAlerta, int idAlerta)
        {
            //Crear observador 
            var nuevoObservador = new AlertaPorcentaje(
                    (mensaje, alertaID) => AlertaActivada(mensaje, alertaID)); // Acción para mostrar el mensaje

            // Configurar el observador
            nuevoObservador.ConfigurarAlerta(nombreCrypto, valorAlerta, tipoAlerta, idAlerta);

            observadores.Add(nuevoObservador);
        }

        public void AlertaActivada(string mensaje, int idAlerta)
        {
            //Elimino observador
            EliminarObservador(idAlerta);

            // Notificar a los suscriptores
            alertaActivada?.Invoke(idAlerta);

            MessageBox.Show(mensaje);
        }


        public void EliminarObservador(int idAlerta)
        {
            // Elimina el observador correspondiente
            var observadorAEliminar = observadores.FirstOrDefault(o => o is AlertaPorcentaje alerta && alerta.idAlerta == idAlerta);
            if (observadorAEliminar != null)
            {
                observadores.Remove(observadorAEliminar);
            }
        }


        public void CargarObservadores(List<DTOs.AlertaDTO> listaAlertasActivas)
        {
            foreach (var alerta in listaAlertasActivas)
            {
                //Crear observador 
                var nuevoObservador = new AlertaPorcentaje(
                        (mensaje, alertaID) => AlertaActivada(mensaje, alertaID)); // Acción para mostrar el mensaje

                // Configurar el observador
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
