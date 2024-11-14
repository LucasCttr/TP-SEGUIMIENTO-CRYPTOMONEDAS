using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs
{
    public class AlertaDTO    //Eliminar El usuario id y id?, y llevar eso a una clase nueva de Alerta con todos estos datos.
    {
        public int Id { get; set; }
        public int UsuarioID { get; set; }
        public string CryptoID { get; set; }
        public decimal CambioPorcentual {  get; set; }
        public DateTime FechaAlerta { get; set; }
        public string TipoCambio { get; set; }

        public string CryptoNombre { get; set; }

    }
}

