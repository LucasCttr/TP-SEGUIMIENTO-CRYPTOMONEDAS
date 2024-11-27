namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Vistas
{
    partial class MiCuentaForm
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
            textNombre = new TextBox();
            textCorreo = new TextBox();
            textContraseña = new TextBox();
            botonCancelar = new Button();
            botonModificar = new Button();
            labelNombre = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            botonGuardar = new Button();
            SuspendLayout();
            // 
            // textNombre
            // 
            textNombre.Location = new Point(72, 52);
            textNombre.Name = "textNombre";
            textNombre.Size = new Size(133, 23);
            textNombre.TabIndex = 1;
            // 
            // textCorreo
            // 
            textCorreo.Location = new Point(72, 93);
            textCorreo.Name = "textCorreo";
            textCorreo.Size = new Size(133, 23);
            textCorreo.TabIndex = 2;
            // 
            // textContraseña
            // 
            textContraseña.Location = new Point(71, 131);
            textContraseña.Name = "textContraseña";
            textContraseña.Size = new Size(134, 23);
            textContraseña.TabIndex = 3;
            textContraseña.UseSystemPasswordChar = true;
            // 
            // botonCancelar
            // 
            botonCancelar.Location = new Point(65, 178);
            botonCancelar.Name = "botonCancelar";
            botonCancelar.Size = new Size(67, 23);
            botonCancelar.TabIndex = 5;
            botonCancelar.Text = "Cancelar";
            botonCancelar.UseVisualStyleBackColor = true;
            botonCancelar.Click += botonCancelar_Click;
            // 
            // botonModificar
            // 
            botonModificar.Location = new Point(138, 179);
            botonModificar.Name = "botonModificar";
            botonModificar.Size = new Size(72, 23);
            botonModificar.TabIndex = 4;
            botonModificar.Text = "Modificar";
            botonModificar.UseVisualStyleBackColor = true;
            botonModificar.Click += botonModificar_Click;
            // 
            // labelNombre
            // 
            labelNombre.AutoSize = true;
            labelNombre.Location = new Point(18, 57);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(51, 15);
            labelNombre.TabIndex = 5;
            labelNombre.Text = "Nombre";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 98);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 6;
            label1.Text = "Correo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(2, 139);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 7;
            label2.Text = "Contraseña";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(109, 24);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 8;
            label3.Text = "Mi Cuenta";
            // 
            // botonGuardar
            // 
            botonGuardar.Location = new Point(138, 178);
            botonGuardar.Name = "botonGuardar";
            botonGuardar.Size = new Size(72, 23);
            botonGuardar.TabIndex = 4;
            botonGuardar.Text = "Guardar";
            botonGuardar.UseVisualStyleBackColor = true;
            botonGuardar.Click += buttonGuardar_Click;
            // 
            // MiCuentaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(261, 215);
            Controls.Add(botonGuardar);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(labelNombre);
            Controls.Add(botonModificar);
            Controls.Add(botonCancelar);
            Controls.Add(textContraseña);
            Controls.Add(textCorreo);
            Controls.Add(textNombre);
            Name = "MiCuentaForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MiCuentaForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textNombre;
        private TextBox textCorreo;
        private TextBox textContraseña;
        private Button botonCancelar;
        private Button botonModificar;
        private Label labelNombre;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button botonGuardar;
    }
}