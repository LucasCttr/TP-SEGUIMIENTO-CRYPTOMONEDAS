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
        public string cryptoNombre;
        public int? AlertaID;
        public IUnitOfWork _unitOfWork;
        public InicioForm _inicioForm;
        
        //Evento para actualizar la listview de inicio al clickear en guardar
        public event EventHandler GuardarAlerta;
        public AlertaForm(string crypto,int? id, IUnitOfWork unitOfWork, InicioForm inicioForm)
        {
            _unitOfWork = unitOfWork;
            cryptoNombre = crypto;
            AlertaID = id;
            _inicioForm = inicioForm;
            InitializeComponent();
        }

        private void AlertaForm_Load(object sender, EventArgs e)
        {
            //var alerta = _unitOfWork.Alerta.ObtenerUnaAlerta(nombreCrypto);

            //valorPositivo.Text = alerta.ValorPositivo.ToString("F2");
            //valorNegativo.Text = alerta.ValorNegativo.ToString("F2");
            cryptonombre.Text = cryptoNombre;
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            decimal nuevoValorPositivo = Convert.ToDecimal(valorAlerta.Text);  // Convierte el texto a decimal
            string tipo = tipoAlerta.Text;

            if (AlertaID != null)
            {
                _inicioForm._alertaService.ActualizarAlerta(cryptoNombre, nuevoValorPositivo, tipo, AlertaID.Value);
                _inicioForm.CargarAlertasActivas();
            }

            else  _inicioForm._alertaService.CrearAlerta(cryptoNombre, nuevoValorPositivo, tipo);

            // Llama al evento cuando se presiona el botón
            GuardarAlerta?.Invoke(this, EventArgs.Empty);
            this.Close();
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
