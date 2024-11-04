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
            var cryptos = await _unitOfWork.Usuarios.ObtenerCryptosFavoritas(2);      

            // Limpiar el ListView antes de llenarlo

            
            // Agregar cada criptomoneda al ListView
            foreach (var crypto in cryptos)
            {
                // Obtener los detalles de la criptomoneda mediante su ID
                var DatosCrypto = await _unitOfWork.CryptosFavoritas.BuscarCryptoMedianteId(crypto.CryptoID);

                // Verifica si DatosCrypto no es null
                if (DatosCrypto != null)
                {
                    // Crear un nuevo ListViewItem y agregar las propiedades de la criptomoneda
                    var item = new ListViewItem(DatosCrypto.id); // Nombre de la criptomoneda
                    item.SubItems.Add(DatosCrypto.rank.ToString());
                    item.SubItems.Add(DatosCrypto.symbol);
                    item.SubItems.Add(DatosCrypto.priceUsd.ToString("C2", CultureInfo.CreateSpecificCulture("en-US"))); // Precio en USD, formato de moneda
                    item.SubItems.Add(DatosCrypto.changePercent24Hr.ToString("F2"));
                    item.SubItems.Add(DatosCrypto.marketCapUsd.ToString("F2"));
                    item.SubItems.Add(DatosCrypto.supply.ToString("F2"));
                    CryptosFavoritasLista.Items.Add(item);
                }
            }
        }




        private void InitializeListView()
        {
            CryptosFavoritasLista.View = View.Details;
            CryptosFavoritasLista.Columns.Add("Cryptomoneda", 100);
            CryptosFavoritasLista.Columns.Add("Rank", 60);
            CryptosFavoritasLista.Columns.Add("Simbolo", 70);
            CryptosFavoritasLista.Columns.Add("Precio (USD)", 100);
            CryptosFavoritasLista.Columns.Add("24Hs%", 70);
            CryptosFavoritasLista.Columns.Add("MarketCap", 100);
            CryptosFavoritasLista.Columns.Add("Supply", 100);
        }
    }
}
