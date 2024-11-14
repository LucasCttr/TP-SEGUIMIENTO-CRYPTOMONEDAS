namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Vistas
{
    partial class AlertaForm
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
            valorPositivo = new TextBox();
            valorNegativo = new TextBox();
            label1 = new Label();
            valor = new Label();
            botonGuardar = new Button();
            botonCancelar = new Button();
            cryptonombre = new Label();
            SuspendLayout();
            // 
            // valorPositivo
            // 
            valorPositivo.Location = new Point(134, 75);
            valorPositivo.Name = "valorPositivo";
            valorPositivo.Size = new Size(44, 23);
            valorPositivo.TabIndex = 0;
            // 
            // valorNegativo
            // 
            valorNegativo.Location = new Point(134, 104);
            valorNegativo.Name = "valorNegativo";
            valorNegativo.Size = new Size(44, 23);
            valorNegativo.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 78);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 2;
            label1.Text = "Valor Positivo";
            // 
            // valor
            // 
            valor.AutoSize = true;
            valor.Location = new Point(44, 107);
            valor.Name = "valor";
            valor.Size = new Size(84, 15);
            valor.TabIndex = 3;
            valor.Text = "Valor Negativo";
            // 
            // botonGuardar
            // 
            botonGuardar.Location = new Point(115, 149);
            botonGuardar.Name = "botonGuardar";
            botonGuardar.Size = new Size(75, 23);
            botonGuardar.TabIndex = 5;
            botonGuardar.Text = "Guardar";
            botonGuardar.UseVisualStyleBackColor = true;
            botonGuardar.Click += botonGuardar_Click;
            // 
            // botonCancelar
            // 
            botonCancelar.Location = new Point(34, 149);
            botonCancelar.Name = "botonCancelar";
            botonCancelar.Size = new Size(75, 23);
            botonCancelar.TabIndex = 6;
            botonCancelar.Text = "Cancelar";
            botonCancelar.UseVisualStyleBackColor = true;
            botonCancelar.Click += botonCancelar_Click;
            // 
            // cryptonombre
            // 
            cryptonombre.AutoSize = true;
            cryptonombre.Location = new Point(90, 34);
            cryptonombre.Name = "cryptonombre";
            cryptonombre.Size = new Size(38, 15);
            cryptonombre.TabIndex = 7;
            cryptonombre.Text = "label2";
            cryptonombre.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AlertaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(216, 181);
            Controls.Add(cryptonombre);
            Controls.Add(botonCancelar);
            Controls.Add(botonGuardar);
            Controls.Add(valor);
            Controls.Add(label1);
            Controls.Add(valorNegativo);
            Controls.Add(valorPositivo);
            Name = "AlertaForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AlertaForm";
            Load += AlertaForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox valorPositivo;
        private TextBox valorNegativo;
        private Label label1;
        private Label valor;
      //  private Label Crypto;
        private Button botonGuardar;
        private Button botonCancelar;
        private Label cryptonombre;
    }
}