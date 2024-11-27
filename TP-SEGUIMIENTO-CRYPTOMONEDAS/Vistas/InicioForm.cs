using System;
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
            _alertaService.CargarObservadores();

            // Suscribirse al evento para actualizar UI despues de que salte una alerta
            _alertaService.alertaActivada += (notificacion) =>
            {
                // Lógica para actualizar la lista de UI
                CargarHistorial();
            };
        }

        private async void InicioForm_Load(object sender, EventArgs e)
        {
            CargarCryptosFavoritas();
            CargarHistorial();
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
                OpcionesCrypto opcionesForm = new OpcionesCrypto(selectedItem.SubItems[1].Text,selectedItem.SubItems[5].Text, _unitOfWork, this);

                // Suscribirse al evento del formulario intermedio
                opcionesForm.EventoGuardarAlerta += Evento_GuardarAlerta;

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


        public void CargarCryptosFavoritas()
        {
            // Obtener las criptomonedas
            var cryptos = _unitOfWork.Usuarios.ObtenerCryptosFavoritas();

            listaCryptosFavoritas.Items.Clear();

            foreach (var crypto in cryptos)
            {
                // Obtener los detalles de la criptomoneda mediante su ID
                var DatosCrypto = _unitOfWork.CryptosFavoritas.BuscarCryptoMedianteId(crypto.CryptomonedaID);

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
                    else item.SubItems.Add("  "+DatosCrypto.changePercent24Hr.ToString("F2") + " %");
                    item.SubItems.Add(DatosCrypto.id);
                    listaCryptosFavoritas.Items.Add(item);
                }
            }
            listaCryptosFavoritas.Sort();
        }


        public void CargarUnaCryptoAlView(string idCrypto)   //Hacerr un metodo para combinar con l ode arriba.
        {
            var crypto = _unitOfWork.CryptosFavoritas.BuscarCryptoMedianteId(idCrypto);
            // Crear el nuevo ListViewItem con el primer subítem
            var Item = new ListViewItem(crypto.rank.ToString());

            Item.SubItems.Add(crypto.name);
            Item.SubItems.Add(crypto.symbol);
            Item.SubItems.Add(crypto.priceUsd.ToString("C2", CultureInfo.CreateSpecificCulture("en-US"))); // Precio en USD, formato de moneda

            //Para que los numeros no queden desalineados por el signo "-"
            if (crypto.changePercent24Hr.ToString("F2").StartsWith("-"))
                Item.SubItems.Add(crypto.changePercent24Hr.ToString("F2") + " %");
            else Item.SubItems.Add("  " + crypto.changePercent24Hr.ToString("F2") + " %");

            Item.SubItems.Add(crypto.id);
            listaCryptosFavoritas.Items.Add(Item);

            // Mostrar mensaje de éxito
            MessageBox.Show(crypto.name + " agregado a favoritos");
        }

        public void EliminarUnaCryptoDelView(string idCrypto)
        {
            // Suspender redibujado
            listaCryptosFavoritas.BeginUpdate();

            foreach (ListViewItem item in listaCryptosFavoritas.Items)
            {

                if (item.SubItems[5].Text == idCrypto) // Cambia el índice si el ID está en otra columna
                {
                    listaCryptosFavoritas.Items.Remove(item); // Eliminar el item encontrado
                    listaCryptosFavoritas.EndUpdate(); // Reactivar redibujado
                    MessageBox.Show(item.SubItems[1].Text + " eliminado de favoritos");
                    return;
                }
            }

            // Reactivar redibujado en caso de que no se encuentre el ítem
            listaCryptosFavoritas.EndUpdate();
        }


        private void InitializeListView()
        {
            listaCryptosFavoritas.View = View.Details;          //MODIFICAR
            listaCryptosFavoritas.Columns.Add("Rank", 0);
            listaCryptosFavoritas.Columns.Add("Crypto", 100);
            listaCryptosFavoritas.Columns.Add("Simbolo", 0);
            listaCryptosFavoritas.Columns.Add("Precio (USD)", 100);
            listaCryptosFavoritas.Columns.Add("24Hs%", 70);
            listaCryptosFavoritas.Columns.Add("Id", 0);
            botonModificar.Visible = false;
        }

        private void CargarHistorial()
        {
            listaAlertas.Clear();
            listaAlertas.FullRowSelect = false;
          //  var alertasHistorial = _unitOfWork.Alerta.ObtenerAlertasHistorial();
            listaAlertas.View = View.Details;
            listaAlertas.Sort();
            listaAlertas.Columns.Add("Orden", 0);
            listaAlertas.Columns.Add("Fecha", 120);
            listaAlertas.Columns.Add("Crypto", 100);
            listaAlertas.Columns.Add("Valor", 48);
            listaAlertas.Columns.Add("Tipo", 82);

            //foreach (var historial in alertasHistorial)
            //{

            //    var item = new ListViewItem(historial.FechaAlerta.ToString());
            //    item.SubItems.Add(historial.FechaAlerta.ToString());
            //    item.SubItems.Add(historial.CryptoNombre);
            //    item.SubItems.Add(historial.CambioPorcentual.ToString());
            //    item.SubItems.Add(historial.TipoCambio);
            //    listaAlertas.Items.Add(item);
            //}
        }


        public void CargarAlertasActivas()
        {
            listaAlertas.Clear();
            listaAlertas.FullRowSelect = true;
            listaAlertas.View = View.Details;
            listaAlertas.Columns.Add("Activas", 125);
            listaAlertas.Columns.Add("Valor", 95);
            listaAlertas.Columns.Add("Tipo", 85);
            listaAlertas.Columns.Add("Id", 0);

            ActualizarListaAlertasActivas();
        }
        //var alertasActivas = _unitOfWork.Alerta.ObtenerAlertasActivas();
        public void ActualizarListaAlertasActivas()
        {
            listaAlertas.Items.Clear();

            var alertas = _alertaService.ObtenerObservadores();
            
            foreach (var alerta in alertas)
            {
                var item = new ListViewItem(alerta.nombreCrypto);
                item.SubItems.Add(alerta.valorAlerta.ToString("F3"));
                item.SubItems.Add(alerta.tipoAlerta);
                item.SubItems.Add(alerta.idAlerta.ToString()) ;

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
                int subItemValue = Convert.ToInt32(selectedItem.SubItems[3].Text);
                AlertaForm alerta = new AlertaForm(selectedItem.Text, subItemValue, _unitOfWork, this) ;
                // Suscribirse al evento GuardarAlerta
                alerta.GuardarAlerta += Evento_GuardarAlerta;
                alerta.Show();    
            }       
        }

        private void Evento_GuardarAlerta(object sender, EventArgs e)
        {
            CargarAlertasActivas();
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
                    var crypto = await Task.Run(() => _unitOfWork.CryptosFavoritas.BuscarCryptoMedianteId(f.CryptomonedaID));
                    if (crypto == null) continue;
                    // Notificar las alertas si es necesario
                    _alertaService.NotificarCambio(crypto.name, crypto.changePercent24Hr);

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
