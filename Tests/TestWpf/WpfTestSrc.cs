using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWpf
{
    public static class WpfTestSrc
    {
        private static string smtpAdress = "smtp.mail.ru";
        private static int host = 25;
        private static string fromLetter = "irinasamylovskaya@mail.ru";
        private static string toLetter = "irinasamylovskaya@mail.ru";

        public static string SmtpAdress
        {
            get { return smtpAdress; }
            set { smtpAdress = value; }
        }

        public static int Host
        {
            get { return host; }
            set { host = value; }
        }

        public static string FromLetter
        {
            get { return fromLetter; }
            set { fromLetter = value; }
        }

        public static string ToLetter 
        {
            get { return toLetter; }
            set { toLetter = value; }
        }

    }
}
