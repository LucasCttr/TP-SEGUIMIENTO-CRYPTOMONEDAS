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
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.MonitoreoAlertasService;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.UntOfWork;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.Vistas.OpcionesCrypto;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Vistas
{
    public partial class InicioForm : Form
    {
        public IUnitOfWork _unitOfWork;
        public AlertaMonitor _alertaMonitor;
        public event EventHandler<FavoritaDTO> GuardarAlerta = delegate { };

        public InicioForm(IUnitOfWork unitOfWork, AlertaMonitor alertaService)
        {
            InitializeComponent(); // Inicializa los componentes de la interfaz
            InicializarListaCryptosFavoritas(); // Configura la lista de criptomonedas favoritas
            InicializarTimer(); // Inicializa el temporizador para actualizaciones periódicas
            _unitOfWork = unitOfWork; // Almacena la unidad de trabajo
            _alertaMonitor = alertaService; // Almacena el monitor de alertas

            // Suscribir eventos a los manejadores correspondientes
            listaCryptosFavoritas.SelectedIndexChanged += listaCryptosFavoritas_SelectedIndexChanged;
            listaAlertas.SelectedIndexChanged += listaAlertas_SelectedIndexChanged;
            listaCryptosFavoritas.DoubleClick += listaCryptosFavoritas_DoubleClick;

            // Cargar observadores de alertas al iniciar la aplicación
            _alertaMonitor.CargarObservadores(_unitOfWork.Alerta.ObtenerAlertasActivas());


            // Suscribirse al evento para actualizar UI después de que salte una alerta
            _alertaMonitor.alertaActivada += (idAlerta) =>
            {
                _unitOfWork.Alerta.MarcarActivacionAlerta(idAlerta);
                CargarHistorialAlertas();
            };
        }

        private async void InicioForm_Load(object sender, EventArgs e)
        {
            CargarCryptosFavoritas(); // Cargar criptomonedas favoritas
            CargarHistorialAlertas(); // Cargar historial de alertas
            botonOpciones.Visible = false; // Ocultar el botón de opciones al inicio
        }

        private void MercadoBoton_Click(object sender, EventArgs e)
        {
            // Abre el formulario de mercado
            var mercadoForm = new MercadoForm(_unitOfWork, this);
            mercadoForm.Show();
        }

        private void MiCuentaBoton_Click(object sender, EventArgs e)
        {
            // Abre el formulario de cuenta del usuario
            var cuentaForm = new MiCuentaForm(_unitOfWork);
            cuentaForm.ShowDialog();
        }

        private void OpcionesBoton_Click(object sender, EventArgs e)
        {
            if (listaCryptosFavoritas.SelectedItems.Count > 0)
            {
                // Obtener el ítem seleccionado
                ListViewItem selectedItem = listaCryptosFavoritas.SelectedItems[0];

                // Crear e iniciar el nuevo formulario pasando los datos
                OpcionesCryptoForm opcionesForm = new OpcionesCryptoForm(selectedItem.SubItems[1].Text, selectedItem.SubItems[5].Text, _unitOfWork, this);

                // Suscribirse al evento del formulario intermedio para actualizar la lista de favoritos
                opcionesForm.GuardarAlerta += Evento_GuardarAlerta;

                opcionesForm.ShowDialog(); // Mostrar el formulario modally
            }
        }

        //Carga el view de las alertas activas actualmente
        private void AlertasBoton_Click(object sender, EventArgs e)
        {
            botonEliminar.Visible = false;
            botonModificar.Visible = false;
            CargarAlertasActivas();
        }

        // Carga el view de alertas con el historial de las que se activaron en los ultimos 7 dias
        private void HistorialAlertas_Click(object sender, EventArgs e)
        {
            listaAlertas.Sort();
            botonModificar.Visible = false;
            botonEliminar.Visible = false;
            listaAlertas.Clear();
            CargarHistorialAlertas();
        }


        private void botonModificar_Click(object sender, EventArgs e)
        {
            if (listaAlertas.SelectedItems.Count > 0)
            {
                // Obtener el ítem seleccionado
                ListViewItem selectedItem = listaAlertas.SelectedItems[0];
                int subItemValue = Convert.ToInt32(selectedItem.SubItems[3].Text);
                AlertaForm alertaForm = new AlertaForm(selectedItem.Text, subItemValue, _unitOfWork);
                // alertaForm.GuardarAlerta += ManejarGuardarAlerta; // Suscripción al evento
                // Suscribirse al evento GuardarAlerta
                alertaForm.GuardarAlerta += (sender, args) =>
                {
                    // Actualizar la lista en InicioForm
                    if (args.AlertaID != null)
                    {
                        _unitOfWork.Alerta.ActualizarAlerta(args.AlertaID.Value, args.NuevoValor, args.Tipo);
                        _alertaMonitor.ActualizarAlerta(args.CryptoNombre, args.NuevoValor, args.Tipo, args.AlertaID.Value);
                    }

                    CargarAlertasActivas();
                };
                alertaForm.ActualizarForm(Convert.ToDecimal(selectedItem.SubItems[1].Text), selectedItem.SubItems[2].Text);
                alertaForm.Show();
            }
        }

        private void botonEliminar_Click_1(object sender, EventArgs e)
        {
            if (listaAlertas.SelectedItems.Count > 0)
            {
                // Obtener el ítem seleccionado
                ListViewItem alertaSeleccionada = listaAlertas.SelectedItems[0];
                int idAlerta = Convert.ToInt32(alertaSeleccionada.SubItems[3].Text);

                //Eliminar observador de la alerta
                _alertaMonitor.EliminarObservador(idAlerta);

                // Elimina la alerta de la base de datos
                _unitOfWork.Alerta.EliminarAlerta(idAlerta);
            }
            CargarAlertasActivas();
        }


        public void CargarCryptosFavoritas() //Integrar con actualizarlistafavoritas
        {
            // Obtener las criptomonedas
            var cryptos = _unitOfWork.Usuarios.ObtenerCryptosFavoritas();

            listaCryptosFavoritas.Items.Clear();

            foreach (var crypto in cryptos)
            {
                // Obtener los detalles de la criptomoneda mediante su ID
                var DatosCrypto = _unitOfWork.CryptosFavoritas.BuscarCryptoEnMercado(crypto.CryptomonedaID);

                // Verifica si DatosCrypto no es null
                if (DatosCrypto != null)
                {
                    // Crear un nuevo ListViewItem y agregar las propiedades de la criptomoneda
                    var item = new ListViewItem(DatosCrypto.rank.ToString()); // Nombre de la criptomoneda
                    item.SubItems.Add(DatosCrypto.name);
                    item.SubItems.Add(DatosCrypto.symbol);
                    item.SubItems.Add(DatosCrypto.priceUsd.ToString("C2", CultureInfo.CreateSpecificCulture("en-US"))); // Precio en USD, formato de moneda

                    //Para que los numeros no queden desalineados por el signo "-"
                    if (DatosCrypto.changePercent24Hr.ToString("F2").StartsWith("-"))
                        item.SubItems.Add(DatosCrypto.changePercent24Hr.ToString("F2") + " %");
                    else item.SubItems.Add("  " + DatosCrypto.changePercent24Hr.ToString("F2") + " %");
                    item.SubItems.Add(DatosCrypto.id);
                    listaCryptosFavoritas.Items.Add(item);
                }
            }
            listaCryptosFavoritas.Sort();
        }


        private void InicializarListaCryptosFavoritas()
        {
            // Configuración de la vista de la lista de criptos favoritas
            listaCryptosFavoritas.View = View.Details;
            listaCryptosFavoritas.Columns.Add("Rank", 0);
            listaCryptosFavoritas.Columns.Add("Crypto", 100);
            listaCryptosFavoritas.Columns.Add("Simbolo", 0);
            listaCryptosFavoritas.Columns.Add("Precio (USD)", 100);
            listaCryptosFavoritas.Columns.Add("24Hs%", 70);
            listaCryptosFavoritas.Columns.Add("Id", 0);

            botonEliminar.Visible = false;
            botonModificar.Visible = false;
        }

        private void CargarHistorialAlertas()
        {
            listaAlertas.Clear();
            listaAlertas.FullRowSelect = false;

            // Obtener las alertas de historial
            var alertasHistorial = _unitOfWork.Alerta.ObtenerAlertasHistorial();

            listaAlertas.View = View.Details;
            listaAlertas.Sort();
            listaAlertas.Columns.Add("Orden", 0);
            listaAlertas.Columns.Add("Fecha", 130);
            listaAlertas.Columns.Add("Crypto", 90);
            listaAlertas.Columns.Add("Valor", 60);
            listaAlertas.Columns.Add("Tipo", 79);

            foreach (var historial in alertasHistorial)
            {
                // Cargo la fecha activación 2 veces para el ordenamiento
                var item = new ListViewItem(historial.FechaActivasion.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                item.SubItems.Add(historial.FechaActivasion.Value.ToString("dd-MM-yyyy / HH:mm:ss"));
                item.SubItems.Add(historial.CryptomonedaID);
                item.SubItems.Add(historial.CambioPorcentual.ToString("F3"));
                item.SubItems.Add(historial.TipoCambio);
                listaAlertas.Items.Add(item);
            }
        }


        public void CargarAlertasActivas()
        {
            listaAlertas.Clear();
            listaAlertas.FullRowSelect = true;
            listaAlertas.View = View.Details;

            // Configuración de las columnas de la lista de alertas
            listaAlertas.Columns.Add("Activas", 125);
            listaAlertas.Columns.Add("Valor", 95);
            listaAlertas.Columns.Add("Tipo", 85);
            listaAlertas.Columns.Add("Id", 0);

            listaAlertas.Sort();
            listaAlertas.Sorting = SortOrder.Ascending;

            // Obtener las alertas activas
            var alertas = _alertaMonitor.ObtenerObservadores();

            foreach (var alerta in alertas)
            {
                var item = new ListViewItem(alerta.nombreCrypto);
                item.SubItems.Add(alerta.valorAlerta.ToString("F3"));
                item.SubItems.Add(alerta.tipoAlerta);
                item.SubItems.Add(alerta.idAlerta.ToString());

                listaAlertas.Items.Add(item);
            }
        }


        private void listaCryptosFavoritas_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Mostrar u ocultar el botón de opciones dependiendo de si hay una criptomoneda seleccionada
            botonOpciones.Visible = listaCryptosFavoritas.SelectedItems.Count > 0;
        }

        private void Evento_GuardarAlerta(object sender, FavoritaDTO e)
        {
            _alertaMonitor.CrearAlerta(e.CryptoNombre, e.NuevoValor, e.Tipo, e.AlertaID.Value);
            CargarAlertasActivas();
        }

        private void listaAlertas_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Mostrar u ocultar los botones de modificar y eliminar dependiendo de si hay una alerta seleccionada
            bool alertaSeleccionada = listaAlertas.SelectedItems.Count > 0;
            botonModificar.Visible = alertaSeleccionada;
            botonEliminar.Visible = alertaSeleccionada;
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


        public async Task ActualizarListaFavoritasAsync()
        {
            try
            {
                // Obtener la lista de criptomonedas favoritas en un hilo separado
                var favoritas = await Task.Run(() => _unitOfWork.Usuarios.ObtenerCryptosFavoritas());

                List<ListViewItem> nuevosItems = new List<ListViewItem>();

                foreach (var f in favoritas)
                {
                    // Obtener la información actualizada del precio y la tendencia
                    var crypto = await Task.Run(() => _unitOfWork.CryptosFavoritas.BuscarCryptoEnMercado(f.CryptomonedaID));
                    if (crypto == null) continue;

                    // Notificar las alertas si es necesario
                    _alertaMonitor.NotificarCambio(crypto.name, crypto.changePercent24Hr);

                    // Crear un nuevo ListViewItem
                    ListViewItem newItem = new ListViewItem(crypto.rank.ToString())
                    {
                        Tag = f // Guardar el objeto para futuras actualizaciones
                    };
                    newItem.SubItems.Add(crypto.name);
                    newItem.SubItems.Add(crypto.symbol);
                    newItem.SubItems.Add(crypto.priceUsd.ToString("C2", CultureInfo.CreateSpecificCulture("en-US")));
                    newItem.SubItems.Add(crypto.changePercent24Hr.ToString("F2") + "%");
                    newItem.SubItems.Add(crypto.id);
                    nuevosItems.Add(newItem);
                }

                // Actualizar la ListView en el hilo de la interfaz de usuario
                listaCryptosFavoritas.Invoke((MethodInvoker)(() =>
                {
                    listaCryptosFavoritas.BeginUpdate(); // Iniciar actualización de la lista para evitar parpadeos
                    listaCryptosFavoritas.Items.Clear(); // Limpiar la lista existente
                    listaCryptosFavoritas.Items.AddRange(nuevosItems.ToArray()); // Agregar los nuevos items
                    listaCryptosFavoritas.EndUpdate(); // Finalizar actualización de la lista
                }));
            }
            catch (Exception ex)
            {
                // Mostrar un mensaje de error si ocurre una excepción
                MessageBox.Show("Error al actualizar la lista de favoritas: " + ex.Message);
            }
        }

        private void listaCryptosFavoritas_DoubleClick(object sender, EventArgs e)
        {
            OpcionesBoton_Click(sender, e);
        }
    }
}
