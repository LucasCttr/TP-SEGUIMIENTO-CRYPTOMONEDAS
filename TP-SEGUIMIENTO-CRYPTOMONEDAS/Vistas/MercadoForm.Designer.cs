namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Vistas
{
    partial class MercadoForm
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
            CryptosLista = new ListView();
            OpcionesBoton = new Button();
            Mercado = new Label();
            SuspendLayout();
            // 
            // CryptosLista
            // 
            CryptosLista.FullRowSelect = true;
            CryptosLista.Location = new Point(12, 44);
            CryptosLista.MultiSelect = false;
            CryptosLista.Name = "CryptosLista";
            CryptosLista.Size = new Size(776, 356);
            CryptosLista.TabIndex = 0;
            CryptosLista.UseCompatibleStateImageBehavior = false;
            CryptosLista.View = View.Details;
            // 
            // OpcionesBoton
            // 
            OpcionesBoton.Location = new Point(12, 406);
            OpcionesBoton.Name = "OpcionesBoton";
            OpcionesBoton.Size = new Size(75, 23);
            OpcionesBoton.TabIndex = 1;
            OpcionesBoton.Text = "Opciones";
            OpcionesBoton.UseVisualStyleBackColor = true;
            OpcionesBoton.Click += OpcionesBoton_Click;
            // 
            // Mercado
            // 
            Mercado.AutoSize = true;
            Mercado.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            Mercado.Location = new Point(12, 9);
            Mercado.Name = "Mercado";
            Mercado.Size = new Size(108, 32);
            Mercado.TabIndex = 2;
            Mercado.Text = "Mercado";
            // 
            // MercadoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 439);
            Controls.Add(Mercado);
            Controls.Add(OpcionesBoton);
            Controls.Add(CryptosLista);
            Name = "MercadoForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MercadoForm";
            Load += MercadoForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView CryptosLista;
        private Button OpcionesBoton;
        private Label Mercado;
    }
}