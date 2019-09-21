using System;
using System.Net;
using System.Windows;
using System.Net.Mail;
using System.Security;
using System.Windows.Documents;

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LogBtn_Click(object sender, RoutedEventArgs e)
        {
            Sender.senderAddress = login.Text;
            Sender.Password = password.SecurePassword;
            Sender.IsLogin = true;
        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Sender.IsLogin == true)
            {
                Sender.resieverAddress = resiever.Text;

                Sender.message = new TextRange(emailContent.Document.ContentStart, emailContent.Document.ContentEnd).Text + DateTime.Now;
                Email email = new Email(Sender.senderAddress, Sender.Password, Sender.resieverAddress, Sender.message, Sender.host, Sender.port);
                email.sendMail();
            }
        }
    }
}
