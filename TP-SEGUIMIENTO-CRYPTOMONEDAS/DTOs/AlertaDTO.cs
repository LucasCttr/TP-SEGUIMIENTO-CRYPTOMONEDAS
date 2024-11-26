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
                              //El DbContext actualmente se basa en esto, es decir, las tablas de la bd tienen que coincidir con estas propiedades.
                              // Por lo que en realidad deberia de convertir esto al dominio, es decir, a clases como Alerta, UsuarioCrypto, etc. y usar el DTO para lo demas mensajes.
    {
        public int Id { get; set; }
        public int UsuarioID { get; set; }
        public decimal CambioPorcentual {  get; set; }
        public DateTime FechaAlerta { get; set; }
        public string TipoCambio { get; set; }
        public string CryptoNombre { get; set; }

    }
}

