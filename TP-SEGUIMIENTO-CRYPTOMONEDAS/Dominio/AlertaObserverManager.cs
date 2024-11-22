using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Dominio
{
    internal class AlertaObserverManager
    {
        private readonly List<IAlertaObserver> observadores = new();

        // Método para agregar un observador
        public void AgregarObservador(IAlertaObserver observador)
        {
            observadores.Add(observador);
        }

        // Método para eliminar un observador
        public void EliminarObservador(string nombreCrypto)
        {
            var observadorAEliminar = observadores.FirstOrDefault(o => o is AlertaPorcentaje alerta && alerta.nombreCrypto == nombreCrypto);
            if (observadorAEliminar != null)
            {
                observadores.Remove(observadorAEliminar);
            }
        }

        // Método para modificar un observador existente
        public void ModificarObservador(string nombreCrypto, decimal valorPositivo, decimal valorNegativo)
        {
            var observadorAModificar = observadores.FirstOrDefault(o => o is AlertaPorcentaje alerta && alerta.nombreCrypto == nombreCrypto);
            if (observadorAModificar is AlertaPorcentaje alertaPorcentaje)
            {
                alertaPorcentaje.ConfigurarAlerta(nombreCrypto, valorPositivo, valorNegativo);
            }
        }

        // Método para notificar a un observador específico
        public void NotificarObservadores(string nombreCrypto, decimal cambio24Hs)
        {
            foreach (var observador in observadores)
            {
                if (observador is AlertaPorcentaje alerta && alerta.nombreCrypto == nombreCrypto)
                {
                    alerta.Notificar(cambio24Hs);
                }
            }
        }

        // Método para cargar observadores desde un repositorio
        public void CargarObservadores(IEnumerable<UsuarioCryptoDTO> alertasActivas, Action<string> accionAlerta)
        {
            foreach (var alerta in alertasActivas)
            {
                var observador = new AlertaPorcentaje(accionAlerta);
                observador.ConfigurarAlerta(alerta.CryptoNombre, alerta.ValorPositivo, alerta.ValorNegativo);
                AgregarObservador(observador);
            }
        }
    }
}
