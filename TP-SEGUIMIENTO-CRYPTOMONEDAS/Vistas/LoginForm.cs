using Microsoft.Extensions.DependencyInjection;
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
        }

        private void BotonIniciar_Click(object sender, EventArgs e)
        {
            string mail = MailBox.Text;
            string contrasena = ContrasenaBox.Text;

            // Llamar a la función para validar las credenciales
            var user = _unitOfWork.Usuarios.ValidarUsuario(mail, contrasena);

            if (user != null)
            {
                // Autenticación exitosa
                SessionManager.CurrentUserId = user.Id; // Guardar ID de usuario en SessionManager
                this.Hide();
                var alertaObserver = new AlertaObserverManager();
                var _alertaService = new AlertaService(_unitOfWork, alertaObserver);
                var inicioForm = new InicioForm(_unitOfWork,_alertaService); // Cambia esto al nombre de tu formulario principal
                inicioForm.Show();
            }
            else
            {
                // Mostrar mensaje de error
                MessageBox.Show("Correo electrónico o contraseña incorrectos.");
            }
        }
    }
}
