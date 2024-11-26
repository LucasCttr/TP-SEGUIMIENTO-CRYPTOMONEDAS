using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Repository
{
    public interface IAlertaRepository
    {
      // List<AlertaDTO> ObtenerAlertasHistorial();
        //UsuarioCryptoDTO ObtenerUnaAlerta(string nombreCrypto);
       // void GuardarValoresAlerta(string nombreCrypto, decimal valorPositivo, decimal valorNegativo);
       // void EliminarAlerta(string nombreCrypto);
        void CrearHistoriaAlerta(string nombreCrypto, decimal umbralSuperado, string tipo);
        //List<UsuarioCryptoDTO> ObtenerAlertasActivas();
    }
}
