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
        public ListViewItem Crypto;
        public IUnitOfWork _unitOfWork;
        private ICryptoState _estadoActual;
        public InicioForm InicioForm;

        public OpcionesCrypto(ListViewItem CryptoSelect, IUnitOfWork unitOfWork, InicioForm inicioForm)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            Crypto = CryptoSelect;
            CargarDatos(Crypto);
            InicioForm = inicioForm;
        }

        private void CargarDatos(ListViewItem Crypto)
        {
            CryptomonedaNombre.Text = Crypto.SubItems[2].Text + "  " + "[" + Crypto.SubItems[3].Text + "]";
            CryptomonedaNombre.AutoSize = false;

            CryptomonedaNombre.TextAlign = ContentAlignment.MiddleCenter;
            if (_unitOfWork.CryptosFavoritas.VerificarSiEsFavorito(Crypto.SubItems[1].Text))
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
            GraficoForm graficoForm = new GraficoForm(Crypto.SubItems[1].Text, _unitOfWork);
            graficoForm.Show();
        }

        private void AlertaBoton_Click(object sender, EventArgs e)
        {
            AlertaForm alertaForm = new AlertaForm(Crypto.SubItems[2].Text, _unitOfWork);
            alertaForm.Show();
        }
    }
}
