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
            CryptosFavoritasLista.SelectedIndexChanged += listView1_SelectedIndexChanged;
        }

        private async void InicioForm_Load(object sender, EventArgs e)
        {
            CargarCryptosFavoritas();
            CargarAlertas();
        }

        private void MercadoBoton_Click(object sender, EventArgs e)
        {
            var MercadoForm = new MercadoForm(_unitOfWork, this); // Cambia esto al nombre de tu formulario principal
            MercadoForm.Show();
        }

        private void CargarCryptosFavoritas()
        {
            // Obtener las criptomonedas
            var cryptos = _unitOfWork.Usuarios.ObtenerCryptosFavoritas();

            // Agregar cada criptomoneda al ListView
            foreach (var crypto in cryptos)
            {
                // Obtener los detalles de la criptomoneda mediante su ID
                var DatosCrypto = _unitOfWork.CryptosFavoritas.BuscarCryptoMedianteId(crypto.CryptoID);

                // Verifica si DatosCrypto no es null
                if (DatosCrypto != null)
                {
                    // Crear un nuevo ListViewItem y agregar las propiedades de la criptomoneda
                    var item = new ListViewItem(DatosCrypto.id); // Nombre de la criptomoneda
                    item.SubItems.Add(DatosCrypto.name);
                    item.SubItems.Add(DatosCrypto.rank.ToString());
                    item.SubItems.Add(DatosCrypto.symbol);
                    item.SubItems.Add(DatosCrypto.priceUsd.ToString("C2", CultureInfo.CreateSpecificCulture("en-US"))); // Precio en USD, formato de moneda
                    item.SubItems.Add(DatosCrypto.changePercent24Hr.ToString("F2") + " %");
                    item.SubItems.Add(DatosCrypto.marketCapUsd.ToString("F2"));
                    item.SubItems.Add(DatosCrypto.supply.ToString("F2"));
                    CryptosFavoritasLista.Items.Add(item);
                }
            }
        }



        public void CargarUnaCryptoAlView(ListViewItem Crypto)      //IMPLEMENTAR ESTO EN EL METODO DE ARRIBA
        {
            var Item = new ListViewItem(Crypto.SubItems[0].Text);
            Item.SubItems.Add(Crypto.SubItems[1]);
            Item.SubItems.Add(Crypto.SubItems[2]);
            Item.SubItems.Add(Crypto.SubItems[3]);
            Item.SubItems.Add(Crypto.SubItems[4]); // Precio en USD, formato de moneda
            Item.SubItems.Add(Crypto.SubItems[5]);
            Item.SubItems.Add(Crypto.SubItems[6]);
            Item.SubItems.Add(Crypto.SubItems[7]);
            CryptosFavoritasLista.Items.Add(Item);
            // Mensaje de éxito
            MessageBox.Show(Crypto.SubItems[1].Text + " agregado a favoritos");
        }

        public void EliminarUnaCryptoDelView(string idCrypto)
        {
            // Buscar el item en el ListView que tenga el ID especificado
            foreach (ListViewItem item in CryptosFavoritasLista.Items)
            {
                if (item.SubItems[0].Text == idCrypto) // Cambia el índice si el ID está en otra columna
                {
                    CryptosFavoritasLista.Items.Remove(item); // Eliminar el item encontrado
                    MessageBox.Show(item.SubItems[1].Text + " eliminado de favoritos");
                    return;
                }
            }
        }

        private void CargarAlertas()
        {
            // Obtener las alertas
            var cryptos = _unitOfWork.Alerta.ObtenerAlertas();
        }

        private void OpcionesBoton_Click(object sender, EventArgs e)
        {
            if (CryptosFavoritasLista.SelectedItems.Count > 0)
            {
                // Obtener el ítem seleccionado
                ListViewItem selectedItem = CryptosFavoritasLista.SelectedItems[0];

                // Crear e iniciar el nuevo formulario pasando los datos
                OpcionesCrypto opcionesForm = new OpcionesCrypto(selectedItem, _unitOfWork, this);
                opcionesForm.ShowDialog(); // Usar ShowDialog para abrir como modal, o Show para no modal
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CryptosFavoritasLista.SelectedItems.Count > 0)
            {
                CryptosFavoritasLista.Enabled = CryptosFavoritasLista.SelectedItems.Count > 0;
            }
        }

        private void InitializeListView()
        {
            CryptosFavoritasLista.View = View.Details;
            CryptosFavoritasLista.Columns.Add("Id", 0);
            CryptosFavoritasLista.Columns.Add("Crypto", 100);
            CryptosFavoritasLista.Columns.Add("Rank", 0);
            CryptosFavoritasLista.Columns.Add("Simbolo", 0);
            CryptosFavoritasLista.Columns.Add("Precio (USD)", 100);
            CryptosFavoritasLista.Columns.Add("24Hs%", 70);
            CryptosFavoritasLista.Columns.Add("MarketCap", 0);
            CryptosFavoritasLista.Columns.Add("Supply", 0);
        }
    }
}
