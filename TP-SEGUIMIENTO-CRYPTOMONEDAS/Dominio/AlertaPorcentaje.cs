using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Dominio
{
    public class AlertaPorcentaje : IAlertaObserver
    {
        private readonly Action<string> accionAlerta;
        public string nombreCrypto { get; set; }
        private decimal valorPositivo;
        private decimal valorNegativo;

    public AlertaPorcentaje(Action<string> accion)
        {
            accionAlerta = accion;
        }

        // Configuramos la alerta con los valores de la criptomoneda y los umbrales
        public void ConfigurarAlerta(string nombre, decimal valorPositivo, decimal valorNegativo)
        {
            this.nombreCrypto = nombre;
            this.valorPositivo = valorPositivo;
            this.valorNegativo = valorNegativo;
        }

        public void Notificar(decimal cambio24Hs)
        {
            if (cambio24Hs >= valorPositivo)
            {
                accionAlerta($"🔔 Alerta positiva: {nombreCrypto} ha aumentado un {cambio24Hs:F2}% en las últimas 24 horas.");
                ConfigurarAlerta(nombreCrypto, 0, 0);
            }
            else if (Math.Abs(cambio24Hs) >= valorNegativo)
            {
                accionAlerta($"🔔 Alerta negativa: {nombreCrypto} ha disminuido un {cambio24Hs:F2}% en las últimas 24 horas.");
                ConfigurarAlerta(nombreCrypto, 0, 0);
            }
        }
    }
}
