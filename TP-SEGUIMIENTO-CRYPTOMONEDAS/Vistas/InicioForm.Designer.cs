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
            CryptosFavoritasLista = new ListView();
            label1 = new Label();
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
            // CryptosFavoritasLista
            // 
            CryptosFavoritasLista.Location = new Point(12, 41);
            CryptosFavoritasLista.Name = "CryptosFavoritasLista";
            CryptosFavoritasLista.Size = new Size(776, 368);
            CryptosFavoritasLista.TabIndex = 1;
            CryptosFavoritasLista.UseCompatibleStateImageBehavior = false;
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
            // InicioForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(CryptosFavoritasLista);
            Controls.Add(MercadoBoton);
            Name = "InicioForm";
            Text = "InicioForm";
            Load += InicioForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button MercadoBoton;
        private ListView CryptosFavoritasLista;
        private Label label1;
    }
}