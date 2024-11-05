using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.UntOfWork;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Vistas
{
    public partial class OpcionesCrypto : Form
    {
        private string idCrypto;
        private IUnitOfWork _unitOfWork;

        public OpcionesCrypto(string nombreCrypto, string IdCrypto, IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            idCrypto = IdCrypto;
            CargarDatos(nombreCrypto, IdCrypto);
            
            
        }


        private void CargarDatos(string nombreCrypto, string idCrypto)
        {
            this.CryptomonedaNombre.Text = nombreCrypto;

            if (_unitOfWork.CryptosFavoritas.VerificarSiEsFavorito(idCrypto) == true)
            {
                AgregarEliminarBoton.Text = "Eliminar";
            }
            else 
            {
                AgregarEliminarBoton.Text = "Agregar";
            }
        }
    }
}
