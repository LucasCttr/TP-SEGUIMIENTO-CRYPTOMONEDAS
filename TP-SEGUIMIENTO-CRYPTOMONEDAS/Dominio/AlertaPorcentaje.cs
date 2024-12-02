using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.SessionManagerService;
using MailKit.Net.Smtp;
using MimeKit;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Dominio
{
    public class AlertaPorcentaje : IAlertaObserver
    {
        private readonly Action<string,int> alertaActivada;
        private readonly Action<int> eliminarObservador; // Acción para eliminar el observador
        public string nombreCrypto { get; set; }
        public int idAlerta { get; set; }
        public decimal valorAlerta { get; set; }
        public string tipoAlerta { get; set; }

        public AlertaPorcentaje(Action<string,int> accion, Action<int> eliminar)
        {
            alertaActivada = accion;
            eliminarObservador = eliminar;
        }

        // Configuramos la alerta con los valores de la criptomoneda y los umbrales
        public void ConfigurarAlerta(string nombre, decimal valorAlerta, string tipoAlerta, int idAlerta)
        {
            this.nombreCrypto = nombre;
            this.valorAlerta = valorAlerta;
            this.tipoAlerta = tipoAlerta;
            this.idAlerta = idAlerta;   
        }

        public void Notificar(decimal cambio24Hs)
        {
            if (tipoAlerta == "Incremento" && cambio24Hs >= valorAlerta)
            {
                alertaActivada($"🔔 Alerta: {nombreCrypto} ha aumentado un {cambio24Hs:F2}% en las últimas 24 horas.", idAlerta);
                //EnviarMail(tipoAlerta, valorAlerta);
            }
            else if (tipoAlerta == "Decremento" && cambio24Hs <= valorAlerta)
            {
                alertaActivada($"🔔 Alerta: {nombreCrypto} ha disminuido un {cambio24Hs:F2}% en las últimas 24 horas.", idAlerta);
                //EnviarMail(tipoAlerta, valorAlerta);
            }
        }

        //Crear Contrasena de aplicaciones
        private void EnviarMail(string tipo, decimal valor)
        {
            var mailFrom = "carottalucas2@gmail.com";
            var mailTo = SessionManager.CurrentMail;
            try
            {
                // Crear el mensaje
                var mensaje = new MimeMessage();
                mensaje.From.Add(new MailboxAddress("Alertas", mailFrom));
                mensaje.To.Add(new MailboxAddress(SessionManager.CurrentName, "carottalucas@gmail.com"));   // Modificar, poner mailTo 
                mensaje.Subject = "Alerta Activada: " + nombreCrypto;

                // Cuerpo del correo
                mensaje.Body = new TextPart("plain")
                {
                    Text = "Este es un correo para avisar que la cryptomoneda " + nombreCrypto + " " + tipo + " un" + valor + "%"
                };

                // Configurar el cliente SMTP
                using (var cliente = new SmtpClient())
                {
                    cliente.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    cliente.Authenticate(mailFrom, "asda");

                    // Enviar el correo
                    cliente.Send(mensaje);
                    cliente.Disconnect(true);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
