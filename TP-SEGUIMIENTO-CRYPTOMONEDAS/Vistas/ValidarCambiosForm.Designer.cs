namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Vistas
{
    partial class ValidarCambiosForm
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
            botonCancelar = new Button();
            botonConfirmar = new Button();
            textContraseña = new TextBox();
            botonContraseña = new Label();
            SuspendLayout();
            // 
            // botonCancelar
            // 
            botonCancelar.Location = new Point(18, 120);
            botonCancelar.Name = "botonCancelar";
            botonCancelar.Size = new Size(66, 23);
            botonCancelar.TabIndex = 0;
            botonCancelar.Text = "Cancelar";
            botonCancelar.UseVisualStyleBackColor = true;
            botonCancelar.Click += botonCancelar_Click;
            // 
            // botonConfirmar
            // 
            botonConfirmar.Location = new Point(90, 120);
            botonConfirmar.Name = "botonConfirmar";
            botonConfirmar.Size = new Size(66, 23);
            botonConfirmar.TabIndex = 1;
            botonConfirmar.Text = "Confirmar";
            botonConfirmar.UseVisualStyleBackColor = true;
            botonConfirmar.Click += botonConfirmar_Click;
            // 
            // textContraseña
            // 
            textContraseña.Location = new Point(18, 71);
            textContraseña.Name = "textContraseña";
            textContraseña.Size = new Size(138, 23);
            textContraseña.TabIndex = 2;
            textContraseña.UseSystemPasswordChar = true;
            // 
            // botonContraseña
            // 
            botonContraseña.AutoSize = true;
            botonContraseña.Location = new Point(33, 36);
            botonContraseña.Name = "botonContraseña";
            botonContraseña.Size = new Size(112, 15);
            botonContraseña.TabIndex = 3;
            botonContraseña.Text = "Ingresar Contraseña";
            // 
            // ValidarCambiosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(175, 155);
            Controls.Add(botonContraseña);
            Controls.Add(textContraseña);
            Controls.Add(botonConfirmar);
            Controls.Add(botonCancelar);
            Name = "ValidarCambiosForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ValidarCambiosForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button botonCancelar;
        private Button botonConfirmar;
        private TextBox textContraseña;
        private Label botonContraseña;
    }
}