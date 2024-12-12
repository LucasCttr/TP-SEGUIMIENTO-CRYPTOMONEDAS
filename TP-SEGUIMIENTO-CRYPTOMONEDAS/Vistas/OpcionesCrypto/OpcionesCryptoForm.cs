using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.UntOfWork;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Vistas.OpcionesCrypto
{
    public partial class OpcionesCryptoForm : Form
    {
        public string cryptoNombre;
        public string cryptoId;
        public IUnitOfWork _unitOfWork;
        private ICryptoState _estadoActual;
        public InicioForm InicioForm;
        public event EventHandler<FavoritaDTO> GuardarAlerta;

        public OpcionesCryptoForm(string nombreCrypto, string idCrypto, IUnitOfWork unitOfWork, InicioForm inicioForm)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            cryptoNombre = nombreCrypto;
            cryptoId = idCrypto;
            CargarDatos();
            InicioForm = inicioForm;
        }

        // Carga el Form con el nombre y estado correspondiente de la cryptomoneda
        private void CargarDatos()
        {
            CryptomonedaNombre.Text = cryptoNombre;
            CryptomonedaNombre.AutoSize = false;
            CryptomonedaNombre.TextAlign = ContentAlignment.MiddleCenter;

            // Verificar si la criptomoneda es favorita
            if (_unitOfWork.CryptosFavoritas.VerificarSiEsFavorito(cryptoId))
            {
                CambiarEstado(new EliminarState());  // Asigna el estado inicial a Eliminar
                ActualizarBotones("Eliminar", true);
            }
            else
            {
                CambiarEstado(new AgregarState());  // Asigna el estado inicial a Agregar
                ActualizarBotones("Agregar", false);
            }
        }

        // Cambia el estado actual del OpcionesCryptoForm
        public void CambiarEstado(ICryptoState nuevoEstado)
        {
            _estadoActual = nuevoEstado;
        }

        // Actualiza los textos y habilitaciones de los botones
        public void ActualizarBotones(string texto, bool mostrar)
        {
            AgregarEliminarBoton.Text = texto;
            AlertaBoton.Enabled = mostrar;
        }

        // Muestra los botones adicionales
        public void MostrarBotones()
        {
            GraficoBoton.Visible = true;
        }

        // Maneja el evento de clic en el botón de agregar/eliminar
        private void AgregarEliminarBoton_Click(object sender, EventArgs e)
        {
            _estadoActual.Handle(this);
        }

        // Muestra el gráfico de la criptomoneda
        private void GraficoBoton_Click(object sender, EventArgs e)
        {
            GraficoForm graficoForm = new GraficoForm(cryptoId, _unitOfWork);
            graficoForm.Show();
        }

        // AlertaBoton_Click: Muestra el formulario de alertas para la criptomoneda
        private void AlertaBoton_Click(object sender, EventArgs e)
        {
            AlertaForm alertaForm = new AlertaForm(cryptoNombre, null, _unitOfWork);
            alertaForm.GuardarAlerta += FormularioSecundario_GuardarAlerta; // Suscribirse al evento GuardarAlerta del formulario secundario
            alertaForm.Show();
        }

        // Evento FormularioSecundario_GuardarAlerta: Notifica el cambio de alerta al formulario principal
        private void FormularioSecundario_GuardarAlerta(object sender, FavoritaDTO e)
        {
            // Propagar el evento al formulario de inicio
            GuardarAlerta?.Invoke(this, e);
        }
    }
}