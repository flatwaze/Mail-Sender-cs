using System;
using System.Net;
using System.Windows;
using System.Net.Mail;
using System.Security;
using System.Windows.Documents;

namespace MailSender
{
    public class Email
    {
        private string sender;
        private SecureString password;
        
        private string resiever;
        private string message;

        private string host;
        private int port;

        public Email(string _sender, SecureString _password, string _resiever, string _message, string _host, int _port)
        {
            sender = _sender;
            password = _password;
            resiever = _resiever;
            message = _message;
            host = _host;
            port = _port;
        }

        public void sendMail()
        {
            using (var client = new SmtpClient(host, port))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(sender, password);

                using (var Message = new MailMessage())
                {
                    Message.From = new MailAddress(sender);
                    Message.To.Add(new MailAddress(resiever));
                    Message.Body = message;
                    try
                    {
                        ChildWindow child = new ChildWindow();
                        child.Show();
                    }
                    catch (Exception error)
                    {
                        ChildWindow child = new ChildWindow();
                        child.lbl.Content = "Ошибка " + error;
                        child.Show();
                    }
                }
            }
        }
    }
}
