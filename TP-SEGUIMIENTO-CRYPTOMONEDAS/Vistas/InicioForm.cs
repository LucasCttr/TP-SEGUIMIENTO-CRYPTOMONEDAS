﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
    public partial class InicioForm : Form
    {
        private IUnitOfWork _unitOfWork;
        public AlertaService _alertaService;


        public InicioForm(IUnitOfWork unitOfWork, AlertaService alertaService)
        {
            InitializeComponent();
            InitializeListView();
            _unitOfWork = unitOfWork;
            _alertaService = alertaService;
            InicializarTimer();
            listaCryptosFavoritas.SelectedIndexChanged += listaCryptosFavoritas_SelectedIndexChanged;
            listaCryptosFavoritas.SelectedIndexChanged += listaAlertasActivas_SelectedIndexChanged;
            listaAlertas.SelectedIndexChanged += listaAlertas_SelectedIndexChanged;

            // Suscribirse al evento para actualizar UI despues de que salte una alerta
            _alertaService.AlertaEliminada += (nombreCrypto) =>
            {
                // Lógica para actualizar la lista de UI
                CargarHistorial();
            };
        }

        private async void InicioForm_Load(object sender, EventArgs e)
        {
            CargarCryptosFavoritas();
            CargarHistorial();
            _alertaService.CargarAlertasActivas();
        }

        private void MercadoBoton_Click(object sender, EventArgs e)
        {
            var MercadoForm = new MercadoForm(_unitOfWork, this); // Cambia esto al nombre de tu formulario principal
            MercadoForm.Show();
        }

        private void OpcionesBoton_Click(object sender, EventArgs e)
        {
            if (listaCryptosFavoritas.SelectedItems.Count > 0)
            {
                // Obtener el ítem seleccionado
                ListViewItem selectedItem = listaCryptosFavoritas.SelectedItems[0];

                // Crear e iniciar el nuevo formulario pasando los datos
                OpcionesCrypto opcionesForm = new OpcionesCrypto(selectedItem, _unitOfWork, this);
                opcionesForm.ShowDialog(); // Usar ShowDialog para abrir como modal, o Show para no modal
            }
        }

        private void AlertasBoton_Click(object sender, EventArgs e)
        {
            CargarAlertasActivas();
        }

        private void HistorialAlertas_Click(object sender, EventArgs e)
        {
            botonModificar.Visible = false;
            listaAlertas.Clear();
            CargarHistorial();
        }


        private void CargarCryptosFavoritas()
        {
            // Obtener las criptomonedas
            var cryptos = _unitOfWork.Usuarios.ObtenerCryptosFavoritas();

            foreach (var crypto in cryptos)
            {
                // Obtener los detalles de la criptomoneda mediante su ID
                var DatosCrypto = _unitOfWork.CryptosFavoritas.BuscarCryptoMedianteId(crypto.CryptoID);

                // Verifica si DatosCrypto no es null
                if (DatosCrypto != null)
                {
                    // Crear un nuevo ListViewItem y agregar las propiedades de la criptomoneda
                    var item = new ListViewItem(DatosCrypto.rank.ToString()); // Nombre de la criptomoneda
                    item.SubItems.Add(DatosCrypto.id);
                    item.SubItems.Add(DatosCrypto.name);
                    item.SubItems.Add(DatosCrypto.symbol);
                    item.SubItems.Add(DatosCrypto.priceUsd.ToString("C2", CultureInfo.CreateSpecificCulture("en-US"))); // Precio en USD, formato de moneda

                    //Para que los numeros no queden desalineados por el signo "-"
                    if (DatosCrypto.changePercent24Hr.ToString("F2").StartsWith("-")) 
                        item.SubItems.Add(DatosCrypto.changePercent24Hr.ToString("F2") + " %");  
                    else item.SubItems.Add("  "+DatosCrypto.changePercent24Hr.ToString("F2") + " %");

                    item.SubItems.Add(DatosCrypto.marketCapUsd.ToString("F2"));
                    item.SubItems.Add(DatosCrypto.supply.ToString("F2"));
                    listaCryptosFavoritas.Items.Add(item);
                }
            }
            listaCryptosFavoritas.Sort();
        }


        public void CargarUnaCryptoAlView(ListViewItem Crypto)
        {
            // Crear el nuevo ListViewItem con el primer subítem
            var Item = new ListViewItem(Crypto.SubItems[0].Text);

            // Iterar sobre los subítems restantes y agregarlos al nuevo Item
            for (int i = 1; i < Crypto.SubItems.Count; i++)
            {
                Item.SubItems.Add(Crypto.SubItems[i]);
            }

            // Añadir el nuevo item a la lista de favoritos
            listaCryptosFavoritas.Items.Add(Item);

            // Mostrar mensaje de éxito
            MessageBox.Show(Crypto.SubItems[2].Text + " agregado a favoritos");
        }

        public void EliminarUnaCryptoDelView(string idCrypto)
        {
            // Buscar el item en el ListView que tenga el ID especificado
            foreach (ListViewItem item in listaCryptosFavoritas.Items)
            {
                if (item.SubItems[1].Text == idCrypto) // Cambia el índice si el ID está en otra columna
                {
                    listaCryptosFavoritas.Items.Remove(item); // Eliminar el item encontrado
                    MessageBox.Show(item.SubItems[2].Text + " eliminado de favoritos");
                    return;
                }
            }
        }


        private void InitializeListView()
        {
            listaCryptosFavoritas.View = View.Details;          //MODIFICAR
            listaCryptosFavoritas.Columns.Add("Rank", 0);
            listaCryptosFavoritas.Columns.Add("Id", 0);
            listaCryptosFavoritas.Columns.Add("Crypto", 100);
            listaCryptosFavoritas.Columns.Add("Simbolo", 0);
            listaCryptosFavoritas.Columns.Add("Precio (USD)", 100);
            listaCryptosFavoritas.Columns.Add("24Hs%", 70);
            listaCryptosFavoritas.Columns.Add("MarketCap", 0);
            listaCryptosFavoritas.Columns.Add("Supply", 0);

            botonModificar.Visible = false;
        }

        private void CargarHistorial()
        {
            listaAlertas.Clear();
            listaAlertas.FullRowSelect = false;
            var alertasHistorial = _unitOfWork.Alerta.ObtenerAlertasHistorial();
            listaAlertas.View = View.Details;
            listaAlertas.Sort();
            listaAlertas.Columns.Add("Orden", 0);
            listaAlertas.Columns.Add("Fecha", 120);
            listaAlertas.Columns.Add("Crypto", 100);
            listaAlertas.Columns.Add("Valor", 48);
            listaAlertas.Columns.Add("Tipo", 82);

            foreach (var historial in alertasHistorial)
            {

                var item = new ListViewItem(historial.FechaAlerta.ToString());
                item.SubItems.Add(historial.FechaAlerta.ToString());
                item.SubItems.Add(historial.CryptoNombre);
                item.SubItems.Add(historial.CambioPorcentual.ToString());
                item.SubItems.Add(historial.TipoCambio);
                listaAlertas.Items.Add(item);
            }
        }


        public void CargarAlertasActivas()
        {
            listaAlertas.Clear();
            listaAlertas.FullRowSelect = true;
            listaAlertas.View = View.Details;
            listaAlertas.Columns.Add("Activas", 125);
            listaAlertas.Columns.Add("Incremento", 100);
            listaAlertas.Columns.Add("Decremento", 80);

            ActualizarListaAlertasActivas();
        }

        public void ActualizarListaAlertasActivas()
        {
            listaAlertas.Items.Clear();
            var alertasActivas = _unitOfWork.Alerta.ObtenerAlertasActivas();
            foreach (var alerta in alertasActivas)
            {
                var item = new ListViewItem(alerta.CryptoNombre);
                if (alerta.ValorPositivo == 0) item.SubItems.Add("    -");
                else item.SubItems.Add(alerta.ValorPositivo.ToString());

                if (alerta.ValorNegativo == 0) item.SubItems.Add("    -");
                else item.SubItems.Add(alerta.ValorNegativo.ToString());

                listaAlertas.Items.Add(item);
            }
        }


        private void listaCryptosFavoritas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listaCryptosFavoritas.SelectedItems.Count > 0)
            {
                listaCryptosFavoritas.Enabled = listaCryptosFavoritas.SelectedItems.Count > 0;
            }
        }

        private void listaAlertasActivas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listaAlertas.SelectedItems.Count > 0)
            {
                listaAlertas.Enabled = listaAlertas.SelectedItems.Count > 0;
            }
        }

        private void botonModificar_Click(object sender, EventArgs e)
        {
            if (listaAlertas.SelectedItems.Count > 0)
            {
                // Obtener el ítem seleccionado
                ListViewItem selectedItem = listaAlertas.SelectedItems[0];
                AlertaForm alerta = new AlertaForm(selectedItem.Text, _unitOfWork, this);
                alerta.Show();    
            }       
        }


        private void listaAlertas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listaAlertas.SelectedItems.Count > 0)
            {
                botonModificar.Visible = true;  // Muestra el botón si hay un ítem seleccionado
            }
            else
            {
                botonModificar.Visible = false;  // Oculta el botón si no hay ítem seleccionado
            }
        }

        private async void InicializarTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 10000; // 10 segundos
            timer.Tick += async (sender, e) => await Timer_TickAsync();
            timer.Start();
        }
        private async Task Timer_TickAsync()
        {
            ActualizarListaFavoritasAsync();
        }


        //Metodo para que cuando la lista se actualice no parpadee
        private async Task ActualizarListaFavoritasAsync()
        {
            try
            {
                // Obtener la lista de criptomonedas favoritas en un hilo separado
                var favoritas = await Task.Run(() => _unitOfWork.Usuarios.ObtenerCryptosFavoritas());

                List<ListViewItem> nuevosItems = new List<ListViewItem>();

                foreach (var f in favoritas)
                {
                    // Obtener la información actualizada del precio y la tendencia
                    var crypto = await Task.Run(() => _unitOfWork.CryptosFavoritas.BuscarCryptoMedianteId(f.CryptoID));
                    if (crypto == null) continue;

                    // Notificar las alertas si es necesario
                    _alertaService.NotificarCambio
                        (crypto.name, crypto.changePercent24Hr);

                    // Crear un nuevo ListViewItem
                    ListViewItem newItem = new ListViewItem(crypto.rank.ToString())
                    {
                        Tag = f // Guardar el objeto para futuras actualizaciones
                    };
                    newItem.SubItems.Add(crypto.id);
                    newItem.SubItems.Add(crypto.name);
                    newItem.SubItems.Add(crypto.symbol);
                    newItem.SubItems.Add(crypto.priceUsd.ToString("C2", CultureInfo.CreateSpecificCulture("en-US")));
                    newItem.SubItems.Add(crypto.changePercent24Hr.ToString("F2") + "%");

                    nuevosItems.Add(newItem);
                }

                // Actualizar la ListView en el hilo de la interfaz de usuario
                listaCryptosFavoritas.Invoke((MethodInvoker)(() =>
                {
                    listaCryptosFavoritas.BeginUpdate();
                    listaCryptosFavoritas.Items.Clear();
                    listaCryptosFavoritas.Items.AddRange(nuevosItems.ToArray());
                    listaCryptosFavoritas.EndUpdate();
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la lista de favoritas: " + ex.Message);
            }
        }
    }

}
