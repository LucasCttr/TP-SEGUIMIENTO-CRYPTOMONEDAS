using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.MonitoreoAlertasService
{
    public interface IAlertaObserver
    {
        string nombreCrypto { get; }  
        int idAlerta { get; }
        decimal valorAlerta { get; }
        string tipoAlerta { get; }

        void ConfigurarAlerta(string nombre, decimal valor, string tipo, int idAlerta);
    }
}
