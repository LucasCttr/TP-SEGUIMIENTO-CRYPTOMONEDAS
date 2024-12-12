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
    public partial class ValidarCambiosForm : Form
    {
        public event EventHandler<bool> OnPasswordValidated; // Evento para notificar si la contraseña es válida
        private IUnitOfWork _unitOfWork;

        public ValidarCambiosForm(IUnitOfWork unit)
        {
            _unitOfWork = unit;
            InitializeComponent(); 
        }

        // Evento que se activa al hacer clic en el botón "Confirmar"
        private void botonConfirmar_Click(object sender, EventArgs e)
        {
            // Valida la contraseña ingresada mediante el unitOfWork
            var contraseñaCorrecta = _unitOfWork.Usuarios.ValidarContraseña(textContraseña.Text);

            if (contraseñaCorrecta == true)
            {
                // Si la contraseña es correcta, invoca el evento OnPasswordValidated con resultado true
                OnPasswordValidated?.Invoke(this, true);
                this.DialogResult = DialogResult.OK; // Establece el resultado del formulario como OK
                this.Close(); // Cierra el formulario
            }
            else
            {
                // Si la contraseña es incorrecta, muestra un mensaje al usuario
                MessageBox.Show("Contraseña incorrecta");
            }
        }

        // Evento que se activa al hacer clic en el botón "Cancelar"
        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario sin realizar acciones adicionales
        }
    }
}
