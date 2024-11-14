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
            CargarHistorialCrypto(Crypto, "d1");
            // grafico.Series[0].ToolTip = "#VALY, #VALX"; // Muestra el valor Y (por ejemplo, el precio de la criptomoneda)

            // Asociamos el evento MouseWheel al gráfico
            grafico.MouseDown += chart1_MouseDown;

        }
        private void CargarHistorialCrypto(string idCrypto, string intervalo)
        {
            var datosHistorial = _unitOfWork.CryptosFavoritas.ObtenerHistorialDeCrypto(Crypto, intervalo);


            grafico.Series.Clear();
            Series serie = new Series();
            serie.ChartType = SeriesChartType.Line;

            foreach (var punto in datosHistorial)
            {
                serie.Points.AddXY(punto.Fecha, punto.Precio);
            }

            grafico.Series.Add(serie);
            grafico.Series[0].BorderWidth = 2;
            grafico.ChartAreas[0].AxisX.LabelStyle.Format = "dd-MM";
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

        private void boton12Meses_Click_1(object sender, EventArgs e)
        {
            ResetZoom();
            grafico.Series.Clear();
            CargarHistorialCrypto(Crypto, "d1");
        }

        private void boton6Meses_Click(object sender, EventArgs e)
        {
            ResetZoom();
            grafico.Series.Clear();
            CargarHistorialCrypto(Crypto, "h6");
        }

        private void boton1Mes_Click_1(object sender, EventArgs e)
        {   
            ResetZoom();
            grafico.Series.Clear();
            CargarHistorialCrypto(Crypto, "h1");
        }

        private void Boton1Dia_Click_1(object sender, EventArgs e)
        {
            ResetZoom();
            grafico.Series.Clear();
            CargarHistorialCrypto(Crypto, "m1");
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
