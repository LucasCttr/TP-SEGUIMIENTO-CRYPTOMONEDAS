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
                this.Hide();
                var inicioForm = new InicioForm(_unitOfWork); // Cambia esto al nombre de tu formulario principal
                inicioForm.Show();
            }
            else
            {
                // Mostrar mensaje de error
                //lblErrorMessage.Text = "Correo electrónico o contraseña incorrectos.";
            }
        }
    }
}
