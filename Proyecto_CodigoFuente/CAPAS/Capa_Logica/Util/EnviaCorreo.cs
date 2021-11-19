using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades.Util
{
    /// <summary>
    /// Clase EnviaCorreo, se encarga de construir y de enviar el correo electronico
    /// con el mensaje suministrado
    /// </summary>
    public class EnviaCorreo
    {
        /// <summary>
        /// Correo de la persona/empresa que envia el correo
        /// </summary>
        /// <value> Correo de origen</value>
        private const string CorreoOrigen = "paul.pry.utn@gmail.com";

        /// <summary>
        /// Contrasenna del correo de origen
        /// </summary>
        /// <value> Contrasenna de correo de origen</value>
        private const string ContrasennaOrigen = "Agosto0899";

        /// <summary>
        /// Metodo statico, para que se pueda ser llamado, desde cualquier lugar, y 
        /// enviar el correo electronico
        /// </summary>
        /// <returns>void</returns>
        public static void EnviaEmail(string pCorreoDestino, string pAsunto, string pMensaje)
            {
                MailMessage mensaje = new MailMessage();
                mensaje.IsBodyHtml = true;
                mensaje.Subject = pAsunto;
                mensaje.Body = pMensaje;

                mensaje.From = new MailAddress(CorreoOrigen);
                mensaje.To.Add(pCorreoDestino);

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

                smtp.Credentials = new NetworkCredential(CorreoOrigen, ContrasennaOrigen);
                smtp.EnableSsl = true;

            // Sirve para enviar un archivo adjunto al correo
            Attachment attachment1 = new Attachment(@"c:\temp\FacturaXML.xml");
            mensaje.Attachments.Add(attachment1);
            Attachment attachment2 = new Attachment(@"c:\temp\FacturaCompra.pdf");
            mensaje.Attachments.Add(attachment2);

            smtp.Send(mensaje);
            smtp.Dispose();
        }
    }
}
