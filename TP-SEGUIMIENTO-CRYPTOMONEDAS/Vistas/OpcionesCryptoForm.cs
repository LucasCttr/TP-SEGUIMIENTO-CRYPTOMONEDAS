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

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Vistas
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

        private void CargarDatos()
        {
            CryptomonedaNombre.Text = cryptoNombre;
            CryptomonedaNombre.AutoSize = false;

            CryptomonedaNombre.TextAlign = ContentAlignment.MiddleCenter;
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

        //Patron estado
        public void CambiarEstado(ICryptoState nuevoEstado)
        {
            _estadoActual = nuevoEstado;
        }

        public void ActualizarBotones(string texto, bool mostrar)
        {
            AgregarEliminarBoton.Text = texto;
            AlertaBoton.Enabled = mostrar;
        }

        public void MostrarBotones()
        {
            GraficoBoton.Visible = true;

        }

        private void AgregarEliminarBoton_Click(object sender, EventArgs e)
        {
            _estadoActual.Handle(this);
        }

        private void GraficoBoton_Click(object sender, EventArgs e)
        {
            GraficoForm graficoForm = new GraficoForm(cryptoId, _unitOfWork);
            graficoForm.Show();
        }

        private void AlertaBoton_Click(object sender, EventArgs e)
        {
            AlertaForm alertaForm = new AlertaForm(cryptoNombre,null ,_unitOfWork);
            // Suscribirse al evento GuardarAlerta del formulario secundario
            alertaForm.GuardarAlerta += FormularioSecundario_GuardarAlerta;
            alertaForm.Show();
        }

        //Evento para actualizar la view del formulario de inicio al darle a guardar en el formulario de alerta.
        private void FormularioSecundario_GuardarAlerta(object sender, FavoritaDTO e)
        {
            // Propagar el evento o invocar el método en el FormularioPrincipal
            // Puedes crear un evento en el FormularioIntermedio para llamar al FormularioPrincipal
            GuardarAlerta?.Invoke(this, e);
            MessageBox.Show(e.CryptoNombre);
        }
    }
}
