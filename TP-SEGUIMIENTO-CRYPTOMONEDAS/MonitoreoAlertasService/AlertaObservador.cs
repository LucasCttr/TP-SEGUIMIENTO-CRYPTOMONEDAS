using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.SessionManagerService;
//using MailKit.Net.Smtp;
//using MimeKit;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.MonitoreoAlertasService
{
    public class AlertaObservador : IAlertaObserver
    {
        private readonly Action<string, int> alertaActivada;
        public string nombreCrypto { get; set; }
        public int idAlerta { get; set; }
        public decimal valorAlerta { get; set; }
        public string tipoAlerta { get; set; }

        public AlertaObservador(Action<string, int> accion)
        {
            alertaActivada = accion;
        }

        // Configuramos la alerta con los valores de la criptomoneda y los umbrales
        public void ConfigurarAlerta(string nombre, decimal valorAlerta, string tipoAlerta, int idAlerta)
        {
            nombreCrypto = nombre;
            this.valorAlerta = valorAlerta;
            this.tipoAlerta = tipoAlerta;
            this.idAlerta = idAlerta;
        }

        public void Notificar(decimal cambio24Hs)
        {
            if (tipoAlerta == "Incremento" && cambio24Hs >= valorAlerta)
            {
                alertaActivada($"🔔 Alerta: {nombreCrypto} ha aumentado un {cambio24Hs:F2}% en las últimas 24 horas.", idAlerta);
                EnviarMail(tipoAlerta, valorAlerta);
            }
            else if (tipoAlerta == "Decremento" && cambio24Hs <= valorAlerta)
            {
                alertaActivada($"🔔 Alerta: {nombreCrypto} ha disminuido un {cambio24Hs:F2}% en las últimas 24 horas.", idAlerta);
                EnviarMail(tipoAlerta, valorAlerta);
            }
        }

        //Crear Contrasena de aplicaciones
        private void EnviarMail(string tipo, decimal valor)
        {   
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            var mailFrom = configuration["EmailSettings:MailFrom"];
            var mailTo = "martindfernandez23@gmail.com"; //cambiar a SessionManager.CurrentMail;
            var smtpPassword = configuration["EmailSettings:SMTPPassword"];
            var asunto = "Alerta Activada: " + nombreCrypto;
            var cuerpo = "Este es un correo para avisar que la cryptomoneda " + nombreCrypto + " " + tipo + " un " + valor + "%";

            try
            {
                // Configuración del cliente SMTP
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587; // Puerto SMTP
                client.Credentials = new NetworkCredential(mailFrom, smtpPassword);
                client.EnableSsl = true; // Habilitar SSL

                // Crear el mensaje de correo
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(mailFrom);
                mailMessage.To.Add(mailTo);
                mailMessage.Subject = asunto;
                mailMessage.Body = cuerpo;

                // Enviar el correo
                client.Send(mailMessage);
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Console.WriteLine("Error al enviar el correo: " + ex.Message);
            }
        }
    }
}
