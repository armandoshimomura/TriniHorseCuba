using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace Mail
{
    public class Util
    {
        string EmailOrigen = "horsebackubatrinidad@gmail.com";
        string Contraseña = "samuel.961029";

        public void Enviar(string To, string Asunto, StringBuilder Cuerpo)
        {
            MailMessage mailMessage = new MailMessage(EmailOrigen, To, Asunto, Cuerpo.ToString());
            mailMessage.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient("smtpout.secureserver.net");
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Port = 587;                       
            smtpClient.Credentials = new System.Net.NetworkCredential(EmailOrigen, Contraseña);
            smtpClient.Send(mailMessage);
            smtpClient.Dispose();            
        }
    }
}
