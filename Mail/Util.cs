using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Mail
{
    public class Util
    {
        string EmailOrigen = "sammy@calderon.pro";
        string Contraseña = "scc13de89!!xx";

        public int Enviar(string sDesdeCorreo, string sDesdeNombre, string sPara, string Asunto, StringBuilder Cuerpo)
        {
            MailAddress Desde = new MailAddress(sDesdeCorreo, sDesdeNombre);
            MailAddress Para = new MailAddress(sPara);
            MailMessage Mensaje = new MailMessage(Desde, Para);

            Mensaje.IsBodyHtml = true;
            Mensaje.Subject = Asunto;
            Mensaje.Body = Cuerpo.ToString();

            NetworkCredential _credencial = new NetworkCredential(EmailOrigen, Contraseña);

            SmtpClient smtpClient = new SmtpClient("smtpout.secureserver.net");
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = _credencial;            
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;                        

            try
            {
                smtpClient.Send(Mensaje);
                smtpClient.Dispose();
                return 1;
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.ToString());
                return 0;
            }                
        }
    }
}
