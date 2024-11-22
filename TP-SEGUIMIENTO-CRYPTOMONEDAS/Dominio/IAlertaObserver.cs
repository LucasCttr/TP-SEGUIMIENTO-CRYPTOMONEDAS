using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Dominio
{
    public interface IAlertaObserver
    {
        string nombreCrypto { get; }  // Propiedad que quieres referenciar
        void Notificar(decimal Cambio24Hs);
       // void EliminarAlerta(string nombre);
        void ConfigurarAlerta(string nombre, decimal valorPositivo, decimal valorNegativo);

    }
}
