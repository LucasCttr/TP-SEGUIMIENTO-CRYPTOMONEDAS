using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.Controllers;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.UntOfWork;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Vistas
{
    public partial class AltaUsuarioForm : Form // Formulario para registrar un nuevo usuario.
    {
        private readonly APIController _APIController;
        private readonly UsuarioController _usuarioController;
        private readonly AlertaController _alertaController;

        public AltaUsuarioForm(AlertaController alertaController, APIController cryptosFavoritascontroller, UsuarioController usuarioController)
        {
            _APIController = cryptosFavoritascontroller;
            _usuarioController = usuarioController;
            _alertaController = alertaController;

            InitializeComponent(); 
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario cuando se cancela.
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            bool esValido = true;

            // Validar si el correo ya está registrado.
            if (_usuarioController.ObtenerUsuario(textCorreo.Text) != null)
            {
                MessageBox.Show("El correo ingresado ya se encuentra registrado");
                esValido = false;
            }

            // Validar si las contraseñas coinciden.
            if (textContraseña.Text != textContraseña2.Text)
            {
                MessageBox.Show("Las contraseñas ingresadas no coinciden");
                esValido = false;
            }

            // Registrar al usuario si ambas validaciones son exitosas.
            if (esValido)
            {
                MessageBox.Show("Usuario dado de alta correctamente");
                _usuarioController.DarDeAltaUsuario(textNombre.Text, textCorreo.Text, textContraseña.Text);
                this.Close(); // Cierra el formulario después del registro.
            }
        }
    }
}
