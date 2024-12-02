using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.UntOfWork;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;


namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Vistas
{
    public partial class GraficoForm : Form
    {
        private string Crypto;
        IUnitOfWork _unitOfWork;
        
        public GraficoForm(string idCrypto, IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            Crypto = idCrypto;
            _unitOfWork = unitOfWork;
            grafico.ChartAreas[0].AxisX.LabelStyle.Format = "dd-MM";
            CargarHistorialCrypto("d1");
            CargarDetallesCrypto();     

            // Asociamos el evento MouseWheel al gráfico
            grafico.MouseDown += chart1_MouseDown;

        }
        private void CargarHistorialCrypto(string intervalo)
        {
            var datosHistorial = _unitOfWork.CryptosFavoritas.ObtenerHistorialDeUnaCrypto(Crypto,intervalo);
            
            grafico.Series.Clear();
            Series serie = new Series();
            serie.ChartType = SeriesChartType.Line;

            foreach (var punto in datosHistorial)
            {
                serie.Points.AddXY(punto.Fecha, punto.Precio);
            }

            grafico.Series.Add(serie);
            grafico.Series[0].BorderWidth = 2;
            grafico.ChartAreas[0].AxisY.LabelStyle.Format = "$0.00";
            grafico.ChartAreas[0].CursorX.IsUserEnabled = true;
            grafico.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            grafico.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            grafico.ChartAreas[0].CursorY.IsUserEnabled = true;
            grafico.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            grafico.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            grafico.ChartAreas[0].AxisX.ScrollBar.Enabled = false;
            grafico.ChartAreas[0].AxisY.ScrollBar.Enabled = false;
        }

        private void CargarDetallesCrypto()
        {
            listaDetalles.View = View.Details;
            listaDetalles.Columns.Add("Rank", 0);
            listaDetalles.Columns.Add("Crypto", 130);
            listaDetalles.Columns.Add("Simbolo", 100);
            listaDetalles.Columns.Add("Price (USD)", 120);
            listaDetalles.Columns.Add("24Hs%", 100);
            listaDetalles.Columns.Add("Supply",140);
            listaDetalles.Columns.Add("MarketCapUSD",140);
            listaDetalles.Columns.Add("volumeUsd24Hr", 140);
            listaDetalles.Columns.Add("vwap24Hr", 120);
            listaDetalles.Columns.Add("Id", 0);

            var datosCrypto = _unitOfWork.CryptosFavoritas.BuscarCryptoEnMercado(Crypto);

            // Verifica si DatosCrypto no es null
            if (datosCrypto != null)
            {
                // Crear un nuevo ListViewItem y agregar las propiedades de la criptomoneda
                var item = new ListViewItem(datosCrypto.rank.ToString()); // Nombre de la criptomoneda
                item.SubItems.Add(datosCrypto.name);
                item.SubItems.Add(datosCrypto.symbol);
                item.SubItems.Add(datosCrypto.priceUsd.ToString("C2", CultureInfo.CreateSpecificCulture("en-US"))); // Precio en USD, formato de moneda

                //Para que los numeros no queden desalineados por el signo "-"
                if (datosCrypto.changePercent24Hr.ToString("F2").StartsWith("-"))
                    item.SubItems.Add(datosCrypto.changePercent24Hr.ToString("F2") + " %");
                else item.SubItems.Add("  " + datosCrypto.changePercent24Hr.ToString("F2") + " %");
                item.SubItems.Add(Math.Round(datosCrypto.supply, 2).ToString());
                item.SubItems.Add(Math.Round(datosCrypto.marketCapUsd,2).ToString());
                item.SubItems.Add(Math.Round(datosCrypto.volumeUsd24Hr,2).ToString());
                item.SubItems.Add(Math.Round(datosCrypto.vwap24Hr.Value,2).ToString());
                
                listaDetalles.Items.Add(item);
            }
        }

        private void boton12Meses_Click_1(object sender, EventArgs e)
        {
            ResetZoom();
            grafico.Series.Clear();
            grafico.ChartAreas[0].AxisX.LabelStyle.Format = "dd-MM";
            grafico.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Months;  // Intervalo en horas
            grafico.ChartAreas[0].AxisX.Interval = 1;
            CargarHistorialCrypto( "d1");
        }

        private void boton6Meses_Click(object sender, EventArgs e)
        {
            ResetZoom();
            grafico.Series.Clear(); 
            grafico.ChartAreas[0].AxisX.LabelStyle.Format = "dd-MM";
            grafico.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Weeks;  // Intervalo en horas
            grafico.ChartAreas[0].AxisX.Interval = 2;
            CargarHistorialCrypto("h6");
        }

        private void boton1Mes_Click_1(object sender, EventArgs e)
        {   
            ResetZoom();
            grafico.Series.Clear();
            grafico.ChartAreas[0].AxisX.LabelStyle.Format = "dd-MM";
            grafico.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;  // Intervalo en horas
            grafico.ChartAreas[0].AxisX.Interval = 2;
            CargarHistorialCrypto("h1");
        }

        private void Boton1Dia_Click_1(object sender, EventArgs e)
        {
            ResetZoom();
            grafico.Series.Clear();
            grafico.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm";
            grafico.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Hours;  // Intervalo en horas
            grafico.ChartAreas[0].AxisX.Interval = 1;
            CargarHistorialCrypto("m1");
        }

        private void chart1_MouseDown(object sender, MouseEventArgs e)
        {
            // Verificar si el clic fue con el botón derecho del mouse
            if (e.Button == MouseButtons.Right)
            {
                grafico.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                grafico.ChartAreas[0].AxisY.ScaleView.ZoomReset();
                grafico.Invalidate();
            }
        }
        private void ResetZoom()
        {
            var chartArea = grafico.ChartAreas[0];

            // Restablecer el zoom de los ejes X e Y
            chartArea.AxisX.ScaleView.ZoomReset();
            chartArea.AxisY.ScaleView.ZoomReset();
        }
    }
}
