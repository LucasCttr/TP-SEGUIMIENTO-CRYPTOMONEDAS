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

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Vistas
{
    public partial class AltaUsuarioForm : Form // Formulario para registrar un nuevo usuario.
    {
        public IUnitOfWork _unitOfWork; // Interfaz Unit of Work para manejar repositorios.

        public AltaUsuarioForm(IUnitOfWork unit)
        {
            _unitOfWork = unit; 
            InitializeComponent(); 
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario cuando se cancela.
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            // Validar si el correo ya está registrado.
            if (_unitOfWork.Usuarios.VerificarExistenciaUsuario(textCorreo.Text)) // Asume que retorna un booleano.
            {
                MessageBox.Show("El correo ingresado ya se encuentra registrado");
                return; // Salir si el correo ya existe.
            }

            // Validar si las contraseñas coinciden.
            if (textContraseña.Text != textContraseña2.Text)
            {
                MessageBox.Show("Las contraseñas ingresadas no coinciden");
                return; // Salir si las contraseñas no coinciden.
            }

            // Registrar al usuario si las validaciones son exitosas.
            _unitOfWork.Usuarios.DarDeAltaUsuario(textNombre.Text, textCorreo.Text, textContraseña.Text);
            MessageBox.Show("Registro exitoso");
            this.Close(); // Cierra el formulario después del registro.
        }
    }
}
