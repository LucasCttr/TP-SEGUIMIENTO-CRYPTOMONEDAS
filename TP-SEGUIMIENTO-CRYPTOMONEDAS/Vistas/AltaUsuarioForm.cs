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
    public partial class AltaUsuarioForm : Form
    {
        public IUnitOfWork _unitOfWork;

        public AltaUsuarioForm(IUnitOfWork unit)
        {
            _unitOfWork = unit;
            InitializeComponent();
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            // Verificar si el correo ya está registrado
            if (_unitOfWork.Usuarios.VerificarExistenciaUsuario(textCorreo.Text))
            {
                MessageBox.Show("El correo ingresado ya se encuentra registrado");
                return; // Salir del método si el correo ya existe
            }

            // Verificar si las contraseñas coinciden
            if (textContraseña.Text != textContraseña2.Text)
            {
                MessageBox.Show("Las contraseñas ingresadas no coinciden");
                return; // Salir del método si las contraseñas no coinciden
            }

            // Registrar al usuario si pasa las validaciones
            _unitOfWork.Usuarios.DarDeAltaUsuario(textNombre.Text, textCorreo.Text, textContraseña.Text);
            MessageBox.Show("Registro exitoso");
            this.Close(); // Cerrar el formulario después del registro
        }
    }
}
