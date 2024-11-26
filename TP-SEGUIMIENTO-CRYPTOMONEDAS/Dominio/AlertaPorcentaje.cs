using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;
using MailKit.Net.Smtp;
using MimeKit;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Dominio
{
    public class AlertaPorcentaje : IAlertaObserver
    {
        private readonly Action<string> accionAlerta;
        private readonly Action<string> eliminarObservador; // Acción para eliminar el observador
        private readonly Action<string, decimal, string> alertaPositivaActivada;  //Crear el hisotiral de la alerta +
        private readonly Action<string, decimal, string> alertaNegativaActivada;  //Crear el hisotiral de la alerta -
        public string nombreCrypto { get; set; }
        private decimal valorIncremento;
        private decimal valorDecremento;

        public AlertaPorcentaje(Action<string> accion, Action<string> eliminar, Action<string, decimal, string> alertaPositiva, Action<string, decimal, string> alertaNegativa)
        {
            accionAlerta = accion;
            eliminarObservador = eliminar;
            alertaPositivaActivada = alertaPositiva;
            alertaNegativaActivada = alertaNegativa;
        }

        // Configuramos la alerta con los valores de la criptomoneda y los umbrales
        public void ConfigurarAlerta(string nombre, decimal valorPositivo, decimal valorNegativo)
        {
            this.nombreCrypto = nombre;
            this.valorIncremento = valorPositivo;
            this.valorDecremento = valorNegativo;
        }

        public void Notificar(decimal cambio24Hs)
        {
            if (cambio24Hs >= valorIncremento && valorIncremento != 0)
            {
                accionAlerta($"🔔 Alerta: {nombreCrypto} ha aumentado un {cambio24Hs:F2}% en las últimas 24 horas.");
                eliminarObservador(nombreCrypto);
                alertaPositivaActivada(nombreCrypto, valorIncremento, "Incremento");
                //EnviarMail("Incremento", valorIncremento);

            }
            else if (cambio24Hs <= valorDecremento && valorDecremento != 0)
            {
                accionAlerta($"🔔 Alerta: {nombreCrypto} ha disminuido un {cambio24Hs:F2}% en las últimas 24 horas.");
                eliminarObservador(nombreCrypto);
                alertaNegativaActivada(nombreCrypto, valorDecremento, "Decremento");
               //EnviarMail("Decremento", valorDecremento);
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
