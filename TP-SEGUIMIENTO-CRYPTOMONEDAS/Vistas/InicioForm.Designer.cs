namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Vistas
{
    partial class InicioForm
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
            MercadoBoton = new Button();
            listaCryptosFavoritas = new ListView();
            label1 = new Label();
            OpcionesBoton = new Button();
            MiCuentaBoton = new Button();
            listaAlertas = new ListView();
            AlertasBoton = new Button();
            HistorialAlertas = new Button();
            botonModificar = new Button();
            SuspendLayout();
            // 
            // MercadoBoton
            // 
            MercadoBoton.Location = new Point(12, 415);
            MercadoBoton.Name = "MercadoBoton";
            MercadoBoton.Size = new Size(75, 23);
            MercadoBoton.TabIndex = 0;
            MercadoBoton.Text = "Mercado";
            MercadoBoton.UseVisualStyleBackColor = true;
            MercadoBoton.Click += MercadoBoton_Click;
            // 
            // listaCryptosFavoritas
            // 
            listaCryptosFavoritas.FullRowSelect = true;
            listaCryptosFavoritas.Location = new Point(12, 41);
            listaCryptosFavoritas.MultiSelect = false;
            listaCryptosFavoritas.Name = "listaCryptosFavoritas";
            listaCryptosFavoritas.Size = new Size(274, 368);
            listaCryptosFavoritas.Sorting = SortOrder.Ascending;
            listaCryptosFavoritas.TabIndex = 1;
            listaCryptosFavoritas.UseCompatibleStateImageBehavior = false;
            listaCryptosFavoritas.View = View.Details;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 23);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 2;
            label1.Text = "inicio";
            // 
            // OpcionesBoton
            // 
            OpcionesBoton.Location = new Point(93, 415);
            OpcionesBoton.Name = "OpcionesBoton";
            OpcionesBoton.Size = new Size(75, 23);
            OpcionesBoton.TabIndex = 3;
            OpcionesBoton.Text = "Opciones";
            OpcionesBoton.UseVisualStyleBackColor = true;
            OpcionesBoton.Click += OpcionesBoton_Click;
            // 
            // MiCuentaBoton
            // 
            MiCuentaBoton.Location = new Point(174, 415);
            MiCuentaBoton.Name = "MiCuentaBoton";
            MiCuentaBoton.Size = new Size(75, 23);
            MiCuentaBoton.TabIndex = 4;
            MiCuentaBoton.Text = "Mi Cuenta";
            MiCuentaBoton.UseVisualStyleBackColor = true;
            // 
            // listaAlertas
            // 
            listaAlertas.FullRowSelect = true;
            listaAlertas.Location = new Point(308, 41);
            listaAlertas.Name = "listaAlertas";
            listaAlertas.Size = new Size(325, 368);
            listaAlertas.Sorting = SortOrder.Descending;
            listaAlertas.TabIndex = 5;
            listaAlertas.UseCompatibleStateImageBehavior = false;
            // 
            // AlertasBoton
            // 
            AlertasBoton.Location = new Point(308, 415);
            AlertasBoton.Name = "AlertasBoton";
            AlertasBoton.Size = new Size(75, 23);
            AlertasBoton.TabIndex = 6;
            AlertasBoton.Text = "Alertas";
            AlertasBoton.UseVisualStyleBackColor = true;
            AlertasBoton.Click += AlertasBoton_Click;
            // 
            // HistorialAlertas
            // 
            HistorialAlertas.Location = new Point(389, 415);
            HistorialAlertas.Name = "HistorialAlertas";
            HistorialAlertas.Size = new Size(75, 23);
            HistorialAlertas.TabIndex = 7;
            HistorialAlertas.Text = "Historial";
            HistorialAlertas.UseVisualStyleBackColor = true;
            HistorialAlertas.Click += HistorialAlertas_Click;
            // 
            // botonModificar
            // 
            botonModificar.Location = new Point(470, 415);
            botonModificar.Name = "botonModificar";
            botonModificar.Size = new Size(75, 23);
            botonModificar.TabIndex = 8;
            botonModificar.Text = "Modificar";
            botonModificar.UseVisualStyleBackColor = true;
            botonModificar.Click += botonModificar_Click;
            // 
            // InicioForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(645, 450);
            Controls.Add(botonModificar);
            Controls.Add(HistorialAlertas);
            Controls.Add(AlertasBoton);
            Controls.Add(listaAlertas);
            Controls.Add(MiCuentaBoton);
            Controls.Add(OpcionesBoton);
            Controls.Add(label1);
            Controls.Add(listaCryptosFavoritas);
            Controls.Add(MercadoBoton);
            Name = "InicioForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "InicioForm";
            Load += InicioForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button MercadoBoton;
        private ListView listaCryptosFavoritas;
        private Label label1;
        private Button OpcionesBoton;
        private Button MiCuentaBoton;
        private ListView listaAlertas;
        private Button AlertasBoton;
        private Button HistorialAlertas;
        private Button botonModificar;
    }
}