namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Vistas
{
    partial class AltaUsuarioForm
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
            botonGuardar = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            labelNombre = new Label();
            botonCancelar = new Button();
            textContraseña = new TextBox();
            textCorreo = new TextBox();
            textNombre = new TextBox();
            textContraseña2 = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // botonGuardar
            // 
            botonGuardar.Location = new Point(193, 207);
            botonGuardar.Name = "botonGuardar";
            botonGuardar.Size = new Size(63, 23);
            botonGuardar.TabIndex = 19;
            botonGuardar.Text = "Guardar";
            botonGuardar.UseVisualStyleBackColor = true;
            botonGuardar.Click += botonGuardar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(160, 20);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 18;
            label3.Text = "Registro";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 130);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 17;
            label2.Text = "Contraseña";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(73, 92);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 16;
            label1.Text = "Correo";
            // 
            // labelNombre
            // 
            labelNombre.AutoSize = true;
            labelNombre.Location = new Point(65, 51);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(51, 15);
            labelNombre.TabIndex = 15;
            labelNombre.Text = "Nombre";
            // 
            // botonCancelar
            // 
            botonCancelar.Location = new Point(123, 207);
            botonCancelar.Name = "botonCancelar";
            botonCancelar.Size = new Size(64, 23);
            botonCancelar.TabIndex = 13;
            botonCancelar.Text = "Cancelar";
            botonCancelar.UseVisualStyleBackColor = true;
            botonCancelar.Click += botonCancelar_Click;
            // 
            // textContraseña
            // 
            textContraseña.Location = new Point(122, 127);
            textContraseña.Name = "textContraseña";
            textContraseña.Size = new Size(134, 23);
            textContraseña.TabIndex = 12;
            textContraseña.UseSystemPasswordChar = true;
            // 
            // textCorreo
            // 
            textCorreo.Location = new Point(123, 89);
            textCorreo.Name = "textCorreo";
            textCorreo.Size = new Size(133, 23);
            textCorreo.TabIndex = 11;
            // 
            // textNombre
            // 
            textNombre.Location = new Point(123, 48);
            textNombre.Name = "textNombre";
            textNombre.Size = new Size(133, 23);
            textNombre.TabIndex = 10;
            // 
            // textContraseña2
            // 
            textContraseña2.Location = new Point(122, 166);
            textContraseña2.Name = "textContraseña2";
            textContraseña2.Size = new Size(134, 23);
            textContraseña2.TabIndex = 13;
            textContraseña2.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 169);
            label4.Name = "label4";
            label4.Size = new Size(105, 30);
            label4.TabIndex = 21;
            label4.Text = "Repetir contraseña\r\n\r\n";
            // 
            // AltaUsuarioForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(349, 238);
            Controls.Add(label4);
            Controls.Add(textContraseña2);
            Controls.Add(botonGuardar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(labelNombre);
            Controls.Add(botonCancelar);
            Controls.Add(textContraseña);
            Controls.Add(textCorreo);
            Controls.Add(textNombre);
            Name = "AltaUsuarioForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AltaUsuarioForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button botonGuardar;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label labelNombre;
        private Button botonCancelar;
        private TextBox textContraseña;
        private TextBox textCorreo;
        private TextBox textNombre;
        private TextBox textContraseña2;
        private Label label4;
    }
}