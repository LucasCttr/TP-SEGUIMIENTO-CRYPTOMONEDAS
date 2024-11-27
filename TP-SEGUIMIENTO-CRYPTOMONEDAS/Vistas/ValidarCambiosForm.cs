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

        private void botonConfirmar_Click(object sender, EventArgs e)
        {
            var contraseñaCorrecta = _unitOfWork.Usuarios.ValidarContraseña(textContraseña.Text);

            if (contraseñaCorrecta == true)
            {
                OnPasswordValidated?.Invoke(this, true); // Invoca el evento con resultado true
                this.DialogResult = DialogResult.OK;    // Cierra el formulario con éxito
                this.Close();

            }
            else { MessageBox.Show("Contraseña incorrecta"); }
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
