using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.Dominio;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.UntOfWork;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Vistas
{
    public partial class OpcionesCrypto : Form
    {
        public string Crypto;
        public IUnitOfWork _unitOfWork;
        private ICryptoState _estadoActual;
        public InicioForm InicioForm;

        public OpcionesCrypto(string nombreCrypto, IUnitOfWork unitOfWork, InicioForm inicioForm)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            Crypto = nombreCrypto;
            CargarDatos();
            InicioForm = inicioForm;
        }

        private void CargarDatos()
        {
            CryptomonedaNombre.Text = Crypto + "  " + "[" + Crypto + "]";
            CryptomonedaNombre.AutoSize = false;

            CryptomonedaNombre.TextAlign = ContentAlignment.MiddleCenter;
            if (_unitOfWork.CryptosFavoritas.VerificarSiEsFavorito(Crypto))
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
            GraficoForm graficoForm = new GraficoForm(Crypto, _unitOfWork);
            graficoForm.Show();
        }

        private void AlertaBoton_Click(object sender, EventArgs e)
        {
            AlertaForm alertaForm = new AlertaForm(Crypto, _unitOfWork, InicioForm);
            alertaForm.Show();
        }
    }
}
