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
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Vistas
{
    public partial class AlertaForm : Form
    {
        public string CryptoNombre { get; set; }
        public int? AlertaID { get; private set; }
        private IUnitOfWork _unitOfWork;

        // Evento para notificar al exterior
        public event EventHandler<FavoritaDTO> GuardarAlerta;

        public AlertaForm(string crypto, int? id, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            CryptoNombre = crypto;
            AlertaID = id;
            InitializeComponent();
        }

        private void AlertaForm_Load(object sender, EventArgs e)
        {
            cryptonombre.Text = CryptoNombre;
            cryptonombre.Left = ((this.ClientSize.Width - cryptonombre.Width) / 2) +2;
            tipoAlerta.SelectedIndex = 0;
            valorAlerta.Text = "0"; 
            
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            decimal nuevoValorPositivo = Convert.ToDecimal(valorAlerta.Text);
            string tipo = tipoAlerta.Text;

            if (AlertaID != null)
            {
                // Modificar la alerta en la base de datos
                _unitOfWork.Alerta.ActualizarAlerta(AlertaID.Value, nuevoValorPositivo, tipo);
            }
            else
            {
                // Crear la alerta en la base de datos
                int idAlerta = _unitOfWork.Alerta.CrearAlerta(CryptoNombre, nuevoValorPositivo, tipo);
                AlertaID = idAlerta; // Actualizar el ID para esta instancia
            }

            // Invocar el evento para notificar
            GuardarAlerta?.Invoke(this, new FavoritaDTO
            {
                CryptoNombre = CryptoNombre,
                AlertaID = AlertaID,
                NuevoValor = nuevoValorPositivo,
                Tipo = tipo
            });

            this.Close();
        }

        public void ActualizarForm(decimal valor, string tipo)
        {
            valorAlerta.Text = valor.ToString();
            tipoAlerta.SelectedIndex = string.Equals(tipo, "Decremento") ? 1 : 0;
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    // Clase para encapsular los datos del evento
    public class FavoritaDTO : EventArgs
    {
        public string CryptoNombre { get; set; }
        public int? AlertaID { get; set; }
        public decimal NuevoValor { get; set; }
        public string Tipo { get; set; }
    }
}
