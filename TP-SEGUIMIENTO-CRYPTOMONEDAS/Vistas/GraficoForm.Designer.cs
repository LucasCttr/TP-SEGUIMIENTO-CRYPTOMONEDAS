namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Vistas
{
    partial class GraficoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            grafico = new System.Windows.Forms.DataVisualization.Charting.Chart();
            boton6Meses = new Button();
            boton12Meses = new Button();
            boton1Mes = new Button();
            Boton1Dia = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)grafico).BeginInit();
            SuspendLayout();
            // 
            // grafico
            // 
            chartArea1.Name = "ChartArea1";
            grafico.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            grafico.Legends.Add(legend1);
            grafico.Location = new Point(-29, 41);
            grafico.Name = "grafico";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            grafico.Series.Add(series1);
            grafico.Size = new Size(948, 486);
            grafico.TabIndex = 0;
            grafico.Text = "CryptoNombre";
            // 
            // boton6Meses
            // 
            boton6Meses.Location = new Point(93, 12);
            boton6Meses.Name = "boton6Meses";
            boton6Meses.Size = new Size(75, 23);
            boton6Meses.TabIndex = 1;
            boton6Meses.Text = "6 Meses";
            boton6Meses.UseVisualStyleBackColor = true;
            boton6Meses.Click += boton6Meses_Click;
            // 
            // boton12Meses
            // 
            boton12Meses.Location = new Point(12, 12);
            boton12Meses.Name = "boton12Meses";
            boton12Meses.Size = new Size(75, 23);
            boton12Meses.TabIndex = 2;
            boton12Meses.Text = "12 Meses";
            boton12Meses.UseVisualStyleBackColor = true;
            boton12Meses.Click += boton12Meses_Click_1;
            // 
            // boton1Mes
            // 
            boton1Mes.Location = new Point(174, 12);
            boton1Mes.Name = "boton1Mes";
            boton1Mes.Size = new Size(75, 23);
            boton1Mes.TabIndex = 3;
            boton1Mes.Text = "1 Mes";
            boton1Mes.UseVisualStyleBackColor = true;
            boton1Mes.Click += boton1Mes_Click_1;
            // 
            // Boton1Dia
            // 
            Boton1Dia.Location = new Point(255, 12);
            Boton1Dia.Name = "Boton1Dia";
            Boton1Dia.Size = new Size(75, 23);
            Boton1Dia.TabIndex = 4;
            Boton1Dia.Text = "1 Dia";
            Boton1Dia.UseVisualStyleBackColor = true;
            Boton1Dia.Click += Boton1Dia_Click_1;
            // 
            // GraficoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(799, 538);
            Controls.Add(Boton1Dia);
            Controls.Add(boton1Mes);
            Controls.Add(boton12Meses);
            Controls.Add(boton6Meses);
            Controls.Add(grafico);
            Name = "GraficoForm";
            Text = "GraficoForm";
            ((System.ComponentModel.ISupportInitialize)grafico).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart grafico;
        private Button boton6Meses;
        private Button boton12Meses;
        private Button boton1Mes;
        private Button Boton1Dia;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}