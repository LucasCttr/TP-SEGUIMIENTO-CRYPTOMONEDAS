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
        List<AlertaDTO> ObtenerAlertasHistorialBD();
        void ActualizarAlerta(int idCrypto, decimal valorPositivo, string tipo);
        void EliminarAlertaBD(int idAlerta);
        int CrearAlerta(string nombreCrypto, decimal umbralSuperado, string tipo);
        void MarcarActivacionAlerta(int idAlerta);
        List<AlertaDTO> ObtenerAlertasActivas();
    }
}
