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
        public string nombreCrypto;
        public IUnitOfWork _unitOfWork;
        public InicioForm _inicioForm;
        public AlertaForm(string crypto, IUnitOfWork unitOfWork, InicioForm inicioForm)
        {
            _unitOfWork = unitOfWork;
            nombreCrypto = crypto;
            _inicioForm = inicioForm;
            InitializeComponent();
        }

        private void AlertaForm_Load(object sender, EventArgs e)
        {
            var alerta = _unitOfWork.Alerta.ObtenerUnaAlerta(nombreCrypto);

            valorPositivo.Text = alerta.ValorPositivo.ToString("F2");
            valorNegativo.Text = alerta.ValorNegativo.ToString("F2");
            cryptonombre.Text = nombreCrypto;
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            decimal nuevoValorPositivo = Convert.ToDecimal(valorPositivo.Text);  // Convierte el texto a decimal
            decimal nuevoValorNegativo = Convert.ToDecimal(valorNegativo.Text);  // Convierte el texto a decimal

            _inicioForm._alertaService.ActualizarOCrearAlerta(nombreCrypto, nuevoValorPositivo, nuevoValorNegativo);
            _inicioForm.ActualizarListaAlertasActivas();
            this.Close();
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
