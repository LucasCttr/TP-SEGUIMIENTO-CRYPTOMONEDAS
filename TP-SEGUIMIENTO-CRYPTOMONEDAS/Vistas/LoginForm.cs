﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.UntOfWork;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.Vistas;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.SessionManagerService;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.Dominio;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Vistas
{
    public partial class LoginForm : Form
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoginForm(IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(LoginForm_KeyDown);
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BotonIniciar.PerformClick();
            }
        }

        private void BotonIniciar_Click(object sender, EventArgs e)
        {
            string Correo = MailBox.Text;
            string Contraseña = ContrasenaBox.Text;

            // Llamar a la función para validar las credenciales
            var user = _unitOfWork.Usuarios.ValidarUsuario(Correo, Contraseña);

            if (user != null)
            {
                // Autenticación exitosa
                // Guardar ID y Mail de usuario en SessionManager
                SessionManager.CurrentUserId = user.UsuarioID;
                SessionManager.CurrentPassword = user.Contraseña;
                SessionManager.CurrentMail = user.Correo;
                SessionManager.CurrentName = user.Nombre;
                this.Hide();
                var _alertaService = new AlertaMonitor();
                var inicioForm = new InicioForm(_unitOfWork, _alertaService); // Cambia esto al nombre de tu formulario principal
                inicioForm.Show();
            }
            else
            {
                // Mostrar mensaje de error
                MessageBox.Show("Correo electrónico o contraseña incorrectos.");
            }
        }

        private void botonRegistrarse_Click(object sender, EventArgs e)
        {
            var altaForm = new AltaUsuarioForm(_unitOfWork);
            altaForm.ShowDialog();
        }
    }
}
