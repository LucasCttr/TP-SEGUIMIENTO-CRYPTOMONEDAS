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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.Vistas.OpcionesCrypto;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.Controllers;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Vistas
{
    public partial class MercadoForm : Form
    {
        private AlertaController _alertaController;
        private CryptosFavoritasController _cryptosFavoritasController;
        private UsuarioController _usuarioController;
        private InicioForm _inicioForm;

        public MercadoForm(AlertaController alertaController, CryptosFavoritasController cryptosFavoritasController, UsuarioController usuarioController, InicioForm inicioForm)
        {
            _alertaController = alertaController;
            _usuarioController = usuarioController;
            _cryptosFavoritasController = cryptosFavoritasController;

            InitializeComponent(); // Inicializa los componentes del formulario
            InitializeListView(); // Inicializa la vista de la lista de criptomonedas
            CryptosLista.SelectedIndexChanged += listView1_SelectedIndexChanged; // Evento cuando se selecciona un ítem en la lista
            CryptosLista.DoubleClick += CryptosLista_DoubleClick; // Evento de doble clic para abrir opciones
            OpcionesBoton.Enabled = false; // Desactiva el botón de opciones por defecto
            _inicioForm = inicioForm;
            CargarMercado(); // Carga las criptomonedas en el ListView    
        }

        // Carga las criptomonedas en el ListView
        private async Task CargarMercado()
        {
            // Obtener las criptomonedas favoritas desde el repositorio API
            var cryptos = await _cryptosFavoritasController.ObtenerMercadoAPI();
            this.Invoke(() =>
            {
                // Limpiar la lista antes de cargar los nuevos datos
                CryptosLista.Items.Clear();

                // Añadir cada criptomoneda al ListView
                foreach (var crypto in cryptos)
                {
                    var item = new ListViewItem(crypto.rank.ToString());
                    item.SubItems.Add(crypto.id.ToString());
                    item.SubItems.Add(crypto.name);
                    item.SubItems.Add(crypto.symbol);
                    item.SubItems.Add(crypto.priceUsd.ToString("C2", CultureInfo.CreateSpecificCulture("en-US"))); // Formato de precio en USD
                    item.SubItems.Add(crypto.changePercent24Hr.ToString("F2") + " %"); // Porcentaje de cambio en 24 horas
                    item.SubItems.Add(crypto.marketCapUsd.ToString("F2")); // Capitalización del mercado
                    item.SubItems.Add(crypto.supply.ToString("F2")); // Suministro
                    CryptosLista.Items.Add(item);
                }
            });

            
        }

        // Inicializa la vista del ListView
        private void InitializeListView()
        {
            CryptosLista.View = View.Details;
            CryptosLista.Columns.Add("Rank", 40);
            CryptosLista.Columns.Add("Id", 0);
            CryptosLista.Columns.Add("Nombre", 150);
            CryptosLista.Columns.Add("Simbolo", 100);
            CryptosLista.Columns.Add("Precio (USD)", 110);
            CryptosLista.Columns.Add("24Hs%", 100);
            CryptosLista.Columns.Add("MarketCap", 130);
            CryptosLista.Columns.Add("Supply", 125);
        }

        // Evento que se activa cuando cambia la selección en el ListView
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OpcionesBoton.Enabled = CryptosLista.SelectedItems.Count > 0; // Habilita el botón de opciones si hay al menos un item seleccionado
        }

        // Evento que se activa cuando se hace doble clic en un item del ListView
        private void OpcionesBoton_Click(object sender, EventArgs e)
        {
            if (CryptosLista.SelectedItems.Count > 0)
            {
                // Obtener el ítem seleccionado
                ListViewItem selectedItem = CryptosLista.SelectedItems[0];

                // Crear una nueva instancia del formulario de opciones pasando los datos del item seleccionado
                OpcionesCryptoForm opcionesForm = new OpcionesCryptoForm(selectedItem.SubItems[2].Text, selectedItem.SubItems[1].Text, _alertaController, _cryptosFavoritasController, _usuarioController, _inicioForm);
                opcionesForm.Show(); // Mostrar el formulario de opciones
            }
        }

        // Evento que se activa cuando se hace doble clic en el ListView
        private void CryptosLista_DoubleClick(object sender, EventArgs e)
        {
            OpcionesBoton_Click(sender, e); // Llama al método de clic en opciones
        }
    }
}
