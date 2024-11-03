using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.Data;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.Repository;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.UntOfWork;
using System.Globalization;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Vistas
{
    public partial class MercadoForm : Form
    {
        private IUnitOfWork _unitOfWork;
        public MercadoForm(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            InitializeComponent();
            InitializeListView();
        }

        private async void MercadoForm_Load(object sender, EventArgs e)
        {
            await CargarCryptos();

        }

        private async Task CargarCryptos()
        {

            // Obtener las criptomonedas
            var cryptos = await _unitOfWork.CryptosFavoritas.MostrarCryptos();

            // Limpiar el ListView antes de llenarlo
            CryptosLista.Items.Clear();

            // Agregar cada criptomoneda al ListView
            foreach (var crypto in cryptos)
            {
                var item = new ListViewItem(crypto.name);
                item.SubItems.Add(crypto.rank.ToString());
                item.SubItems.Add(crypto.symbol); 
                item.SubItems.Add(crypto.priceUsd.ToString("C2", CultureInfo.CreateSpecificCulture("en-US"))); // Precio en USD, formato de moneda
                item.SubItems.Add(crypto.changePercent24Hr.ToString("F2")) ;
                item.SubItems.Add(crypto.marketCapUsd.ToString("F2"));
                item.SubItems.Add(crypto.supply.ToString("F2"));
                CryptosLista.Items.Add(item);
            }
        }

        private void InitializeListView()
        {
            CryptosLista.View = View.Details;
            CryptosLista.Columns.Add("Nombre", 100);
            CryptosLista.Columns.Add("Rank", 60);
            CryptosLista.Columns.Add("Simbolo", 70);
            CryptosLista.Columns.Add("Precio (USD)", 100);
            CryptosLista.Columns.Add("24Hs%", 70);
            CryptosLista.Columns.Add("MarketCap", 100);
            CryptosLista.Columns.Add("Supply", 100);
        }
    }
}
