using CarsSystem.Services.Contracts;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace CarsSystem.Services
{
    public class MailService : IMailService
    {
        public void SendEmail(string subject, string content, IEnumerable<string> emails)
        {
            foreach (var email in emails)
            {
                var mail = new MailMessage();
                var smtpServer = new SmtpClient();
                smtpServer.Credentials = new NetworkCredential("mastikurka@gmail.com", "asenmastikata93");
                smtpServer.Port = 587;
                smtpServer.Host = "smtp.gmail.com";

                smtpServer.EnableSsl = true;
                smtpServer.EnableSsl = true;
                mail.To.Add(email);
                mail.From = new MailAddress("mastikurka@gmail.com");
                mail.Subject = subject;
                mail.Body = content;
                smtpServer.Send(mail);
            }
        }
    }
}
