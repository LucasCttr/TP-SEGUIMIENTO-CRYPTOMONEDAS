using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.UntOfWork;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Controllers
{
    public class AlertaController
    {
        private readonly IUnitOfWork _unitOfWork;

        public AlertaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void ActualizarAlerta(int idAlerta, decimal valorAlerta, string tipoAlerta)
        {
            _unitOfWork.Alerta.ActualizarAlerta(idAlerta, valorAlerta, tipoAlerta);
        }

        public void MarcarActivacionAlerta(int idAlerta)
        {
            _unitOfWork.Alerta.MarcarActivacionAlerta(idAlerta);
        }

        public void EliminarAlerta(int idAlerta)
        {
            _unitOfWork.Alerta.EliminarAlertaBD(idAlerta);
        }

        public List<AlertaDTO> ObtenerAlertasHistorial()
        {
            return _unitOfWork.Alerta.ObtenerAlertasHistorialBD();
        }

        public List<AlertaDTO> ObtenerAlertasActivas()
        {
            return _unitOfWork.Alerta.ObtenerAlertasActivas();
        }
    }
}
