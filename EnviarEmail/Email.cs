using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace EnviarEmail
{
    public class Email
    {
        private SmtpClient SmtpClient { get; set; }

        public Email (string host, int port, string user, string password)
        {
            SmtpClient = new SmtpClient
            {
                //Configurações
                Host = host,
                Port = port,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(user, password)
            };
        }

        public void SendMail(string from, List<string> lstTo, string subject, string body, bool bodyHtml)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(from);

                    foreach (var email in lstTo)
                    {
                        mail.To.Add(new MailAddress(email));
                    }

                    mail.Subject = subject;
                    mail.IsBodyHtml = bodyHtml;
                    mail.Body = body;

                    //Envia E-mail
                    SmtpClient.Send(mail);                    
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
