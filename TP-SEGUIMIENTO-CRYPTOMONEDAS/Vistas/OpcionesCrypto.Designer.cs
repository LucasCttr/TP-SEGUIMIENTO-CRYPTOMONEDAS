namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Vistas
{
    partial class OpcionesCrypto
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
            AgregarEliminarBoton = new Button();
            GraficoBoton = new Button();
            AlertaBoton = new Button();
            CryptomonedaNombre = new Label();
            SuspendLayout();
            // 
            // AgregarEliminarBoton
            // 
            AgregarEliminarBoton.Location = new Point(16, 63);
            AgregarEliminarBoton.Name = "AgregarEliminarBoton";
            AgregarEliminarBoton.Size = new Size(75, 23);
            AgregarEliminarBoton.TabIndex = 0;
            AgregarEliminarBoton.Text = "AgregarEliminar";
            AgregarEliminarBoton.UseVisualStyleBackColor = true;
            AgregarEliminarBoton.Click += AgregarEliminarBoton_Click;
            // 
            // GraficoBoton
            // 
            GraficoBoton.Location = new Point(98, 63);
            GraficoBoton.Name = "GraficoBoton";
            GraficoBoton.Size = new Size(75, 23);
            GraficoBoton.TabIndex = 1;
            GraficoBoton.Text = "Grafico";
            GraficoBoton.UseVisualStyleBackColor = true;
            GraficoBoton.Click += GraficoBoton_Click;
            // 
            // AlertaBoton
            // 
            AlertaBoton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            AlertaBoton.Location = new Point(179, 63);
            AlertaBoton.Name = "AlertaBoton";
            AlertaBoton.Size = new Size(75, 23);
            AlertaBoton.TabIndex = 2;
            AlertaBoton.Text = "Nueva 🔔";
            AlertaBoton.UseVisualStyleBackColor = true;
            AlertaBoton.Click += AlertaBoton_Click;
            // 
            // CryptomonedaNombre
            // 
            CryptomonedaNombre.AutoSize = true;
            CryptomonedaNombre.Font = new Font("Segoe Fluent Icons", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            CryptomonedaNombre.ForeColor = SystemColors.ControlText;
            CryptomonedaNombre.Location = new Point(52, 20);
            CryptomonedaNombre.Name = "CryptomonedaNombre";
            CryptomonedaNombre.Size = new Size(162, 21);
            CryptomonedaNombre.TabIndex = 3;
            CryptomonedaNombre.Text = "CryptoMonedaNombre";
            // 
            // OpcionesCrypto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(275, 95);
            Controls.Add(CryptomonedaNombre);
            Controls.Add(AlertaBoton);
            Controls.Add(GraficoBoton);
            Controls.Add(AgregarEliminarBoton);
            Name = "OpcionesCrypto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "OpcionesCryptow";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AgregarEliminarBoton;
        private Button GraficoBoton;
        private Button AlertaBoton;
        private Label CryptomonedaNombre;
    }
}