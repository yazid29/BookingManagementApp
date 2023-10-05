using API.Contracts;
using Microsoft.AspNetCore.Hosting.Server;
using System.Net.Mail;

namespace API.Utilities.Handler
{
    public class EmailHandler : IEmailHandler
    {
        private string _server;
        private int _port;
        private string _fromEmailAddress;
        public EmailHandler(string server,int port, string email) {
            _server = server;
            _port = port;
            _fromEmailAddress = email;
        }
        public void Send(string subject, string body, string _fromEmailAddress)
        {
            var message = new MailMessage()
            {
                From = new MailAddress(_fromEmailAddress),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            message.To.Add(new MailAddress(_fromEmailAddress));

            using var smtpClient = new SmtpClient(_server,_port);
            smtpClient.Send(message);
        }
    }
}
