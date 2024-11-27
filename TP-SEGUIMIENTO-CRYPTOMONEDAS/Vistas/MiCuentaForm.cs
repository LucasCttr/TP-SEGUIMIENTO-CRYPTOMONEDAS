using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.Dominio;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.UntOfWork;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Vistas
{
    public partial class MiCuentaForm : Form
    {
        private IUnitOfWork _unitOfWork;
        public MiCuentaForm(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            InitializeComponent();
            CargarForm();
        }

        private void CargarForm()
        {
            textNombre.Text = SessionManager.CurrentName;
            textCorreo.Text = SessionManager.CurrentMail;
            textContraseña.Text = SessionManager.CurrentPassword;
            ActiviarBotonModificar();
        }


        private void botonModificar_Click(object sender, EventArgs e)
        {
            ActivarBotonGuardar();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            var validarForm = new ValidarCambiosForm(_unitOfWork);

            // Suscribirse al evento OnPasswordValidated
            validarForm.OnPasswordValidated += ValidarForm_OnPasswordValidated;

            // Mostrar el formulario como un cuadro de diálogo y esperar su resultado
            if (validarForm.ShowDialog() == DialogResult.OK)
            {
                // El formulario fue cerrado con DialogResult.OK, lo que significa que la contraseña fue correcta
                // Activar el botón "Modificar"
                ActiviarBotonModificar();
                _unitOfWork.Usuarios.CambiarDatosUsuario(textNombre.Text, textCorreo.Text, textContraseña.Text);
            }
        }

        // Este es el manejador del evento OnPasswordValidated
        private void ValidarForm_OnPasswordValidated(object sender, bool isValid)
        {
            if (isValid)
            {
                // Si la contraseña es válida
                MessageBox.Show("Datos modificados correctamente");
            }
            else
            {
                // Si la contraseña no es válida, puedes mostrar un mensaje o hacer algo más
                MessageBox.Show("La contraseña es incorrecta. Intenta nuevamente.");
            }
        }


        private void ActiviarBotonModificar()
        {
            botonGuardar.Visible = false;
            botonModificar.Visible = true;
            textNombre.ReadOnly = true;
            textCorreo.ReadOnly = true;
            textContraseña.ReadOnly = true;
            textContraseña.UseSystemPasswordChar = true;
        }

        private void ActivarBotonGuardar()
        {
            botonGuardar.Visible = true;
            botonModificar.Visible = false;
            textNombre.ReadOnly = false;
            textCorreo.ReadOnly = false;
            textContraseña.ReadOnly = false;
            textContraseña.UseSystemPasswordChar = false;
            textContraseña.Text = string.Empty;
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
