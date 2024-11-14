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

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Vistas
{
    public partial class AlertaForm : Form
    {
        public ListViewItem Crypto;
        public IUnitOfWork _unitOfWork;
        public AlertaForm(ListViewItem crypto, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            Crypto = crypto;
            InitializeComponent();
        }

        private void AlertaForm_Load(object sender, EventArgs e)
        {
            var alerta = _unitOfWork.Alerta.ObtenerUnaAlerta(Crypto);

            valorPositivo.Text = alerta.ValorPositivo.ToString("F2");
            valorNegativo.Text = alerta.ValorNegativo.ToString("F2");
            cryptonombre.Text = Crypto.SubItems[1].Text;
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            decimal nuevoValorPositivo = Convert.ToDecimal(valorPositivo.Text);  // Convierte el texto a decimal
            decimal nuevoValorNegativo = Convert.ToDecimal(valorNegativo.Text);  // Convierte el texto a decimal

            _unitOfWork.Alerta.GuardarValoresAlerta(Crypto, nuevoValorPositivo, nuevoValorNegativo);
            this.Close();
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
