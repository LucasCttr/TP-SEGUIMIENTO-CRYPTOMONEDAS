using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.UntOfWork;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Vistas
{
    public partial class InicioForm : Form
    {
        private IUnitOfWork _unitOfWork;
        public InicioForm(IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            InitializeListView();
            _unitOfWork = unitOfWork;
        }

        private async void InicioForm_Load(object sender, EventArgs e)
        {

            await CargarCryptosFavoritas();
        }

        private void MercadoBoton_Click(object sender, EventArgs e)
        {
            var MercadoForm = new MercadoForm(_unitOfWork); // Cambia esto al nombre de tu formulario principal
            MercadoForm.Show();
        }

        private async Task CargarCryptosFavoritas()
        {

            // Obtener las criptomonedas
            var cryptos = await _unitOfWork.Usuarios.ObtenerCryptosFavoritas(1);

            // Limpiar el ListView antes de llenarlo
            CryptosFavoritasLista.Items.Clear();
            
            // Agregar cada criptomoneda al ListView
            foreach (var crypto in cryptos)
            {
                var item = new ListViewItem(crypto.UsuarioID.ToString());
                item.SubItems.Add(crypto.CryptoID.ToString()); ;
                
                CryptosFavoritasLista.Items.Add(item);
            }
        }



        private void InitializeListView()
        {
            CryptosFavoritasLista.View = View.Details;
            CryptosFavoritasLista.Columns.Add("idUsuario", 100);
            CryptosFavoritasLista.Columns.Add("Crypto", 60);
        }
    }
}
