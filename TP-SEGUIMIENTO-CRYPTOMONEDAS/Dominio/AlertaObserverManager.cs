using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Dominio
{
    public class AlertaObserverManager
    {
        private readonly List<IAlertaObserver> observadores = new();

        //Este componente manejará exclusivamente la lógica relacionada con los observadores en memoria, dejando al AlertaRepository el trabajo de interactuar con la base de datos.

        // Método para agregar un observador
        public void AgregarObservador(IAlertaObserver observador)
        {
            observadores.Add(observador);
        }

        // Método para eliminar un observador
        public void EliminarObservador(int idCrypto)
        {
            var observadorAEliminar = observadores.FirstOrDefault(o => o is AlertaPorcentaje alerta && alerta.idAlerta == idCrypto);
            if (observadorAEliminar != null)
            {
                observadores.Remove(observadorAEliminar);
            }
        }

        // Método para modificar un observador existente
        public void ModificarObservador(string nombreCrypto, decimal valorAlerta, string tipoAlerta, int idAlerta)
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


        // Método para notificar a un observador específico
        public void NotificarObservadores(string nombreCrypto, decimal cambio24Hs)
        {
            var copiaObservadores = observadores.ToList();
            foreach (var observador in copiaObservadores)
            {
                if (observador is AlertaPorcentaje alerta && alerta.nombreCrypto == nombreCrypto)
                {
                    alerta.Notificar(cambio24Hs);
                }
            }
        }

        public List<IAlertaObserver> ObtenerLista()
        {
            return observadores;
        }
    }
}
