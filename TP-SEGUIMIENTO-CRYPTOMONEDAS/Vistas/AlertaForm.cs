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
using TP_SEGUIMIENTO_CRYPTOMONEDAS.Controllers;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Vistas
{
    public partial class AlertaForm : Form
    {
        public string iCryptoNombre { get; set; }
        public int? iAlertaID { get; private set; }  //Si es null, la alerta no existe en la DB. Si tiene valor, si existe.

        private AlertaController _alertaController;
        private APIController _APIController;
        private UsuarioController _usuarioController;

        // Evento para notificar al exterior
        public event EventHandler<FavoritaDTO> GuardarAlerta;

        public AlertaForm(string crypto, int? id, AlertaController alertaController, APIController cryptosFavoritasController, UsuarioController usuarioController)
        {
            _alertaController = alertaController;
            _APIController = cryptosFavoritasController;
            _usuarioController = usuarioController;

            iCryptoNombre = crypto;
            iAlertaID = id;
            InitializeComponent();
        }

        private void AlertaForm_Load(object sender, EventArgs e)
        {
            cryptonombre.Text = iCryptoNombre;
            cryptonombre.Left = ((this.ClientSize.Width - cryptonombre.Width) / 2) + 2;   //Ubicar  el nombre en el medio del form

            // Se abre el form con los valores 0 e incremento seleccionados si es que no se modifico antes de abrirlo
            if (valorAlerta.Text == "")
            {
                ActualizarForm(0, "Incremento");
            }
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            decimal nuevoValorPositivo = Convert.ToDecimal(valorAlerta.Text);
            string tipo = tipoAlerta.Text;

            if (iAlertaID != null) // Si es distinto de null, la alerta ya existe y se la busca en la DB para modificarla. Si es null, entonces no existe y se la crea en la DB
            {
                // Modificar la alerta en la base de datos
                _alertaController.ActualizarAlerta(iAlertaID.Value, nuevoValorPositivo, tipo);
            }
            else
            {
                // Crear la alerta en la base de datos y devuelve la id de la misma para actulizarla en la clase actual
                int idAlerta = _alertaController.CrearAlertaYObtenerID(iCryptoNombre, nuevoValorPositivo, tipo);
                iAlertaID = idAlerta; // Actualizar el ID para esta instancia
            }

            // Invocar el evento para notificar al Inicio y que este cree o modifique un observador para la alerta actual.
            GuardarAlerta?.Invoke(this, new FavoritaDTO
            {
                CryptoNombre = iCryptoNombre,
                AlertaID = iAlertaID,
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

        private void botonCancelar_Click_1(object sender, EventArgs e)
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
