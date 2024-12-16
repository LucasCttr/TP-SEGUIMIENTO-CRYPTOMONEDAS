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
            components = new System.ComponentModel.Container();
            MercadoBoton = new Button();
            listaCryptosFavoritas = new ListView();
            label1 = new Label();
            botonOpciones = new Button();
            MiCuentaBoton = new Button();
            listaAlertas = new ListView();
            AlertasBoton = new Button();
            HistorialAlertas = new Button();
            botonModificar = new Button();
            timer = new System.Windows.Forms.Timer(components);
            botonEliminar = new Button();
            SuspendLayout();
            // 
            // MercadoBoton
            // 
            MercadoBoton.Location = new Point(90, 415);
            MercadoBoton.Name = "MercadoBoton";
            MercadoBoton.Size = new Size(65, 23);
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
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 15.75F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 8);
            label1.Name = "label1";
            label1.Size = new Size(94, 30);
            label1.TabIndex = 2;
            label1.Text = "Favoritas";
            // 
            // botonOpciones
            // 
            botonOpciones.Location = new Point(161, 415);
            botonOpciones.Name = "botonOpciones";
            botonOpciones.Size = new Size(66, 23);
            botonOpciones.TabIndex = 3;
            botonOpciones.Text = "Opciones";
            botonOpciones.UseVisualStyleBackColor = true;
            botonOpciones.Click += OpcionesBoton_Click;
            // 
            // MiCuentaBoton
            // 
            MiCuentaBoton.Location = new Point(12, 415);
            MiCuentaBoton.Name = "MiCuentaBoton";
            MiCuentaBoton.Size = new Size(72, 23);
            MiCuentaBoton.TabIndex = 4;
            MiCuentaBoton.Text = "Mi Cuenta";
            MiCuentaBoton.UseVisualStyleBackColor = true;
            MiCuentaBoton.Click += MiCuentaBoton_Click;
            // 
            // listaAlertas
            // 
            listaAlertas.FullRowSelect = true;
            listaAlertas.Location = new Point(308, 41);
            listaAlertas.MultiSelect = false;
            listaAlertas.Name = "listaAlertas";
            listaAlertas.Size = new Size(387, 368);
            listaAlertas.Sorting = SortOrder.Descending;
            listaAlertas.TabIndex = 5;
            listaAlertas.UseCompatibleStateImageBehavior = false;
            // 
            // AlertasBoton
            // 
            AlertasBoton.Location = new Point(308, 415);
            AlertasBoton.Name = "AlertasBoton";
            AlertasBoton.Size = new Size(62, 23);
            AlertasBoton.TabIndex = 6;
            AlertasBoton.Text = "Alertas";
            AlertasBoton.UseVisualStyleBackColor = true;
            AlertasBoton.Click += AlertasBoton_Click;
            // 
            // HistorialAlertas
            // 
            HistorialAlertas.Location = new Point(376, 415);
            HistorialAlertas.Name = "HistorialAlertas";
            HistorialAlertas.Size = new Size(63, 23);
            HistorialAlertas.TabIndex = 7;
            HistorialAlertas.Text = "Historial";
            HistorialAlertas.UseVisualStyleBackColor = true;
            HistorialAlertas.Click += HistorialAlertas_Click;
            // 
            // botonModificar
            // 
            botonModificar.Location = new Point(445, 415);
            botonModificar.Name = "botonModificar";
            botonModificar.Size = new Size(66, 23);
            botonModificar.TabIndex = 8;
            botonModificar.Text = "Modificar";
            botonModificar.UseVisualStyleBackColor = true;
            botonModificar.Click += botonModificar_Click;
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 10000;
            // 
            // botonEliminar
            // 
            botonEliminar.Location = new Point(517, 415);
            botonEliminar.Name = "botonEliminar";
            botonEliminar.Size = new Size(65, 23);
            botonEliminar.TabIndex = 9;
            botonEliminar.Text = "Eliminar";
            botonEliminar.UseVisualStyleBackColor = true;
            botonEliminar.Click += botonEliminar_Click_1;
            // 
            // InicioForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Image.FromFile("Resources/bg.jpeg");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(707, 450);
            Controls.Add(botonEliminar);
            Controls.Add(botonModificar);
            Controls.Add(HistorialAlertas);
            Controls.Add(AlertasBoton);
            Controls.Add(listaAlertas);
            Controls.Add(MiCuentaBoton);
            Controls.Add(botonOpciones);
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
        private Button botonOpciones;
        private Button MiCuentaBoton;
        private ListView listaAlertas;
        private Button AlertasBoton;
        private Button HistorialAlertas;
        private Button botonModificar;
        private System.Windows.Forms.Timer timer;
        private Button botonEliminar;
    }
}