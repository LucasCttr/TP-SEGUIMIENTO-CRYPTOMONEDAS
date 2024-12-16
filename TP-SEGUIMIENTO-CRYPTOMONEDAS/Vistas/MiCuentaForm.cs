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
using TP_SEGUIMIENTO_CRYPTOMONEDAS.SessionManagerService;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Vistas
{
    public partial class MiCuentaForm : Form
    {
        private IUnitOfWork _unitOfWork;
        public MiCuentaForm(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            InitializeComponent();
            CargarForm(); // Carga los datos del usuario en el formulario
        }

        // Método para cargar los datos del usuario y configurar el estado inicial del formulario
        private void CargarForm()
        {
            textNombre.Text = SessionManager.CurrentName; // Carga el nombre desde la sesión
            textCorreo.Text = SessionManager.CurrentMail; // Carga el correo desde la sesión
            textContraseña.Text = "*********"; 
            ActiviarBotonModificar(); // Configura el formulario para estar en modo solo lectura
        }

        // Evento que se activa al hacer clic en el botón "Modificar"
        private void botonModificar_Click(object sender, EventArgs e)
        {
            ActivarBotonGuardar(); // Cambia el formulario al modo de edición
        }

        // Evento que se activa al hacer clic en el botón "Guardar"
        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            var validarForm = new ValidarCambiosForm(_unitOfWork); // Crea una instancia para validar la contraseña

            // Suscribirse al evento que valida la contraseña
            validarForm.OnPasswordValidated += ValidarForm_OnPasswordValidated;

            // Muestra el formulario de validación como cuadro de diálogo
            if (validarForm.ShowDialog() == DialogResult.OK)
            {
                // Si la validación fue exitosa, guarda los cambios y activa el modo solo lectura
                ActiviarBotonModificar();
                _unitOfWork.Usuarios.CambiarDatosUsuario(textNombre.Text, textCorreo.Text, textContraseña.Text); // Actualiza los datos del usuario
            }
        }

        // Manejador del evento OnPasswordValidated para acciones según la validación
        private void ValidarForm_OnPasswordValidated(object sender, bool isValid)
        {
            if (isValid)
            {
                // Si la contraseña es válida, se confirma la modificación
                MessageBox.Show("Datos modificados correctamente");
            }
            else
            {
                // Si la contraseña no es válida, se informa al usuario
                MessageBox.Show("La contraseña es incorrecta. Intenta nuevamente.");
            }
        }

        // Método para configurar el formulario en modo solo lectura
        private void ActiviarBotonModificar()
        {
            botonGuardar.Visible = false; // Oculta el botón "Guardar"
            botonModificar.Visible = true; // Muestra el botón "Modificar"
            textNombre.ReadOnly = true; // Establece los campos como no editables
            textCorreo.ReadOnly = true;
            textContraseña.ReadOnly = true;
            textContraseña.UseSystemPasswordChar = true; // Oculta el texto de la contraseña
        }

        // Método para configurar el formulario en modo edición
        private void ActivarBotonGuardar()
        {
            botonGuardar.Visible = true; // Muestra el botón "Guardar"
            botonModificar.Visible = false; // Oculta el botón "Modificar"
            textNombre.ReadOnly = false; // Permite editar los campos
            textCorreo.ReadOnly = false;
            textContraseña.ReadOnly = false;
            textContraseña.UseSystemPasswordChar = false; // Muestra el texto de la contraseña
            textContraseña.Text = string.Empty; // Limpia el campo de contraseña
        }

        // Evento que se activa al hacer clic en el botón "Cancelar"
        private void botonCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario
        }
    }
}
