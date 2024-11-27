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
            valorAlerta = new TextBox();
            label1 = new Label();
            valor = new Label();
            botonGuardar = new Button();
            botonCancelar = new Button();
            cryptonombre = new Label();
            tipoAlerta = new ComboBox();
            SuspendLayout();
            // 
            // valorAlerta
            // 
            valorAlerta.Location = new Point(62, 74);
            valorAlerta.Name = "valorAlerta";
            valorAlerta.Size = new Size(103, 23);
            valorAlerta.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 77);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 2;
            label1.Text = "Valor";
            // 
            // valor
            // 
            valor.AutoSize = true;
            valor.Location = new Point(13, 106);
            valor.Name = "valor";
            valor.Size = new Size(30, 15);
            valor.TabIndex = 3;
            valor.Text = "Tipo";
            // 
            // botonGuardar
            // 
            botonGuardar.Location = new Point(99, 146);
            botonGuardar.Name = "botonGuardar";
            botonGuardar.Size = new Size(75, 23);
            botonGuardar.TabIndex = 5;
            botonGuardar.Text = "Guardar";
            botonGuardar.UseVisualStyleBackColor = true;
            botonGuardar.Click += botonGuardar_Click;
            // 
            // botonCancelar
            // 
            botonCancelar.Location = new Point(18, 146);
            botonCancelar.Name = "botonCancelar";
            botonCancelar.Size = new Size(75, 23);
            botonCancelar.TabIndex = 6;
            botonCancelar.Text = "Cancelar";
            botonCancelar.UseVisualStyleBackColor = true;
            // 
            // cryptonombre
            // 
            cryptonombre.AutoSize = true;
            cryptonombre.Location = new Point(85, 36);
            cryptonombre.Name = "cryptonombre";
            cryptonombre.Size = new Size(38, 15);
            cryptonombre.TabIndex = 7;
            cryptonombre.Text = "label2";
            cryptonombre.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tipoAlerta
            // 
            tipoAlerta.FormattingEnabled = true;
            tipoAlerta.Items.AddRange(new object[] { "Incremento", "Decremento" });
            tipoAlerta.Location = new Point(62, 103);
            tipoAlerta.Name = "tipoAlerta";
            tipoAlerta.Size = new Size(103, 23);
            tipoAlerta.TabIndex = 8;
            // 
            // AlertaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(193, 181);
            Controls.Add(tipoAlerta);
            Controls.Add(cryptonombre);
            Controls.Add(botonCancelar);
            Controls.Add(botonGuardar);
            Controls.Add(valor);
            Controls.Add(label1);
            Controls.Add(valorAlerta);
            Name = "AlertaForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AlertaForm";
            Load += AlertaForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox valorAlerta;
        private Label label1;
        private Label valor;
      //  private Label Crypto;
        private Button botonGuardar;
        private Button botonCancelar;
        private Label cryptonombre;
        private ComboBox tipoAlerta;
    }
}