using System;
using System.Net;
using System.Net.Mail;

namespace FunctionEnvioEmail.Dominio
{
    public class DadosEmail
    {
        public bool EnviarEmail(string titulo, string mensagem, string destinatarios)
        {
            string remetente = "alef.dev.silva@gmail.com";
            SmtpClient smtpClient = new SmtpClient();
            string msg = string.Empty;

            try
            {
                var client = new SmtpClient("smtp.mailtrap.io", 2525)
                {
                    Credentials = new NetworkCredential("0c95dc503480cd", "0d116cb58ec0f5"),
                    EnableSsl = true
                };
                client.Send(remetente, destinatarios, titulo, mensagem);
             
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return false;
            }
        }
    }
}
