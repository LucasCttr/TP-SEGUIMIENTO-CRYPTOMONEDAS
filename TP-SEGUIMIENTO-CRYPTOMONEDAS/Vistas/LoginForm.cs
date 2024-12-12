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
using TP_SEGUIMIENTO_CRYPTOMONEDAS.SessionManagerService;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.MonitoreoAlertasService;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.Dominio;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Vistas
{
    public partial class LoginForm : Form // Representa la vista para login.
    {
        private readonly IUnitOfWork _unitOfWork; // Patrón Unit of Work para manejar repositorios.

        public LoginForm(IUnitOfWork unitOfWork)
        {
            InitializeComponent(); 
            _unitOfWork = unitOfWork; 
            this.KeyPreview = true; // Permite que el formulario capture eventos de teclado.
            this.KeyDown += new KeyEventHandler(LoginForm_KeyDown); // Evento para capturar teclas presionadas.
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Detecta si se presionó la tecla Enter.
            {
                BotonIniciar.PerformClick(); // Simula un clic en el botón "Iniciar".
            }
        }

        private void BotonIniciar_Click(object sender, EventArgs e)
        {
            string Correo = MailBox.Text; // Obtiene el correo del TextBox.
            string Contraseña = ContrasenaBox.Text; // Obtiene la contraseña del TextBox.

            // Llama al método del repositorio para validar credenciales.
            var user = _unitOfWork.Usuarios.ValidarUsuario(Correo, Contraseña);

            if (user != null) // Validación exitosa.
            {
                // Se actualizan las propiedades de la sesión con los datos del usuario autenticado.
                SessionManager.CurrentUserId = user.UsuarioID;
                SessionManager.CurrentPassword = user.Contraseña; 
                SessionManager.CurrentMail = user.Correo;
                SessionManager.CurrentName = user.Nombre;

                this.Hide(); // Oculta el formulario de login.

                // Se inicializa el servicio de alertas y el formulario principal.
                var _alertaService = new AlertaMonitor();
                var inicioForm = new InicioForm(_unitOfWork, _alertaService); 
                inicioForm.Show(); // Muestra el formulario principal.
            }
            else
            {
                // Muestra un mensaje si las credenciales son incorrectas.
                MessageBox.Show("Correo electrónico o contraseña incorrectos.");
            }
        }

        private void botonRegistrarse_Click(object sender, EventArgs e)
        {
            var altaForm = new AltaUsuarioForm(_unitOfWork); // Inicia el formulario para registrar un nuevo usuario.
            altaForm.ShowDialog(); // Muestra el formulario de registro como un cuadro de diálogo modal.
        }
    }
}
