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
    public partial class AlertaForm : Form
    {
        public string cryptoNombre;
        public int? AlertaID;
        public IUnitOfWork _unitOfWork;
        public InicioForm _inicioForm;

        //Evento para actualizar la listview de inicio al clickear en guardar
        public event EventHandler GuardarAlerta;
        public AlertaForm(string crypto, int? id, IUnitOfWork unitOfWork, InicioForm inicioForm)
        {
            _unitOfWork = unitOfWork;
            cryptoNombre = crypto;
            AlertaID = id;
            _inicioForm = inicioForm;
            InitializeComponent();
        }

        private void AlertaForm_Load(object sender, EventArgs e)
        {
            cryptonombre.Text = cryptoNombre;
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            decimal nuevoValorPositivo = Convert.ToDecimal(valorAlerta.Text);  // Convierte el texto a decimal
            string tipo = tipoAlerta.Text;

            if (AlertaID != null)
            {
                //Modificar la alerta en la base de datos
                _inicioForm._unitOfWork.Alerta.ActualizarAlerta(AlertaID.Value, nuevoValorPositivo, tipo);

                //Modificar el observador de la alerta
                _inicioForm._alertaMonitor.ActualizarAlerta(cryptoNombre, nuevoValorPositivo, tipo, AlertaID.Value);
            } 
            else 
            {
                //Crear la Alerta en la base de datos
                int idAlerta = _unitOfWork.Alerta.CrearAlerta(cryptoNombre, nuevoValorPositivo, tipo);

                //Crear el obsevador de la alerta
                _inicioForm._alertaMonitor.CrearAlerta(cryptoNombre, nuevoValorPositivo, tipo, idAlerta);  
            }

            // Llama al evento cuando se presiona el botón
            GuardarAlerta?.Invoke(this, EventArgs.Empty);
            this.Close();
        }

        public void ActualizarForm(decimal valor, string tipo)
        {
            valorAlerta.Text = valor.ToString();
            if (string.Equals(tipo,"Decremento")) { tipoAlerta.SelectedIndex = 1;} else { tipoAlerta.SelectedIndex=0;}
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
