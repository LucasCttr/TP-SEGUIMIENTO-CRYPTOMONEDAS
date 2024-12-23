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
        private readonly CryptosFavoritasController _cryptosFavoritasController;
        private readonly UsuarioController _usuarioController;
        private readonly AlertaController _alertaController;

        public AltaUsuarioForm(AlertaController alertaController, CryptosFavoritasController cryptosFavoritascontroller, UsuarioController usuarioController)
        {
            _cryptosFavoritasController = cryptosFavoritascontroller;
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
            //// Validar si el correo ya está registrado.
            //if (_unitOfWork.Usuarios.VerificarExistenciaUsuario(textCorreo.Text)) // Asume que retorna un booleano.
            //    _usuarioController.VerificarExistenciaUsuario(textCorreo.Text);
            //{
            //    MessageBox.Show("El correo ingresado ya se encuentra registrado");
            //    return; // Salir si el correo ya existe.
            //}

            // Validar si las contraseñas coinciden.
            if (textContraseña.Text != textContraseña2.Text)
            {
                MessageBox.Show("Las contraseñas ingresadas no coinciden");
                return; // Salir si las contraseñas no coinciden.
            }

            // Registrar al usuario si las validaciones son exitosas.
            _usuarioController.DarDeAltaUsuario(textNombre.Text, textCorreo.Text, textContraseña.Text);

            this.Close(); // Cierra el formulario después del registro.
        }
    }
}
