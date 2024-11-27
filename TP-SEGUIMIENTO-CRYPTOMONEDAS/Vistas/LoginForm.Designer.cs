namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Vistas
{
    partial class LoginForm
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
            label1 = new Label();
            label2 = new Label();
            MailBox = new TextBox();
            ContrasenaBox = new TextBox();
            label3 = new Label();
            BotonIniciar = new Button();
            botonRegistrarse = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(71, 81);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 0;
            label1.Text = "Mail";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 121);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 1;
            label2.Text = "Contrasena";
            // 
            // MailBox
            // 
            MailBox.Location = new Point(107, 78);
            MailBox.Name = "MailBox";
            MailBox.Size = new Size(173, 23);
            MailBox.TabIndex = 2;
            // 
            // ContrasenaBox
            // 
            ContrasenaBox.Location = new Point(107, 118);
            ContrasenaBox.Name = "ContrasenaBox";
            ContrasenaBox.Size = new Size(173, 23);
            ContrasenaBox.TabIndex = 3;
            ContrasenaBox.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(157, 34);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 4;
            label3.Text = "Bienvenido";
            // 
            // BotonIniciar
            // 
            BotonIniciar.Location = new Point(205, 164);
            BotonIniciar.Name = "BotonIniciar";
            BotonIniciar.Size = new Size(75, 23);
            BotonIniciar.TabIndex = 5;
            BotonIniciar.Text = "Iniciar";
            BotonIniciar.UseVisualStyleBackColor = true;
            BotonIniciar.Click += BotonIniciar_Click;
            // 
            // botonRegistrarse
            // 
            botonRegistrarse.Location = new Point(107, 164);
            botonRegistrarse.Name = "botonRegistrarse";
            botonRegistrarse.Size = new Size(75, 23);
            botonRegistrarse.TabIndex = 6;
            botonRegistrarse.Text = "Registrarse";
            botonRegistrarse.UseVisualStyleBackColor = true;
            botonRegistrarse.Click += botonRegistrarse_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(366, 199);
            Controls.Add(botonRegistrarse);
            Controls.Add(BotonIniciar);
            Controls.Add(label3);
            Controls.Add(ContrasenaBox);
            Controls.Add(MailBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox MailBox;
        private TextBox ContrasenaBox;
        private Label label3;
        private Button BotonIniciar;
        private Button botonRegistrarse;
    }
}