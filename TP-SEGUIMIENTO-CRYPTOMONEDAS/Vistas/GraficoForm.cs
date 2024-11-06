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
        private bool isMouseWheelInProgress = false; // Para evitar que el evento se dispare varias veces en una sola rueda

        public GraficoForm(string idCrypto, IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            Crypto = idCrypto;
            _unitOfWork = unitOfWork;
            CargarHistorialCrypto(Crypto, "d1");
            // grafico.Series[0].ToolTip = "#VALY, #VALX"; // Muestra el valor Y (por ejemplo, el precio de la criptomoneda)

            // Asociamos el evento MouseWheel al gráfico
            grafico.MouseWheel += Grafico_MouseWheel;

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
            AjustarZoomY();
        }

        private void Grafico_MouseWheel(object sender, MouseEventArgs e)
        {
            // Solo ejecutamos el zoom si la rueda del mouse está siendo movida
            if (isMouseWheelInProgress) return;
            isMouseWheelInProgress = true;

            try
            {
                var chartArea = grafico.ChartAreas[0];

                // Determina la dirección de la rueda del mouse
                double zoomFactor = (e.Delta > 0) ? 1.0001 : 0.9999; // Hacer zoom in o out

                // Para el eje X (puedes hacerlo también para el eje Y si lo necesitas)
                double newMinX = chartArea.AxisX.ScaleView.ViewMinimum * zoomFactor;
                double newMaxX = chartArea.AxisX.ScaleView.ViewMaximum * zoomFactor;

                // Establecer el nuevo rango de escala del eje X
                chartArea.AxisX.ScaleView.Zoom(newMinX, newMaxX);

                // Si necesitas hacer zoom en el eje Y también, puedes hacer algo similar
                double newMinY = chartArea.AxisY.ScaleView.ViewMinimum * zoomFactor;
                double newMaxY = chartArea.AxisY.ScaleView.ViewMaximum * zoomFactor;

                // Establecer el nuevo rango de escala del eje Y
                chartArea.AxisY.ScaleView.Zoom(newMinY, newMaxY);
            }
            finally
            {
                isMouseWheelInProgress = false;
            }
        }
        private void ResetZoom()
        {
            var chartArea = grafico.ChartAreas[0];

            // Restablecer el zoom de los ejes X e Y
            chartArea.AxisX.ScaleView.ZoomReset();
            chartArea.AxisY.ScaleView.ZoomReset();
        }

        private void AjustarZoomY()  //Se usa en 1 dia, ya que si no queda la funcion muy sobre el borde superior
        {
            var chartArea = grafico.ChartAreas[0];

            // Obtén el rango actual del eje Y
            double minY = chartArea.AxisY.ScaleView.ViewMinimum;
            double maxY = chartArea.AxisY.ScaleView.ViewMaximum;

            // Aumenta el rango para darle espacio adicional al gráfico
            double newMinY = minY - (maxY - minY) * 0.3; // 30% menos en la parte inferior
            double newMaxY = maxY + (maxY - minY) * 0.3; // 30% más en la parte superior

            // Establecer los nuevos rangos
            chartArea.AxisY.ScaleView.Zoom(newMinY, newMaxY);
        }
    }
}
