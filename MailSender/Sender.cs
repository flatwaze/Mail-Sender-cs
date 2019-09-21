using System.Security;

namespace MailSender
{
    public static class Sender
    {
        public static string host = "smtp.yandex.ru";
        public static int port = 25;

        public static string senderAddress { get; set; }
        public static string senderName { get; set; }
        private static SecureString password;
        public static SecureString Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
        public static bool IsLogin { get; set; }

        public static string resieverAddress { get; set; }
        public static string resieverName { get; set; }

        public static string message { get; set; }

    }
}
